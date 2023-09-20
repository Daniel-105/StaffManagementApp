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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().HasData(
                new Staff { Id = 1, Name = "Joao", Birthday = new DateTime(2023, 09, 20), Hobbies = "Thriatlon", Team = "A", Email = "joao@gmail.com" },
                new Staff { Id = 2, Name = "Maria", Birthday = new DateTime(1990, 5, 15), Hobbies = "Painting", Team = "B", Email = "maria@gmail.com" },
                new Staff { Id = 3, Name = "Carlos", Birthday = new DateTime(1985, 3, 10), Hobbies = "Cooking", Team = "A", Email = "carlos@gmail.com" },
                new Staff { Id = 4, Name = "Ana", Birthday = new DateTime(1988, 8, 25), Hobbies = "Reading", Team = "B", Email = "ana@gmail.com" },
                new Staff { Id = 5, Name = "Luis", Birthday = new DateTime(1995, 7, 12), Hobbies = "Gardening", Team = "C", Email = "luis@gmail.com" },
                new Staff { Id = 6, Name = "Sofia", Birthday = new DateTime(1993, 2, 5), Hobbies = "Photography", Team = "A", Email = "sofia@gmail.com" },
                new Staff { Id = 7, Name = "Pedro", Birthday = new DateTime(1991, 9, 8), Hobbies = "Swimming", Team = "C", Email = "pedro@gmail.com" },
                new Staff { Id = 8, Name = "Marta", Birthday = new DateTime(1987, 4, 20), Hobbies = "Traveling", Team = "B", Email = "marta@gmail.com" },
                new Staff { Id = 9, Name = "Rita", Birthday = new DateTime(1998, 1, 30), Hobbies = "Playing Guitar", Team = "A", Email = "rita@gmail.com" });
        }
    }
}
