using Microsoft.EntityFrameworkCore;
using StaffManagementApp.Models;

namespace StaffManagementApp.Data
{
    // The ApplicationDbContext inherits everything from th DbContext class
    // DbContext is Entity Framework built-in class
    public class ApplicationDbContext : DbContext
    {
        // here we'll pass the connection string "DefaultConnection"
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //Db set for the model 
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().HasData(
            new Staff { Id = 1, Name = "Joao", Birthday = new DateTime(2023, 09, 20), Hobbies = "Thriatlon", TeamId = 1, Email = "joao@gmail.com" },
            new Staff { Id = 2, Name = "Maria", Birthday = new DateTime(1990, 5, 15), Hobbies = "Painting", TeamId = 2, Email = "maria@gmail.com" },
            new Staff { Id = 3, Name = "Carlos", Birthday = new DateTime(1985, 3, 10), Hobbies = "Cooking", TeamId = 1, Email = "carlos@gmail.com" },
            new Staff { Id = 4, Name = "Ana", Birthday = new DateTime(1988, 8, 25), Hobbies = "Reading", TeamId = 2, Email = "ana@gmail.com" },
            new Staff { Id = 5, Name = "Luis", Birthday = new DateTime(1995, 7, 12), Hobbies = "Gardening", TeamId = 3, Email = "luis@gmail.com" },
            new Staff { Id = 6, Name = "Sofia", Birthday = new DateTime(1993, 2, 5), Hobbies = "Photography", TeamId = 1, Email = "sofia@gmail.com" },
            new Staff { Id = 7, Name = "Pedro", Birthday = new DateTime(1991, 9, 8), Hobbies = "Swimming", TeamId = 3, Email = "pedro@gmail.com" },
            new Staff { Id = 8, Name = "Marta", Birthday = new DateTime(1987, 4, 20), Hobbies = "Traveling", TeamId = 2, Email = "marta@gmail.com" },
            new Staff { Id = 9, Name = "Rita", Birthday = new DateTime(1998, 1, 30), Hobbies = "Playing Guitar", TeamId = 1, Email = "rita@gmail.com" }
            );
            modelBuilder.Entity<Team>().HasData(
            new Staff { Id = 1, Name = "Team A" },
            new Staff { Id = 2, Name = "Team B" },
            new Staff { Id = 3, Name = "Team C" }
            );
        }
    }
}
