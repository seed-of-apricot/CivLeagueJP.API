using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CivLeagueJP.API.Models.Civ6;
using CivLeagueJP.API.Models;

namespace CivLeagueJP.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                            .Property(t => t.Id)
                            .ValueGeneratedNever();
            
            builder.Entity<UserPlayerConnection>()
                .HasIndex(t => t.ApplicationUserId)
                .IsUnique();

            builder.Entity<UserPlayerConnection>()
                .HasOne(t => t.ApplicationUser)
                .WithMany(t => t.UserPlayerConnection);

            var cascadeFKs = builder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            
        }

        public DbSet<UserPlayerConnection> UserPlayerConnection { get; set; }
        //Table Definition for Civ5
        //public DbSet<Civ5Players> Civ5Players { get; set; }
        //public DbSet<Civ5Matches> Civ5Matches { get; set; }
        //public DbSet<Civ5Attendants> Civ5Attendants { get; set; }
        //public DbSet<Civ5Regions> Civ5Regions { get; set; }

        //Table Definition for CivBE
        //public DbSet<CivBEPlayers> CivBEPlayers { get; set; }

        //Table Definition for Civ6
        public DbSet<ActorBase> Civ6ActorBases { get; set; }
        public DbSet<Civilization> Civ6Civilizations { get; set; }
        public DbSet<Player> Civ6Players { get; set; }
        public DbSet<ActorStatus> Civ6ActorStatuses { get; set; }
        public DbSet<ChangeInActorStatus> Civ6ChangesInActorStatus { get; set; }
        public DbSet<ActorCurrentStatus> Civ6ActorCurrentStatuses { get; set; }
        public DbSet<Match> Civ6Matches { get; set; }
        public DbSet<Attendance> Civ6Attendances { get; set; }
        public DbSet<Region> Civ6Regions { get; set; }
        public DbSet<AchievementBase> Civ6AchievementBases { get; set; }
        public DbSet<Medal> Civ6Medals { get; set; }
        public DbSet<Flag> Civ6Flags { get; set; }
        public DbSet<FlagPosessions> Civ6FlagPosessions { get; set; }

        public DbSet<ExecuteMaster> ExecuteMaster { get; set; }
        public DbSet<Models.Civ6.WaitingRoom.Board> Civ6WaitingRoomBoards { get; set; }
        public DbSet<Models.Civ6.WaitingRoom.Post> Civ6WaitingRoomPosts { get; set; }
        public DbSet<Models.Civ6.WaitingRoom.User> Civ6WaitingRoomUsers { get; set; }
    }
}
