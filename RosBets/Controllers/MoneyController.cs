using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using RosBets.Context;
using RosBets.Models;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

namespace RosBets.Controllers
{
    public class MoneyController : Controller
    {
        static RosBetsContext db = new RosBetsContext();

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(decimal? Money,string action)
        { 
            var user = db.Users.Where(u => u.Mail == User.Identity.Name).FirstOrDefault();
            if (Money != null)
            {
                if (Money > 0) {
                    if (ModelState.IsValid)
                    {
                        if (action == "put")
                        {
                            Pay pay = new Pay();
                            pay.Sum = Convert.ToDecimal(Money);
                            pay.UserId = user.Id;
                            db.Pays.Add(pay);
                            db.SaveChanges();
                            return RedirectToAction("DepositingMoney", "Money");

                        }
                        else
                        if (Money <= user.Money && action == "pick")
                        {
                            user.Money -= (decimal)Money;
                            db.SaveChanges();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Неверная сумма для вывода");
                        }
                    }
                }
                else { ModelState.AddModelError("", "Введено отрицательное число"); }
            }
            else { ModelState.AddModelError("", "Введены некорректные символы"); }
            return View(user);
        }

        public ActionResult DepositingMoney()
        {
            Pay payUser = (from u in db.Pays
                           where u.User.Mail == User.Identity.Name
                           select u).ToList().LastOrDefault();

            PayModel paymodel = new PayModel() { PayId = payUser.Id, Sum = payUser.Sum, Name = $"{payUser.User.LastName} {payUser.User.FirstName}" };
            return View(paymodel);
        }
        [HttpGet]
        public ActionResult Paid()
        {
            News news = (from x in db.News
                         select x).ToList().LastOrDefault();
            return View("~/Views/Home/Index.cshtml", news);
        }
        [HttpPost]
        public void Paid(string notification_type, string operation_id, string label, string datetime,
                        decimal amount, decimal withdraw_amount, string sender, string sha1_hash,
                        string currency, bool codepro)
        {
            string key = "TkoZrlU+OeTzSXpAwuLtzXUf";
            // проверяем хэш
            string paramString = string.Format("{0}&{1}&{2}&{3}&{4}&{5}&{6}&{7}&{8}",
        notification_type, operation_id, amount, currency, datetime, sender,
        codepro.ToString().ToLower(), key, label);
            string paramStringHash1 = GetHash(paramString);
            // создаем класс для сравнения строк
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            // если хэши идентичны, добавляем данные о заказе в бд
            if (0 == comparer.Compare(paramStringHash1, sha1_hash))
            {
                Pay pay = (from p in db.Pays
                           where p.Id.ToString() == label
                           select p).FirstOrDefault();

                User user = (from u in db.Users
                             where u.Id == pay.UserId
                             select u).FirstOrDefault();
                user.Money += decimal.Parse(amount.ToString(), NumberStyles.Currency, CultureInfo.InvariantCulture);
                
                pay.Operation_Id = operation_id;
                pay.Date = DateTime.Now;
                pay.Amount = decimal.Parse(amount.ToString(), NumberStyles.Currency, CultureInfo.InvariantCulture); ;
                
                pay.WithdrawAmount = decimal.Parse(withdraw_amount.ToString(), NumberStyles.Currency, CultureInfo.InvariantCulture); ; ;
                
                pay.Sender = sender;
                db.Entry(pay).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public string GetHash(string val)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] data = sha.ComputeHash(Encoding.Default.GetBytes(val));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
}