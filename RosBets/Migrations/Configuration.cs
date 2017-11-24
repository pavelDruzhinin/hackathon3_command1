using System.Collections.Generic;
using RosBets.Models;

namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RosBets.Context.RosBetsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RosBets.Context.RosBetsContext";
        }

        protected override void Seed(RosBets.Context.RosBetsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Создание двух пользователей

            context.Users.AddOrUpdate(
                new User
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

                },
                new User
                {
                    Id = 2,
                    FirstName = "Пример",
                    LastName = "Примеров",
                    MiddleName = "Примерович",
                    City = "Кондопога",
                    Phone = "+79111111111",
                    Mail = "primer@mail.ru",
                    Password = "789102",
                    Money = 3000
                }
            );



            #endregion

            #region Список событий

            context.Events.AddOrUpdate(
                new Event
                {
                    Id = 1,
                    Shortname = "Total",
                    FullName = "Тотал матча"
                },
               new Event
                {
                    Id = 2,
                    Shortname = "TotalMore",
                    FullName = "Тотал больше"
                },
               new Event
                {
                    Id = 3,
                    Shortname = "TotalLess",
                    FullName = "Тотал меньше"
                },
               new Event
                {
                    Id = 4,
                    Shortname = "Win1",
                    FullName = "Победа хозяев"
                },
               new Event
                {
                    Id = 5,
                    Shortname = "X",
                    FullName = "Ничья"
                },
               new Event
                {
                    Id = 6,
                    Shortname = "Win2",
                    FullName = "Победа гостей"
                },
               new Event
                {
                    Id = 7,
                    Shortname = "1X",
                    FullName = "Победа хозяев или ничья"
                },
               new Event
                {
                    Id = 8,
                    Shortname = "12",
                    FullName = "Победа хозяев или гостей"
                },
               new Event
                {
                    Id = 9,
                    Shortname = "2X",
                    FullName = "Победа гостей или ничья"
                },
               new Event
                {
                    Id = 10,
                    Shortname = "iT1",
                    FullName = "Индивидуальный тотал хозяев"
                },
                new Event
                {
                    Id = 11,
                    Shortname = "iT1More",
                    FullName = "Индивидуальный тотал хозяев больше"
                },
                new Event
                {
                    Id = 12,
                    Shortname = "iT1Less",
                    FullName = "Индивидуальный тотал Хозяев меньше"
                },
               new Event
                {
                    Id = 13,
                    Shortname = "iT2",
                    FullName = "Индивидуальный тотал гостей"
                },
                new Event
                {
                    Id = 14,
                    Shortname = "iT2More",
                    FullName = "Индивидуальный тотал гостей больше"
                },
                new Event
                {
                    Id = 15,
                    Shortname = "iT2Less",
                    FullName = "Индивидуальный тотал гостей меньше"
                }
            );

            #endregion

        }
    }
}
