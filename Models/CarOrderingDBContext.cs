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

            modelBuilder.Entity<Cars>().HasData(
                new Cars { CarId = 1, CarName = "Audi", CarPrice = 4343439, CarImgUrl = "Audi.jpg" },
                new Cars { CarId = 2, CarName = "Benz", CarPrice = 3545688, CarImgUrl = "benz.jpeg" },
                new Cars { CarId = 3, CarName = "Jaguar", CarPrice = 5678777, CarImgUrl = "jaguar.jpg" },
                new Cars { CarId = 4, CarName = "Ferrari", CarPrice = 63468327, CarImgUrl = "ferrari.jpg" },
                new Cars { CarId = 5, CarName = "Lamborghini", CarPrice = 976253562, CarImgUrl = "lamborghini.jpg" },
                new Cars { CarId = 6, CarName = "Skoda", CarPrice = 672637373, CarImgUrl = "skoda.jpg" });
        }

        public DbSet<Register> Register { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
