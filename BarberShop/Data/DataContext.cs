using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BarberEmployee> BarberEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasKey(r => new {r.ReservationId});
            modelBuilder.Entity<Reservation>()
                .HasOne(b => b.Barber)
                .WithMany(r => r.Reservations)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<BarberService>()
                .HasKey(bs => new { bs.BarberId, bs.ServiceId });
            modelBuilder.Entity<BarberService>()
                .HasOne(b => b.Barber)
                .WithMany(bs => bs.BarberServices)
                .HasForeignKey(s => s.ServiceId);
        }
    }
}
