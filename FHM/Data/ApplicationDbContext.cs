﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FHM.Models;
using FHM.Models.GameModel;
using FHM.Models.FormatModels;

namespace FHM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //DbSets
        public DbSet<Game> Games { get; set; }
        public DbSet<Format> Formats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Game>().ToTable("Game");
        }

        public DbSet<FHM.Models.FormatModels.Format> Format { get; set; }
    }
}
