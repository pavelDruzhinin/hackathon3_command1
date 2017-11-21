using RosBets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RosBets.Context
{
    public class RosBetsContext : DbContext
    {
        public RosBetsContext()
            : base("name=RosBetsContext")
        {
        }
        static RosBetsContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<BetsDetail> BetDetails { get; set; }

        public DbSet<LineFootball> LinesFootball { get; set; } //LineSFootball 

        public DbSet<Result> Results { get; set; }

        public DbSet<ResultDetail> ResultDetails { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BetsDetail>()
            .HasKey(bd => new { bd.BetsId, bd.Event });

            modelBuilder.Entity<ResultDetail>()
            .HasKey(rd => new { rd.ResultId, rd.Event });

        }
    }
    class MyContextInitializer : DropCreateDatabaseAlways<RosBetsContext>
    {
        protected override void Seed(RosBetsContext db)
        {
            #region//1. Создание двух пользователей
            User user1 = new User
            {
                Id = 1,
                FirstName = "Тест",
                LastName = "Тестов",
                MiddleName = "Тестович",
                City = "Петрозаводск",
                Phone = "+79000000000",
                Mail = "test@mail.ru",
                Password = "123456",
                Money = 1500
                
            };
            User user2 = new User
            {
                Id = 2,
                FirstName = "Пример",
                LastName = "Примеров",
                MiddleName = "Примерович",
                City = "Кондопога",
                Phone = "+79111111111",
                Mail = "primer@mail.ru",
                Password = "789102",
                Money = 3000f
            };
            #endregion

            #region  //2. Создание событий 

            //Первые три прошедшие
            LineFootball lf1 = new LineFootball
            {
                Id = 1,
                IdGames = "123",
                Championat = "Лига Чемпионов",
                Event = "Реал - Монако",
                Date = DateTime.Parse("20/11/2017 21:45"),
                P1 = 1.45f,
                X = 3.2f,
                P2 = 2.1f
            };

            LineFootball lf2 = new LineFootball
            {
                Id = 2,
                IdGames = "4564",
                Championat = "Чемпионат России",
                Event = "Уфа - Урал",
                Date = DateTime.Parse("19/11/2017 15:00"),
                P1 = 2.14f,
                X = 3.8f,
                P2 = 5.1f
            };

            LineFootball lf3 = new LineFootball
            {
                Id = 3,
                IdGames = "12564",
                Championat = "Чемпионат России",
                Event = "Ростов - Краснодар",
                Date = DateTime.Parse("18/11/2017 12:00"),
                P1 = 6.2f,
                X = 4.2f,
                P2 = 2.3f
            };
            //Остальные предстоящие

            LineFootball lf4 = new LineFootball
            {
                Id = 4,
                IdGames = "4684",
                Championat = "Лига Чемпионов",
                Event = "Барселона - Милан",
                Date = DateTime.Parse("28/11/2017 21:45"),
                P1 = 1.45f,
                X = 5.4f,
                P2 = 3.1f
            };
            LineFootball lf5 = new LineFootball
            {
                Id = 5,
                IdGames = "9862",
                Championat = "Лига Чемпионов",
                Event = "Марсель - Порту",
                Date = DateTime.Parse("28/11/2017 21:45"),
                P1 = 2.45f,
                X = 3.3f,
                P2 = 2.13f
            };

            LineFootball lf6 = new LineFootball
            {
                Id = 6,
                IdGames = "85645",
                Championat = "Лига Чемпионов",
                Event = "Арсенал - Базель",
                Date = DateTime.Parse("27/11/2017 21:45"),
                P1 = 1.17f,
                X = 3.3f,
                P2 = 5.18f
            };
            LineFootball lf7 = new LineFootball
            {
                Id = 7,
                IdGames = "6547",
                Championat = "Лига Чемпионов",
                Event = "Манчестер Сити - Интер",
                Date = DateTime.Parse("27/11/2017 20:00"),
                P1 = 1.38f,
                X = 5.6f,
                P2 = 9.18f
            };

            LineFootball lf8 = new LineFootball
            {
                Id = 8,
                IdGames = "6487",
                Championat = "Чемпионат России",
                Event = "Динамо - Спартак",
                Date = DateTime.Parse("25/11/2017 14:00"),
                P1 = 3f,
                X = 5.3f,
                P2 = 1.02f
            };
            LineFootball lf9 = new LineFootball
            {
                Id = 9,
                IdGames = "6487",
                Championat = "Чемпионат России",
                Event = "Локомотив - Зенит",
                Date = DateTime.Parse("24/11/2017 17:00"),
                P1 = 2.11f,
                X = 3.02f,
                P2 = 1.92f
            };

            LineFootball lf10 = new LineFootball
            {
                Id = 10,
                IdGames = "95478",
                Championat = "Чемпионат России",
                Event = "ЦСКА - Краснодар",
                Date = DateTime.Parse("25/11/2017 20:00"),
                P1 = 4.11f,
                X = 3.02f,
                P2 = 2.14f
            };

            LineFootball lf11 = new LineFootball
            {
                Id = 10,
                IdGames = "6433",
                Championat = "Чемпионат России",
                Event = "Арсенал Тула - Кубань",
                Date = DateTime.Parse("24/11/2017 12:00"),
                P1 = 3.11f,
                X = 2.52f,
                P2 = 1.38f
            };
            #endregion


            #region //Ставки

            #region// Ставка пользователя User1. Простой ординар. Матч уже завершён
            Bet bet = new Bet
            {
                Id = 1,
                UserId = 1,
                Date = DateTime.Parse("17/11/2017 12:15"),
                Success = true,
                ToPayoff = 217.5f,
                BetAmount =150f  
                
            };

            BetsDetail betDetail = new BetsDetail
            {
                BetsId = 1,
                Championat = "Лига чемпионов",
                Event = "Реал - Монако",
                Cef = 1.45f,
                P1 = true,
                P2 = false,
                X = false,
                Success = true
            };
            #endregion


            #region //Ставка пользователя User1. Экспресс проигранный

            Bet bet2 = new Bet
            {
                Id = 2,
                UserId = 1,
                Date = DateTime.Parse("16/11/2017 18:31"),
                Success = false,
                ToPayoff = 0f,
                BetAmount = 200f
            };

            BetsDetail betDet2_1 = new BetsDetail
            {
                BetsId = 2,
                Championat = "Чемпионат России",
                Event = "Уфа - Урал",
                Cef = 3.8f,
                P1 = false,
                P2 = false,
                X = true,
                Success = true
            };

            BetsDetail betDet2_2 = new BetsDetail
            {
                BetsId = 2,
                Championat = "Чемпионат России",
                Event = "Ростов - Краснодар",
                Cef = 2.14f,
                P1 = true,
                P2 = false,
                X = false,
                Success = false
            };


            #endregion

            #region Ставка пользователя User2. Нерасчитанный Экспресс
            Bet bet3 = new Bet
            {
                Id = 3,
                Date = DateTime.Parse("15/11/2017 17:42"),
                UserId = 2,
                BetAmount = 450f,
                ToPayoff = null,
                Success = null
            };

            BetsDetail betDet3_1 = new BetsDetail
            {
                BetsId = 3,
                Championat = "Лига Чемпионов",
                Event = "Реал - Монако",
                Cef = 1.45f,
                P1 = true,
                P2 = false,
                X = false,
                Success = true
            };

            BetsDetail betDet3_2 = new BetsDetail
            {
                BetsId = 3,
                Championat = "Лига Чемпионов",
                Event = "Барселона - Милан",
                Cef = 3.1f,
                P1 = false,
                P2 = true,
                X = false,
                Success = null
            };
            BetsDetail betsDet3_3 = new BetsDetail
            {
                BetsId = 3,
                Championat = "Чемпионат России",
                Event = "Динамо - Спартак",
                Cef = 5.3f,
                P1 = false,
                P2 = false,
                X = true,
                Success = null
            };
            
            #endregion

            #endregion


            #region Результаты прошедших матчей
            Result result1 = new Result
            {
                Id = 1,
                Date = DateTime.Parse("20/11/2017 21:45"),
                Championat = "Лига Чемпионов",
                Event = "Реал - Монако",
                FirstResult = 2,
                SecondResult = 0,
                Calculated = true
            };
            ResultDetail resultDet1 = new ResultDetail
            {
                ResultId = 1,
                Event = "Реал - Монако",
                Championat = "Лига Чемпионов",
                FirstWin = true,
                SecondWin = false,
                Draw = false
            };

            Result result2 = new Result()
            {

                Id = 2,
                Date = DateTime.Parse("19/11/2017 15:00"),
                Event = "Уфа - Урал",
                Championat = "Чемпионат России",
                FirstResult  = 1,
                SecondResult = 1,
                Calculated = true

            };
            ResultDetail resultDet2 = new ResultDetail
            {
                ResultId = 2,
                Event = "Уфа - Урал",
                Championat = "Чемпионат России",
                FirstWin = false,
                SecondWin = false,
                Draw = true
            };


            Result result3 = new Result
            {
                Id = 3,
                Date = DateTime.Parse("18/11/2017 12:00"),
                Event = "Ростов - Краснодар",
                Championat = "Чемпионат России",
                FirstResult = 2,
                SecondResult = 3,
                Calculated = true
            };

            ResultDetail resultDet3 = new ResultDetail
            {
                ResultId = 3,
                Championat = "Чемпионат России",
                Event = "Ростов - Краснодар",
                FirstWin = false,
                SecondWin = true,
                Draw = false
            };
            #endregion

            db.Users.AddRange(new List<User>() { user1, user2 });
            db.ResultDetails.AddRange(new List<ResultDetail> {resultDet1,resultDet2,resultDet3 });
            db.Results.AddRange(new List<Result> { result1,result2,result3});
            db.LinesFootball.AddRange(new List<LineFootball> { lf1, lf2, lf3, lf4, lf5, lf6, lf7, lf8, lf9, lf10 });
            db.Bets.AddRange(new List<Bet> { bet, bet2,bet3 });
            db.BetDetails.AddRange(new List<BetsDetail> { betDetail, betDet2_1, betDet2_2,betDet3_1,betDet3_2,betsDet3_3 });
           
            
            db.SaveChanges();

        }
    }

}