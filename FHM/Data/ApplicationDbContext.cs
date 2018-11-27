using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FHM.Models;
using FHM.Models.GameModel;
using FHM.Models.FormatModels;
using FHM.Models.PlayerIDModel;
using FHM.Models.TournamentModels;

namespace FHM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //DbSets
        public DbSet<ApplicationUser> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<PlayerID> PlayerIDs { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Game>().ToTable("Game");
            builder.Entity<PlayerID>(e =>
            {
                // This safe-guards for duplicates.
                e.HasIndex(prp => new { prp.GameId, prp.PlayerId }).IsUnique();
                e.HasOne(prp => prp.Game).WithMany(prp => prp.PlayerIDs).HasForeignKey(prp => prp.GameId);
                e.HasOne(prp => prp.Player).WithMany(prp => prp.PlayerIDs).HasForeignKey(prp => prp.PlayerId);
            }
            );


        }
    }
}
