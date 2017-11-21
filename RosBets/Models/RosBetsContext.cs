﻿using RosBets.Models;
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
}