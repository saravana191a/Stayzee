using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StayZee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayZee.Infrastucture.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<HomeOwner> HomeOwners { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeApporovalStatus> HomeApporavalStatuses { get; set; }
        public DbSet<HomeDocument> HomeDocuments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<KYC> KYCs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OTP> OTPs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Home)
                .WithMany(h => h.Bookings)
                .HasForeignKey(b => b.HomeId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.BookingStatus)
                .WithMany(bs => bs.Bookings)
                .HasForeignKey(b => b.BookingStatusId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.PaymentStatus)
                .WithMany(ps => ps.Bookings)
                .HasForeignKey(b => b.PaymentStatusId);

            modelBuilder.Entity<KYC>()
                .HasOne(k => k.Customer)
                .WithMany(c => c.KYCUploads)
                .HasForeignKey(k => k.CustomerId);

            modelBuilder.Entity<HomeDocument>()
                .HasOne(d => d.home)
                .WithMany(h => h.Documents)
                .HasForeignKey(d => d.HomeId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingId);

            // Decimal precision fix
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Home>()
                .Property(h => h.RatePerDay)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalPrice)
                .HasPrecision(18, 2);

            // Relationship fix
            modelBuilder.Entity<Home>()
                .HasOne(h => h.HomeApprovalStatus)
                .WithMany(s => s.Homes)
                .HasForeignKey(h => h.HomeApprovalStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Your_Connection_String_Here",
                    b => b.MigrationsAssembly("StayZee.Infrastucture")
                );
            }
        }
    }
}