using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOrderingWebApi.Models
{
    public class CarOrderingDBContext : DbContext
    {
        public CarOrderingDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>().HasData(
        new Register
        {
            Id = 1,
            FirstName = "Admin",
            LastName = "Admin"
        });

            modelBuilder.Entity<Login>().HasData(
                    new 
                    {
                        Id = 1,
                        Username = "admin@neudesic.com",
                        Password = "admin",
                        RegisterId = 1
                    });
        }

        public DbSet<Register> Register { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
