using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CustomerVehiclesCrudAPI.Models
{
    public partial class CustomerVehiclesContext : DbContext
    {
        /*public CustomerVehiclesContext()
        {
        }*/

        public CustomerVehiclesContext(DbContextOptions<CustomerVehiclesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=CustomerVehicles;Trusted_Connection=False;User ID=sa;Password=reallyStrongPwd123");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.Vin, "Vehicle_VIN")
                    .IsUnique();

                entity.Property(e => e.CustomerFk).HasColumnName("CustomerFK");

                entity.Property(e => e.RegNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.CustomerFkNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CustomerFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vehicle__Custome__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
