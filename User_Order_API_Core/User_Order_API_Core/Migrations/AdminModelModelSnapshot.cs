﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using User_Order_API_Core.Models;

namespace User_Order_API_Core.Migrations
{
    [DbContext(typeof(AdminModel))]
    partial class AdminModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("User_Order_API_Core.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Pid")
                        .IsRequired()
                        .HasColumnName("PID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Pid");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            Id = "A20202026001",
                            Cost = 90m,
                            Pid = "PD001",
                            Price = 100m,
                            Status = (short)0
                        },
                        new
                        {
                            Id = "A20202023001",
                            Cost = 100m,
                            Pid = "PD002",
                            Price = 120m,
                            Status = (short)0
                        },
                        new
                        {
                            Id = "A20202026002",
                            Cost = 150m,
                            Pid = "PD003",
                            Price = 200m,
                            Status = (short)0
                        },
                        new
                        {
                            Id = "A20202024003",
                            Cost = 120m,
                            Pid = "PD004",
                            Price = 150m,
                            Status = (short)0
                        });
                });

            modelBuilder.Entity("User_Order_API_Core.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = "PD001",
                            Name = "Product1",
                            Price = 1300m
                        },
                        new
                        {
                            Id = "PD002",
                            Name = "Product2",
                            Price = 2000000m
                        },
                        new
                        {
                            Id = "PD003",
                            Name = "Product3",
                            Price = 45000m
                        },
                        new
                        {
                            Id = "PD004",
                            Name = "Product4",
                            Price = 200m
                        });
                });

            modelBuilder.Entity("User_Order_API_Core.Models.ShippingOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnName("OrderID")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Shipping Order");
                });

            modelBuilder.Entity("User_Order_API_Core.Models.Order", b =>
                {
                    b.HasOne("User_Order_API_Core.Models.Product", "P")
                        .WithMany("Order")
                        .HasForeignKey("Pid")
                        .HasConstraintName("FK_Order_Product")
                        .IsRequired();
                });

            modelBuilder.Entity("User_Order_API_Core.Models.ShippingOrder", b =>
                {
                    b.HasOne("User_Order_API_Core.Models.Order", "Order")
                        .WithMany("ShippingOrder")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_Shipping Order_Order")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
