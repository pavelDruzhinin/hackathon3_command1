﻿using RosBets.Models;
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
                    ConfirmPassword = "123456",
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
                    ConfirmPassword = "789102",
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
            context.Sports.AddRange(new List<Sport> { sport1, sport2 });

            Championship championship1 = new Championship { Id = 1, Name = "Футбол. Испания. Примера", SportId = 1 };
            Championship championship2 = new Championship { Id = 2, Name = "Футбол. Германия. Бундеслига", SportId = 1 };
            Championship championship3 = new Championship { Id = 3, Name = "Футбол. Англия. Премьер-лига", SportId = 1 };
            Championship championship4 = new Championship { Id = 4, Name = "Хоккей. Национальная Хоккейная Лига", SportId = 2 };
            context.Championships.AddRange(new List<Championship> { championship1, championship2, championship3,championship4 });
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
            #endregion

            #region Матчи незавершённые
            Match match7 = new Match
            {
                Id = 7,
                ChampionshipId = 1,
                Date = DateTime.Parse("18/12/2017 21:45"),
                Team1Name = "Мальорка",
                Team2Name = "Севилья",
                MatchName = "Мальорка - Севилья",
                MatchNumber = "6894",
                Team1Score = null,
                Team2Score = null,
                Finished = false
            };

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

            context.Matches.AddRange(new List<Match> { match1,match2,match3,match4,match5,match6,match7,match8,match9,match10,match11,match12,match13,match14});


            #endregion

            #region Коэффициенты
            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });
            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });
            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });
            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });

            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });

            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });

            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });

            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });

            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });
            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });
            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });

            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });
            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });
            context.MatchEvents.AddRange(new List<MatchEvent>
                        {
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
                        });
            #endregion

            #region Новости
            RosBets.Models.News news = new Models.News
            { Id = 1, Text = @"Пари дня
РФПЛ. ВОЗЬМЕТ ЛИ ЦСКА ТРИ ОЧКА В КАЗАНИ? 
ЦСКА с хорошим настроением готовился к матчу против «Рубина». В Лиге чемпионов красно-синие обыграли дома «Бенфику» и гарантировали себе евровесну. Остаются у ЦСКА шансы сыграть и в плей-офф Лиги чемпионов, но для этого нужно будет обыгрывать в Англии «МЮ». 

У «Рубина» совсем другие заботы — пять матчей подряд команда не может одержать победу и два матча не может забить. Казанцы находятся на 11 месте лишь в трех очках от зоны переходных матчей. 

Мнение экспертов БК «Лига Ставок»: «Армейцы» выиграли лишь однажды в последних четырех турах, а потому терять очки им крайне нежелательно — преследователи в лице «Спартака» и «Краснодара» не дремлют. С другой стороны, у ЦСКА немало потерь в составе, но игра с «Бенфикой» показала тактическую гибкость команды, когда роль центрального нападающего отправился исполнять Понтус Вернблум. Удастся ли ему забить в ворота «Рубина»? 

Матч начнется 26 ноября в 14:00 МСК. " };
            context.News.Add(news);
            #endregion

            

        }
    }
}