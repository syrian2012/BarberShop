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
        public DbSet<Service> Services { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BarberEmployee> BarberEmployees { get; set; }
        public DbSet<BarberService> BarberServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasKey(r => new {r.ReservationId});
            modelBuilder.Entity<Reservation>()
                .HasOne(b => b.Barber)
                .WithMany(r => r.Reservations)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder.Entity<Reservation>()
                .HasOne(c => c.Customer)
                .WithMany(r => r.Reservations)
                .HasForeignKey(b => b.BarberId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<BarberService>()
                .HasKey(bs => new { bs.BarberServiceId });
            modelBuilder.Entity<BarberService>()
                .HasOne(b => b.Barber)
                .WithMany(bs => bs.BarberServices)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder.Entity<BarberService>()
                .HasOne(s => s.Service)
                .WithMany(bs => bs.BarberServices)
                .HasForeignKey(b => b.BarberId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<ReservationService>()
                .HasKey(rs => new { rs.ReservationId,rs.ServiceId});
            modelBuilder.Entity<ReservationService>()
                .HasOne(r => r.Reservation)
                .WithMany(rs => rs.ReservationServices)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder.Entity<ReservationService>()
                .HasOne(s => s.BarberService)
                .WithMany(rs => rs.ReservationServices)
                .HasForeignKey(r => r.ReservationId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<BarberEmployee>()
                .HasKey(be => be.BarberEmpolyeeId);
        }
    }
}
