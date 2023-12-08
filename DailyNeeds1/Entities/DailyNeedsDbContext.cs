using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DailyNeeds1.Entities
{
    public class DailyNeedsDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Role> roles { get; set; }

        public DbSet<User> users { get; set; }

        //public DbSet<Registration> registrations { get; set; }

        public DbSet<Login> logins { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<Cart> cartss { get; set; }

        public DbSet<Offer> offers { get; set; }

        IConfiguration config = null;
        public DailyNeedsDbContext(IConfiguration cfg)
        {
            config = cfg;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config["ConnString"]);
            //base.OnConfiguring(optionsBuilder);
        }
       
        }
    }
