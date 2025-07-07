using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainApi.Models;

namespace TrainApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Train> Trains => Set<Train>();
        public DbSet<Booking> Bookings => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Train)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TrainId);

            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                Role = "Admin"
            };

            // Hash the password
            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin");

            // Seed admin with hashed password
            modelBuilder.Entity<User>().HasData(adminUser);

            modelBuilder.Entity<Train>().HasData(
                new Train
                {
                    Id = Guid.NewGuid(),
                    Name = "Express 101",
                    Source = "CityA",
                    Destination = "CityB",
                    TotalSeats = 100,
                    AvailableSeats = 100
                }
            );
        }
    }
}

