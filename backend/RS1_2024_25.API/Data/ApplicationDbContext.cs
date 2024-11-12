using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;


namespace RS1_2024_25.API.Data
{
    public class ApplicationDbContext(
        DbContextOptions options) : DbContext(options)

    {
        public DbSet<MyAuthenticationToken> MyAuthenticationTokens { get; set; }


        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }




        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<TeamRole> TeamRoles { get; set; }



        public DbSet<Coin> Coins { get; set; }
        public DbSet<UserCoin> UserCoins { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<UserTournament> UserTournaments { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }


        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }









        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
            modelBuilder.Entity<Payment>()
                 .Property(p => p.Amount)
                 .HasColumnType("decimal(18, 2)");


            //one to many
            modelBuilder.Entity<UserTeam>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.Teams)
                .HasForeignKey(ut => ut.UserId);
            modelBuilder.Entity<UserTeam>()
               .HasIndex(ut => ut.UserId)
               .IsUnique();

            //one to one
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            //one to many
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAchievements)
                .HasForeignKey(ua => ua.UserId);


            //one to many
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.Achievement)
                .WithMany(a => a.UserAchievements)
                .HasForeignKey(ua => ua.AchievementId);

            //one to many
            modelBuilder.Entity<UserLevel>()
                .HasOne(ua => ua.User)
                .WithMany(a => a.Levels)
                .HasForeignKey(ua => ua.UserId);

            //one to many
            modelBuilder.Entity<UserTournament>()
                .HasOne(ua => ua.User)
                .WithMany(a => a.Tournaments)
                .HasForeignKey(ua => ua.UserId);

            //one to many
            modelBuilder.Entity<UserCoin>()
                .HasOne(ua => ua.User)
                .WithMany(a => a.UserCoins)
                .HasForeignKey(ua => ua.UserId);


            // opcija kod nasljeđivanja
            // modelBuilder.Entity<NekaBaznaKlasa>().UseTpcMappingStrategy();
        }
    }
}
