using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace booking_cars.Models
{
    public partial class Simulation_dbContext : DbContext
    {
        //public Simulation_dbContext()
        //{
        //}

        public Simulation_dbContext(DbContextOptions<Simulation_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarsInfo> CarsInfo { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Owned> Owned { get; set; }
        public virtual DbSet<Userinfo> Userinfo { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-6CE6ROD6;Database=Simulation_db;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarsInfo>(entity =>
            {
                entity.ToTable("cars_info");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CName)
                    .HasColumnName("C_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Origin).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__customer__0AD16557D42D8F6E");

                entity.ToTable("customer");

                entity.Property(e => e.CusId)
                    .HasColumnName("Cus_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CusAddress)
                    .HasColumnName("Cus_address")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CusDob)
                    .HasColumnName("Cus_DOB")
                    .HasColumnType("date");

                entity.Property(e => e.CusEmail)
                    .HasColumnName("Cus_email")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CusGender)
                    .HasColumnName("Cus_gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CusName)
                    .HasColumnName("Cus_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CusPassword)
                    .HasColumnName("Cus_password")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CusPhone)
                    .HasColumnName("Cus_phone")
                    .HasColumnType("decimal(10, 0)");
            });

            modelBuilder.Entity<Owned>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("owned");

                entity.Property(e => e.CarId)
                    .HasColumnName("Car_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CusId)
                    .HasColumnName("Cus_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Installment)
                    .HasColumnName("installment")
                    .HasColumnType("decimal(12, 2)");

                entity.Property(e => e.NoOfInstallments).HasColumnName("No_of_installments");

                entity.Property(e => e.Payment)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__owned__Car_ID__4316F928");

                entity.HasOne(d => d.Cus)
                    .WithMany()
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK__owned__Cus_ID__440B1D61");
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__userinfo__F3DBC57387F3B9E8");

                entity.ToTable("userinfo");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
