using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using User_Order_API_Core.Enum;

namespace User_Order_API_Core.Models
{
    public partial class SmallAdminProjContext : DbContext
    {
        public SmallAdminProjContext()
        {
        }

        public SmallAdminProjContext(DbContextOptions<SmallAdminProjContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ShippingOrder> ShippingOrder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SmallAdminProj;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.Pid);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("PID")
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<ShippingOrder>(entity =>
            {
                entity.ToTable("Shipping Order");

                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ShippingOrder)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shipping Order_Order");
            });

            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = "PD001", Name = "Product1", Price = 1300m },
                new Product() { Id = "PD002", Name = "Product2", Price = 2000000m },
                new Product() { Id = "PD003", Name = "Product3", Price = 45000m },
                new Product() { Id = "PD004", Name = "Product4", Price = 200m }
                );

            modelBuilder.Entity<Order>().HasData(
                    new Order() { Id = "A20202026001", Pid = "PD001", Price = 100m, Cost = 90m, Status = (short)OrderStatus.Payment_completed },
                    new Order() { Id = "A20202023001", Pid = "PD002", Price = 120m, Cost = 100m, Status = (short)OrderStatus.Payment_completed },
                    new Order() { Id = "A20202026002", Pid = "PD003", Price = 200m, Cost = 150m, Status = (short)OrderStatus.Payment_completed },
                    new Order() { Id = "A20202024003", Pid = "PD004", Price = 150m, Cost = 120m, Status = (short)OrderStatus.Payment_completed }
                );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
