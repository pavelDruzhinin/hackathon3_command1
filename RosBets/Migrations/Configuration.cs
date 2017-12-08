using RosBets.Models;
using System.Collections.Generic;
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
        }

        protected override void Seed(RosBets.Context.RosBetsContext context)
        {
            

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

            #region Чемпионат\Спорт
            Sport sport1 = new Sport { Id = 1, Name = "Футбол" };
            Sport sport2 = new Sport { Id = 2, Name = "Хоккей" };
            context.Sports.AddOrUpdate (sport1, sport2);

            Championship championship1 = new Championship { Id = 1, Name = "Футбол. Испания. Примера", SportId = 1 };
            Championship championship2 = new Championship { Id = 2, Name = "Футбол. Германия. Бундеслига", SportId = 1 };
            Championship championship3 = new Championship { Id = 3, Name = "Футбол. Англия. Премьер-лига", SportId = 1 };
            Championship championship4 = new Championship { Id = 4, Name = "Хоккей. Национальная Хоккейная Лига", SportId = 2 };
            context.Championships.AddOrUpdate(championship1, championship2, championship3,championship4);
            #endregion

            #region Матчи завершённые
            Match match1 = new Match
            {
                Id = 1,
                ChampionshipId = 1,
                Date = DateTime.Parse("20/11/2017 21:45"),
                Team1Name = "Реал",
                Team2Name = "Барселона",
                MatchName = "Реал - Барселона",
                MatchNumber = "2654",
                Team1Score = 1,
                Team2Score = 1,
                Finished = true
            };

            Match match2 = new Match
            {
                Id = 2,
                ChampionshipId = 1,
                Date = DateTime.Parse("22/11/2017 19:30"),
                Team1Name = "Атлетико Мадрид",
                Team2Name = "Вильяреал",
                MatchName = "Атлетико Мадрид - Вильяреал",
                MatchNumber = "6954",
                Team1Score = 3,
                Team2Score = 0,
                Finished = true
            };

            Match match3 = new Match
            {
                Id = 3,
                ChampionshipId = 2,
                Date = DateTime.Parse("19/11/2017 18:00"),
                Team1Name = "Боруссия Дортмунд",
                Team2Name = "Шальке-04",
                MatchName = "Боруссия Дортмунд - Шальке-04",
                MatchNumber = "32675",
                Team1Score = 2,
                Team2Score = 4,
                Finished = true
            };

            Match match4 = new Match
            {
                Id = 4,
                ChampionshipId = 2,
                Date = DateTime.Parse("24/11/2017 22:00"),
                Team1Name = "Бавария Мюнхен",
                Team2Name = "Вольфсбург",
                MatchName = "Бавария Мюнхен - Вольфсбург",
                MatchNumber = "6589",
                Team1Score = 5,
                Team2Score = 0,
                Finished = true
            };

            Match match5 = new Match
            {
                Id = 5,
                ChampionshipId = 3,
                Date = DateTime.Parse("23/11/2017 15:00"),
                Team1Name = "Арсенал Лондон",
                Team2Name = "Манчестер Сити",
                MatchName = "Арсенал Лондон - Манчестер Сити",
                MatchNumber = "321",
                Team1Score = 2,
                Team2Score = 2,
                Finished = true
            };

            Match match6 = new Match
            {
                Id = 6,
                ChampionshipId = 3,
                Date = DateTime.Parse("22/11/2017 12:00"),
                Team1Name = "Тоттенхем",
                Team2Name = "Лестер",
                MatchName = "Тоттенхем - Лестер",
                MatchNumber = "6475",
                Team1Score = 1,
                Team2Score = 2,
                Finished = true
            };
            Match match7 = new Match
            {
                Id = 7,
                ChampionshipId = 1,
                Date = DateTime.Parse("18/12/2017 21:45"),
                Team1Name = "Мальорка",
                Team2Name = "Севилья",
                MatchName = "Мальорка - Севилья",
                MatchNumber = "6894",
                Team1Score = 2,
                Team2Score = 1,
                Finished = true
            };
            #endregion

            #region Матчи незавершённые


            Match match8 = new Match
            {
                Id = 8,
                ChampionshipId = 1,
                Date = DateTime.Parse("19/12/2017 20:45"),
                Team1Name = "Атлетик Бильбао",
                Team2Name = "Малага",
                MatchName = "Атлетик Бильбао - Малага",
                MatchNumber = "9617",
                Team1Score = null,
                Team2Score = null,
                Finished = false
            };

            Match match9 = new Match
            {
                Id = 9,
                ChampionshipId = 2,
                Date = DateTime.Parse("20/12/2017 19:00"),
                Team1Name = "Герта Берлин",
                Team2Name = "Вердер Бремен",
                MatchName = "Герта Берлин - Вердер Бремен",
                MatchNumber = "6548",
                Team1Score = null,
                Team2Score = null,
                Finished = false
            };

            Match match10 = new Match
            {
                Id = 10,
                ChampionshipId = 2,
                Date = DateTime.Parse("20/12/2017 19:00"),
                Team1Name = "Юнион Берлин",
                Team2Name = "Айнтрахт",
                MatchName = "Юнион Берлин - Айнтрахт",
                MatchNumber = "6572",
                Team1Score = null,
                Team2Score = null,
                Finished = false
            };

            Match match11 = new Match
            {
                Id = 11,
                ChampionshipId = 3,
                Date = DateTime.Parse("21/12/2017 19:00"),
                Team1Name = "Эвертон",
                Team2Name = "Манчестер Юнайтед",
                MatchName = "Эвертон - Манчестер Юнайтед",
                MatchNumber = "2354",
                Team1Score = null,
                Team2Score = null,
                Finished = false
            };

            Match match12 = new Match
            {
                Id = 12,
                ChampionshipId = 3,
                Date = DateTime.Parse("21/12/2017 20:00"),
                Team1Name = "Ливерпуль",
                Team2Name = "Болтон",
                MatchName = "Ливерпуль - Болтон",
                MatchNumber = "6574",
                Team1Score = null,
                Team2Score = null,
                Finished = false
            };
            Match match13 = new Match
            {
                Id = 13,
                ChampionshipId = 4,
                Date = DateTime.Parse("24/12/2017 05:00"),
                Team1Name = "Анахайм",
                Team2Name = "Вашингтон",
                MatchName = "Анахайм - Вашингтон",
                MatchNumber = "1234",
                Team1Score = null,
                Team2Score = null,
                Finished = false
            };
            Match match14 = new Match
            {
                Id = 14,
                ChampionshipId = 4,
                Date = DateTime.Parse("24/12/2017 00:00"),
                Team1Name = "Торонто",
                Team2Name = "Колорадо",
                MatchName = "Торонто - Колорадо",
                MatchNumber = "6485",
                Team1Score = null,
                Team2Score = null,
                Finished = false
            };

            context.Matches.AddOrUpdate(match1, match2, match3, match4, match5, match6, match7, match8, match9, match10, match11, match12, match13, match14);


            #endregion

            #region Коэффициенты
            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 1, EventId = 1, EventValue = 2.5f },
                            new MatchEvent { MatchId = 1, EventId = 2, EventValue = 5.6f },
                            new MatchEvent { MatchId = 1, EventId = 3, EventValue = 6.8f },
                            new MatchEvent { MatchId = 1, EventId = 4, EventValue = 3.2f },
                            new MatchEvent { MatchId = 1, EventId = 5, EventValue = 3.3f },
                            new MatchEvent { MatchId = 1, EventId = 6, EventValue = 8.6f },
                            new MatchEvent { MatchId = 1, EventId = 7, EventValue =10.3f },
                            new MatchEvent { MatchId = 1, EventId = 8, EventValue = 5.3f},
                            new MatchEvent { MatchId = 1, EventId = 9, EventValue =1.45f  },
                            new MatchEvent { MatchId = 1, EventId = 10, EventValue = 1.5f },
                            new MatchEvent { MatchId = 1, EventId = 11, EventValue = 9.45f },
                            new MatchEvent { MatchId = 1, EventId = 12, EventValue = 5.34f  },
                            new MatchEvent { MatchId = 1, EventId = 13, EventValue = 2.0f},
                            new MatchEvent { MatchId = 1, EventId = 14, EventValue = 9.4f },
                            new MatchEvent { MatchId = 1, EventId = 15, EventValue = 2.6f }
                        );
            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 2, EventId = 1, EventValue = 2.5f },
                            new MatchEvent { MatchId = 2, EventId = 2, EventValue = 3.4f },
                            new MatchEvent { MatchId = 2, EventId = 3, EventValue = 5.1f },
                            new MatchEvent { MatchId = 2, EventId = 4, EventValue = 5.65f },
                            new MatchEvent { MatchId = 2, EventId = 5, EventValue = 4.13f },
                            new MatchEvent { MatchId = 2, EventId = 6, EventValue = 6.14f },
                            new MatchEvent { MatchId = 2, EventId = 7, EventValue =1.35f },
                            new MatchEvent { MatchId = 2, EventId = 8, EventValue = 1.39f},
                            new MatchEvent { MatchId = 2, EventId = 9, EventValue =1.90f  },
                            new MatchEvent { MatchId = 2, EventId = 10, EventValue = 1.5f },
                            new MatchEvent { MatchId = 2, EventId = 11, EventValue = 3.45f },
                            new MatchEvent { MatchId = 2, EventId = 12, EventValue = 4.32f  },
                            new MatchEvent { MatchId = 2, EventId = 13, EventValue = 2.0f},
                            new MatchEvent { MatchId = 2, EventId = 14, EventValue = 2.4f },
                            new MatchEvent { MatchId = 2, EventId = 15, EventValue = 1.26f }
                        );
            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 3, EventId = 1, EventValue = 2.5f },
                            new MatchEvent { MatchId = 3, EventId = 2, EventValue = 1.24f },
                            new MatchEvent { MatchId = 3, EventId = 3, EventValue = 6.11f },
                            new MatchEvent { MatchId = 3, EventId = 4, EventValue = 3.25f },
                            new MatchEvent { MatchId = 3, EventId = 5, EventValue = 1.63f },
                            new MatchEvent { MatchId = 3, EventId = 6, EventValue = 9.14f },
                            new MatchEvent { MatchId = 3, EventId = 7, EventValue =3.36f },
                            new MatchEvent { MatchId = 3, EventId = 8, EventValue = 2.29f},
                            new MatchEvent { MatchId = 3, EventId = 9, EventValue =3.94f  },
                            new MatchEvent { MatchId = 3, EventId = 10, EventValue = 5.55f },
                            new MatchEvent { MatchId = 3, EventId = 11, EventValue = 3.67f },
                            new MatchEvent { MatchId = 3, EventId = 12, EventValue = 9.52f  },
                            new MatchEvent { MatchId = 3, EventId = 13, EventValue = 2.0f},
                            new MatchEvent { MatchId = 3, EventId = 14, EventValue = 3.2f },
                            new MatchEvent { MatchId = 3, EventId = 15, EventValue = 6.26f }
                        );
            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 4, EventId = 1, EventValue = 3.5f },
                            new MatchEvent { MatchId = 4, EventId = 2, EventValue = 2.32f },
                            new MatchEvent { MatchId = 4, EventId = 3, EventValue = 9.15f },
                            new MatchEvent { MatchId = 4, EventId = 4, EventValue = 2.65f },
                            new MatchEvent { MatchId = 4, EventId = 5, EventValue = 6.14f },
                            new MatchEvent { MatchId = 4, EventId = 6, EventValue = 6.12f },
                            new MatchEvent { MatchId = 4, EventId = 7, EventValue =3.24f },
                            new MatchEvent { MatchId = 4, EventId = 8, EventValue = 3.59f},
                            new MatchEvent { MatchId = 4, EventId = 9, EventValue =5.64f  },
                            new MatchEvent { MatchId = 4, EventId = 10, EventValue = 2.5f },
                            new MatchEvent { MatchId = 4, EventId = 11, EventValue = 2.67f },
                            new MatchEvent { MatchId = 4, EventId = 12, EventValue = 6.52f  },
                            new MatchEvent { MatchId = 4, EventId = 13, EventValue = 3.0f},
                            new MatchEvent { MatchId = 4, EventId = 14, EventValue = 3.2f },
                            new MatchEvent { MatchId = 4, EventId = 15, EventValue = 3.3f }
                        );

            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 5, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 5, EventId = 2, EventValue = 3.32f },
                            new MatchEvent { MatchId = 5, EventId = 3, EventValue = 6.15f },
                            new MatchEvent { MatchId = 5, EventId = 4, EventValue = 4.15f },
                            new MatchEvent { MatchId = 5, EventId = 5, EventValue = 6.34f },
                            new MatchEvent { MatchId = 5, EventId = 6, EventValue = 6.22f },
                            new MatchEvent { MatchId = 5, EventId = 7, EventValue =3.63f },
                            new MatchEvent { MatchId = 5, EventId = 8, EventValue = 1.23f},
                            new MatchEvent { MatchId = 5, EventId = 9, EventValue =12.64f  },
                            new MatchEvent { MatchId = 5, EventId = 10, EventValue = 3.5f },
                            new MatchEvent { MatchId = 5, EventId = 11, EventValue = 1.67f },
                            new MatchEvent { MatchId = 5, EventId = 12, EventValue = 6.22f  },
                            new MatchEvent { MatchId = 5, EventId = 13, EventValue = 2.0f},
                            new MatchEvent { MatchId = 5, EventId = 14, EventValue = 3.2f },
                            new MatchEvent { MatchId = 5, EventId = 15, EventValue = 4.3f }
                        );

            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 6, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 6, EventId = 2, EventValue = 6.32f },
                            new MatchEvent { MatchId = 6, EventId = 3, EventValue = 3.15f },
                            new MatchEvent { MatchId = 6, EventId = 4, EventValue = 4.15f },
                            new MatchEvent { MatchId = 6, EventId = 5, EventValue = 3.34f },
                            new MatchEvent { MatchId = 6, EventId = 6, EventValue = 3.52f },
                            new MatchEvent { MatchId = 6, EventId = 7, EventValue = 3.63f },
                            new MatchEvent { MatchId = 6, EventId = 8, EventValue = 1.23f},
                            new MatchEvent { MatchId = 6, EventId = 9, EventValue = 12.64f  },
                            new MatchEvent { MatchId = 6, EventId = 10, EventValue = 3.5f },
                            new MatchEvent { MatchId = 6, EventId = 11, EventValue = 6.57f },
                            new MatchEvent { MatchId = 6, EventId = 12, EventValue = 9.02f  },
                            new MatchEvent { MatchId = 6, EventId = 13, EventValue = 3.0f},
                            new MatchEvent { MatchId = 6, EventId = 14, EventValue = 3.22f },
                            new MatchEvent { MatchId = 6, EventId = 15, EventValue = 3.65f }
                        );

            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 7, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 7, EventId = 2, EventValue = 2.12f },
                            new MatchEvent { MatchId = 7, EventId = 3, EventValue = 7.35f },
                            new MatchEvent { MatchId = 7, EventId = 4, EventValue = 3.25f },
                            new MatchEvent { MatchId = 7, EventId = 5, EventValue = 6.23f },
                            new MatchEvent { MatchId = 7, EventId = 6, EventValue = 2.22f },
                            new MatchEvent { MatchId = 7, EventId = 7, EventValue = 1.12f },
                            new MatchEvent { MatchId = 7, EventId = 8, EventValue = 6.23f},
                            new MatchEvent { MatchId = 7, EventId = 9, EventValue = 1.64f  },
                            new MatchEvent { MatchId = 7, EventId = 10, EventValue = 3.5f },
                            new MatchEvent { MatchId = 7, EventId = 11, EventValue = 6.57f },
                            new MatchEvent { MatchId = 7, EventId = 12, EventValue = 4.02f  },
                            new MatchEvent { MatchId = 7, EventId = 13, EventValue = 3.0f},
                            new MatchEvent { MatchId = 7, EventId = 14, EventValue = 2.23f },
                            new MatchEvent { MatchId = 7, EventId = 15, EventValue = 8.65f }
                        );

            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 8, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 8, EventId = 2, EventValue = 6.12f },
                            new MatchEvent { MatchId = 8, EventId = 3, EventValue = 2.65f },
                            new MatchEvent { MatchId = 8, EventId = 4, EventValue = 3.43f },
                            new MatchEvent { MatchId = 8, EventId = 5, EventValue = 3.13f },
                            new MatchEvent { MatchId = 8, EventId = 6, EventValue = 6.32f },
                            new MatchEvent { MatchId = 8, EventId = 7, EventValue = 5.12f },
                            new MatchEvent { MatchId = 8, EventId = 8, EventValue = 3.23f},
                            new MatchEvent { MatchId = 8, EventId = 9, EventValue = 2.64f  },
                            new MatchEvent { MatchId = 8, EventId = 10, EventValue = 3.5f },
                            new MatchEvent { MatchId = 8, EventId = 11, EventValue = 5.57f },
                            new MatchEvent { MatchId = 8, EventId = 12, EventValue = 4.12f  },
                            new MatchEvent { MatchId = 8, EventId = 13, EventValue = 3.0f},
                            new MatchEvent { MatchId = 8, EventId = 14, EventValue = 6.23f },
                            new MatchEvent { MatchId = 8, EventId = 15, EventValue = 9.65f }
                        );

            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 9, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 9, EventId = 2, EventValue = 3.12f },
                            new MatchEvent { MatchId = 9, EventId = 3, EventValue = 6.65f },
                            new MatchEvent { MatchId = 9, EventId = 4, EventValue = 5.13f },
                            new MatchEvent { MatchId = 9, EventId = 5, EventValue = 6.33f },
                            new MatchEvent { MatchId = 9, EventId = 6, EventValue = 2.23f },
                            new MatchEvent { MatchId = 9, EventId = 7, EventValue = 2.62f },
                            new MatchEvent { MatchId = 9, EventId = 8, EventValue = 1.2f},
                            new MatchEvent { MatchId = 9, EventId = 9, EventValue = 6.3f  },
                            new MatchEvent { MatchId = 9, EventId = 10, EventValue = 2.0f },
                            new MatchEvent { MatchId = 9, EventId = 11, EventValue = 1.17f },
                            new MatchEvent { MatchId = 9, EventId = 12, EventValue = 3.12f  },
                            new MatchEvent { MatchId = 9, EventId = 13, EventValue = 2.0f},
                            new MatchEvent { MatchId = 9, EventId = 14, EventValue = 6.23f },
                            new MatchEvent { MatchId = 9, EventId = 15, EventValue = 9.65f }
                        );
            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 10, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 10, EventId = 2, EventValue = 3.52f },
                            new MatchEvent { MatchId = 10, EventId = 3, EventValue = 3.25f },
                            new MatchEvent { MatchId = 10, EventId = 4, EventValue = 3.23f },
                            new MatchEvent { MatchId = 10, EventId = 5, EventValue = 1.23f },
                            new MatchEvent { MatchId = 10, EventId = 6, EventValue = 3.56f },
                            new MatchEvent { MatchId = 10, EventId = 7, EventValue = 2.12f },
                            new MatchEvent { MatchId = 10, EventId = 8, EventValue = 3.2f},
                            new MatchEvent { MatchId = 10, EventId = 9, EventValue = 6.2f  },
                            new MatchEvent { MatchId = 10, EventId = 10, EventValue = 2.0f },
                            new MatchEvent { MatchId = 10, EventId = 11, EventValue = 2.17f },
                            new MatchEvent { MatchId = 10, EventId = 12, EventValue = 3.42f  },
                            new MatchEvent { MatchId = 10, EventId = 13, EventValue = 1.0f},
                            new MatchEvent { MatchId = 10, EventId = 14, EventValue = 3.13f },
                            new MatchEvent { MatchId = 10, EventId = 15, EventValue = 2.65f }
                        );
            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 11, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 11, EventId = 2, EventValue = 5.52f },
                            new MatchEvent { MatchId = 11, EventId = 3, EventValue = 4.55f },
                            new MatchEvent { MatchId = 11, EventId = 4, EventValue = 3.22f },
                            new MatchEvent { MatchId = 11, EventId = 5, EventValue = 6.43f },
                            new MatchEvent { MatchId = 11, EventId = 6, EventValue = 3.12f },
                            new MatchEvent { MatchId = 11, EventId = 7, EventValue = 1.42f },
                            new MatchEvent { MatchId = 11, EventId = 8, EventValue = 6.2f},
                            new MatchEvent { MatchId = 11, EventId = 9, EventValue = 3.2f  },
                            new MatchEvent { MatchId = 11, EventId = 10, EventValue = 2.0f },
                            new MatchEvent { MatchId = 11, EventId = 11, EventValue = 1.17f },
                            new MatchEvent { MatchId = 11, EventId = 12, EventValue = 2.22f  },
                            new MatchEvent { MatchId = 11, EventId = 13, EventValue = 1.0f},
                            new MatchEvent { MatchId = 11, EventId = 14, EventValue = 9.43f },
                            new MatchEvent { MatchId = 11, EventId = 15, EventValue = 2.45f }
                        );

            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 12, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 12, EventId = 2, EventValue = 6.12f },
                            new MatchEvent { MatchId = 12, EventId = 3, EventValue = 1.35f },
                            new MatchEvent { MatchId = 12, EventId = 4, EventValue = 3.24f },
                            new MatchEvent { MatchId = 12, EventId = 5, EventValue = 1.23f },
                            new MatchEvent { MatchId = 12, EventId = 6, EventValue = 3.62f },
                            new MatchEvent { MatchId = 12, EventId = 7, EventValue = 3.22f },
                            new MatchEvent { MatchId = 12, EventId = 8, EventValue = 6.22f},
                            new MatchEvent { MatchId = 12, EventId = 9, EventValue = 1.12f  },
                            new MatchEvent { MatchId = 12, EventId = 10, EventValue = 2.0f },
                            new MatchEvent { MatchId = 12, EventId = 11, EventValue = 3.17f },
                            new MatchEvent { MatchId = 12, EventId = 12, EventValue = 6.22f  },
                            new MatchEvent { MatchId = 12, EventId = 13, EventValue = 1.0f},
                            new MatchEvent { MatchId = 12, EventId = 14, EventValue = 2.13f },
                            new MatchEvent { MatchId = 12, EventId = 15, EventValue = 3.35f }
                        );
            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 13, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 13, EventId = 2, EventValue = 2.12f },
                            new MatchEvent { MatchId = 13, EventId = 3, EventValue = 3.35f },
                            new MatchEvent { MatchId = 13, EventId = 4, EventValue = 4.24f },
                            new MatchEvent { MatchId = 13, EventId = 5, EventValue = 6.13f },
                            new MatchEvent { MatchId = 13, EventId = 6, EventValue = 1.32f },
                            new MatchEvent { MatchId = 13, EventId = 7, EventValue = 6.96f },
                            new MatchEvent { MatchId = 13, EventId = 8, EventValue = 3.12f},
                            new MatchEvent { MatchId = 13, EventId = 9, EventValue = 3.22f  },
                            new MatchEvent { MatchId = 13, EventId = 10, EventValue = 2.0f },
                            new MatchEvent { MatchId = 13, EventId = 11, EventValue = 3.17f },
                            new MatchEvent { MatchId = 13, EventId = 12, EventValue = 3.22f  },
                            new MatchEvent { MatchId = 13, EventId = 13, EventValue = 5.0f},
                            new MatchEvent { MatchId = 13, EventId = 14, EventValue = 3.13f },
                            new MatchEvent { MatchId = 13, EventId = 15, EventValue = 7.35f }
                        );
            context.MatchEvents.AddOrUpdate(
                            new MatchEvent { MatchId = 14, EventId = 1, EventValue = 1.5f },
                            new MatchEvent { MatchId = 14, EventId = 2, EventValue = 3.12f },
                            new MatchEvent { MatchId = 14, EventId = 3, EventValue = 3.35f },
                            new MatchEvent { MatchId = 14, EventId = 4, EventValue = 1.24f },
                            new MatchEvent { MatchId = 14, EventId = 5, EventValue = 3.13f },
                            new MatchEvent { MatchId = 14, EventId = 6, EventValue = 9.32f },
                            new MatchEvent { MatchId = 14, EventId = 7, EventValue = 2.96f },
                            new MatchEvent { MatchId = 14, EventId = 8, EventValue = 3.12f},
                            new MatchEvent { MatchId = 14, EventId = 9, EventValue = 3.22f  },
                            new MatchEvent { MatchId = 14, EventId = 10, EventValue = 3.0f },
                            new MatchEvent { MatchId = 14, EventId = 11, EventValue = 6.17f },
                            new MatchEvent { MatchId = 14, EventId = 12, EventValue = 3.22f  },
                            new MatchEvent { MatchId = 14, EventId = 13, EventValue = 6.0f},
                            new MatchEvent { MatchId = 14, EventId = 14, EventValue = 6.13f },
                            new MatchEvent { MatchId = 14, EventId = 15, EventValue = 3.35f }
                        );
            #endregion

            #region Новости
            RosBets.Models.News news = new Models.News
            { Id = 1, Text = @"<div>
	4 декабря в рамках регулярного чемпионата КХЛ встретятся «Салават Юлаев» и «Динамо».<br>
</div>
<div>
	<br>
</div>
<div>
	Ставка уфимцев на оборону наконец-то стала давать свои плоды. Первым соперником, который прочувствовал итоговые изменения «юлаевцев», стал «Ак Барс». Полная безысходность читалась в глазах игроков, которые не могли ничего поделать с «Салаватом». Всего одна шайба решила исход того матча, и забили её подопечные Эркки Вестерлунда. Важная победа, и главное вовремя, так как слухи о конфликте внутри клуба нарастали с каждой проигранной встречей. Второй удачный матч уфимцы провели с минским «Динамо». И снова «сухая» игра Скривенса, но на этот раз «Салават» забил две шайбы.
</div>
<div>
	<br>
</div>
<div>
	«Динамо» в этом сезоне часто теряет очки в матчах, в которых это в принципе сложно сделать. Команда набрала ход, но прервала серию из четырёх побед в Подольске (3:5). После этого в борьбе победило «Авангард» (2:1) и «Сибирь» (6:4). Но в минувшем туре оступилось в Сочи (4:1). Москвичам явно не хватает стабильности.
</div>
<div>
	<br>
</div>
<div>
	<strong>Мнение экспертов БК «RosBets»:</strong> В этом противостоянии в последние сезоны наблюдается равенство в результатах. Есть только существенное различие. «Салават Юлаев», как правило, побеждает минимальной разницей, если успех празднует «Динамо», то шайб забрасывается много. В этом сезоне в Москве «Салавату» удалось выиграть со счётом 3:2. Сумеют ли бело-голубые взять реванш?
</div>
<div><br>
</div>
<div>
	Матч между «Салаватом Юлаевым» и «Динамо» состоится 4 декабря в 17:00 МСК.
</div>", Caption = "КХЛ. ВОЗЬМЁТ ЛИ «ДИНАМО» РЕВАЕШ ЗА ДОМАШНЕЕ ПОРАЖЕНИЕ?" };
            context.News.AddOrUpdate(news);
            #endregion

            #region Ставки

            context.Bets.AddOrUpdate(
                new Bet() { Id=1, UserId=1, Date=DateTime.Parse("18.11.2017"), BetAmount = 500, Success = true, TotalCoefficient = 3.3f, Payout = 1650m},
                new Bet() { Id=2, UserId=1, Date=DateTime.Parse("20.11.2017"), BetAmount = 100, Success = true, TotalCoefficient = 19.21f, Payout = 1921m},
                new Bet() { Id = 3, UserId = 1, Date = DateTime.Parse("25.11.2017"), BetAmount = 420, Success = false,TotalCoefficient = 2.22f, Payout = 0 }, //932.4m},
                new Bet() { Id = 4, UserId = 1, Date = DateTime.Parse("25.11.2017"), BetAmount = 322, TotalCoefficient = 203.4998784f, Payout = 65526.9608448m } //65526.9608448m }
            );

            context.BetEvents.AddOrUpdate(
                new BetEvent() { BetId = 1, EventId = 5, MatchId = 1,BetEventStatusId = 1, Coefficient = 3.3f },

                new BetEvent() { BetId = 2, EventId = 2, MatchId = 2, BetEventStatusId = 1, Coefficient = 3.4f,Total = 2.5f },
                new BetEvent() { BetId = 2, EventId = 4, MatchId = 2, BetEventStatusId = 1, Coefficient = 5.65f }, 

                new BetEvent() { BetId = 3, EventId = 6, MatchId = 7, BetEventStatusId = 2, Coefficient = 2.22f },

                new BetEvent() { BetId = 4, EventId = 5, MatchId = 9, BetEventStatusId = 4, Coefficient = 6.33f }, //6.33
                new BetEvent() { BetId = 4, EventId = 2, MatchId = 9, BetEventStatusId = 1, Coefficient = 3.12f, Total = 1.5f }, //3.12
                new BetEvent() { BetId = 4, EventId = 8, MatchId = 10, BetEventStatusId = 1, Coefficient = 3.2f, }, //3.2
                new BetEvent() { BetId = 4, EventId = 4, MatchId = 11, BetEventStatusId = 4 , Coefficient = 3.22f } //3.22

            );
            #endregion

            #region Статусы ставок
            context.BetEventsStatus.AddOrUpdate
                (
                new BetEventStatus { Id = 1, Status = "Выигрыш" },
                new BetEventStatus { Id = 2, Status = "Проигрыш" },
                new BetEventStatus { Id = 3, Status = "Возврат" },
                new BetEventStatus { Id = 4, Status = "Не рассчитан" }
                );

            #endregion

        }
    }
}
