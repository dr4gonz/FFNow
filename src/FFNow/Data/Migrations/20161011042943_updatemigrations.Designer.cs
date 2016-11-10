using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FFNow.Data;

namespace FFNow.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161011042943_updatemigrations")]
    partial class updatemigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FFNow.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FFNow.Models.NflGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AwayScore");

                    b.Property<string>("AwayScoreOvertime");

                    b.Property<string>("AwayScoreQuarter1");

                    b.Property<string>("AwayScoreQuarter2");

                    b.Property<string>("AwayScoreQuarter3");

                    b.Property<string>("AwayScoreQuarter4");

                    b.Property<string>("AwayTeam");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("HasStarted");

                    b.Property<string>("HomeScore");

                    b.Property<string>("HomeScoreOvertime");

                    b.Property<string>("HomeScoreQuarter1");

                    b.Property<string>("HomeScoreQuarter2");

                    b.Property<string>("HomeScoreQuarter3");

                    b.Property<string>("HomeScoreQuarter4");

                    b.Property<string>("HomeTeam");

                    b.Property<bool>("IsInProgress");

                    b.Property<bool>("IsOver");

                    b.Property<string>("Quarter");

                    b.Property<string>("QuarterDescription");

                    b.Property<string>("StadiumName");

                    b.Property<string>("TimeRemaining");

                    b.Property<string>("Week");

                    b.HasKey("Id");

                    b.ToTable("NflGames");
                });

            modelBuilder.Entity("FFNow.Models.NflNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Opinion");

                    b.Property<string>("Team");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("NflNews");
                });

            modelBuilder.Entity("FFNow.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("FantasyPoints");

                    b.Property<float>("Fumbles");

                    b.Property<float>("FumblesLost");

                    b.Property<string>("Name");

                    b.Property<float>("PassingAttempts");

                    b.Property<float>("PassingCompletionPercentage");

                    b.Property<float>("PassingCompletions");

                    b.Property<float>("PassingInterceptions");

                    b.Property<float>("PassingRating");

                    b.Property<float>("PassingTouchdowns");

                    b.Property<float>("PassingYards");

                    b.Property<int>("Played");

                    b.Property<int>("PlayerID");

                    b.Property<string>("Position");

                    b.Property<float>("ReceivingTargets");

                    b.Property<float>("ReceivingTouchdowns");

                    b.Property<float>("ReceivingYards");

                    b.Property<float>("Receptions");

                    b.Property<float>("RecevingYardsPerReception");

                    b.Property<float>("RushingAttempts");

                    b.Property<float>("RushingTouchdowns");

                    b.Property<float>("RushingYards");

                    b.Property<float>("RushingYardsPerAttempt");

                    b.Property<int>("Started");

                    b.Property<string>("Team");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FFNow.Models.PlayersTeams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PlayerId");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayersTeams");
                });

            modelBuilder.Entity("FFNow.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FFNow.Models.Player", b =>
                {
                    b.HasOne("FFNow.Models.Team", "UserTeam")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("FFNow.Models.PlayersTeams", b =>
                {
                    b.HasOne("FFNow.Models.Player", "Player")
                        .WithMany("PlayersTeams")
                        .HasForeignKey("PlayerId");

                    b.HasOne("FFNow.Models.Team", "Team")
                        .WithMany("PlayersTeams")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("FFNow.Models.Team", b =>
                {
                    b.HasOne("FFNow.Models.ApplicationUser", "User")
                        .WithMany("Teams")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FFNow.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FFNow.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FFNow.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
