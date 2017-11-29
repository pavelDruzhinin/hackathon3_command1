using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RosBets.Controllers
{
    public class BetController : Controller
    {
        [HttpPost]
        public ActionResult GetCoupon(params string[] selectedIds)
        {
            var ids = new List<string>();
            if (selectedIds != null)
            {
                ids.AddRange(selectedIds);
            }

            return PartialView("right_column", ids);
        }
    }
}