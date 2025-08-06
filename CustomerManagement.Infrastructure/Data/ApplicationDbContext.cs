using CustomerManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for Customers table
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Customer entity
            modelBuilder.Entity<Customer>(entity =>
            {
                // Map to the CUSTOMER table (no schema prefix needed)
                entity.ToTable("CUSTOMER");

                // Primary key
                entity.HasKey(e => e.Id);

                // Configure ID to use Oracle sequence
                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .HasDefaultValueSql("CUSTOMER_SEQ.NEXTVAL");

                // Configure other properties
                entity.Property(e => e.Name)
                      .HasColumnName("NAME")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasColumnName("EMAIL")
                      .HasMaxLength(255)
                      .IsRequired();

                entity.Property(e => e.PhoneNumber)
                      .HasColumnName("PHONE")
                      .HasMaxLength(20);
            });
        }
    }
}