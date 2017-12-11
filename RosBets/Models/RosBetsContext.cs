using RosBets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.Ports;
using System.Linq;
using System.Web;

namespace RosBets.Context
{
    public class RosBetsContext : DbContext
    {
        public RosBetsContext() : base("name=RosBetsContext")
        {
        }

        public RosBetsContext(String sqlConnectionName) :
            base($"Name={sqlConnectionName}")
        {
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<BetEvent> BetEvents { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<MatchEvent> MatchEvents { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Championship> Championships { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<News> News { get; set; }
        public DbSet<BetEventStatus> BetEventsStatus { get; set; }

        public DbSet<CouponEvent> CouponEvents { get; set; }
        public DbSet<Pay> Pays { get; set; }

    }
}