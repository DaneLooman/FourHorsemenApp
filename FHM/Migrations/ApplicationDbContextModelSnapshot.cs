﻿// <auto-generated />
using FHM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FHM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FHM.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FHM.Models.FormatModels.Format", b =>
                {
                    b.Property<int>("FormatID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FormatDescription")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("FormatLink")
                        .IsRequired();

                    b.Property<string>("FormatName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("GameID");

                    b.HasKey("FormatID");

                    b.HasIndex("GameID");

                    b.ToTable("Formats");
                });

            modelBuilder.Entity("FHM.Models.GameModel.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GameImageThumbnailURL");

                    b.Property<string>("GameImageUrl");

                    b.Property<bool>("GameIsGameOfTheWeek");

                    b.Property<string>("GameLongDescription")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("GameShortDescription")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.HasKey("GameID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("FHM.Models.LinkTables.PlayerID_Tournament", b =>
                {
                    b.Property<int>("PlayerIDID");

                    b.Property<int>("TournamentID");

                    b.Property<bool>("Paid");

                    b.HasKey("PlayerIDID", "TournamentID");

                    b.HasIndex("TournamentID");

                    b.ToTable("PlayerID_Tournament");
                });

            modelBuilder.Entity("FHM.Models.PlayerIDModel.PlayerID", b =>
                {
                    b.Property<int>("PlayerIDID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameId");

                    b.Property<string>("PlayerGameID");

                    b.Property<string>("PlayerId");

                    b.HasKey("PlayerIDID");

                    b.HasIndex("PlayerId");

                    b.HasIndex("GameId", "PlayerId")
                        .IsUnique()
                        .HasFilter("[PlayerId] IS NOT NULL");

                    b.ToTable("PlayerIDs");
                });

            modelBuilder.Entity("FHM.Models.TournamentModels.Tournament", b =>
                {
                    b.Property<int>("TournamentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FormatID");

                    b.Property<int?>("GameID");

                    b.Property<bool>("IsMajorTournament");

                    b.Property<string>("TournamentDescription")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<decimal>("TournamentFee");

                    b.Property<string>("TournamentName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("TournamentStartTime");

                    b.HasKey("TournamentID");

                    b.HasIndex("FormatID");

                    b.HasIndex("GameID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FHM.Models.FormatModels.Format", b =>
                {
                    b.HasOne("FHM.Models.GameModel.Game", "Game")
                        .WithMany("GameFormats")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FHM.Models.LinkTables.PlayerID_Tournament", b =>
                {
                    b.HasOne("FHM.Models.PlayerIDModel.PlayerID", "Player")
                        .WithMany("Tournaments")
                        .HasForeignKey("PlayerIDID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FHM.Models.TournamentModels.Tournament", "Tournament")
                        .WithMany("PlayerIDIDs")
                        .HasForeignKey("TournamentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FHM.Models.PlayerIDModel.PlayerID", b =>
                {
                    b.HasOne("FHM.Models.GameModel.Game", "Game")
                        .WithMany("PlayerIDs")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FHM.Models.ApplicationUser", "Player")
                        .WithMany("PlayerIDs")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("FHM.Models.TournamentModels.Tournament", b =>
                {
                    b.HasOne("FHM.Models.FormatModels.Format", "TournamentFormat")
                        .WithMany()
                        .HasForeignKey("FormatID");

                    b.HasOne("FHM.Models.GameModel.Game", "TournamentGame")
                        .WithMany()
                        .HasForeignKey("GameID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FHM.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FHM.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FHM.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FHM.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
