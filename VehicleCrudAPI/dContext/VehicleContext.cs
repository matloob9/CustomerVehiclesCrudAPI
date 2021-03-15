using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using VehicleCrudAPI.Models;

#nullable disable

namespace VehicleCrudAPI.dContext
{
    public partial class VehicleContext : DbContext
    {
        //public VehicleContext()
        //{
        //}

        public VehicleContext(DbContextOptions<VehicleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Vehicle;Trusted_Connection=False;User ID=sa;Password=reallyStrongPwd123");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.Vin, "Vehicle_VIN")
                    .IsUnique();

                entity.Property(e => e.CustomerFk).HasColumnName("CustomerFK");

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RegNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("VIN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
