﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OS.Data.Context;

namespace OS.Data.Migrations
{
    [DbContext(typeof(OnlineShopDbContext))]
    partial class OnlineShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OS.Domain.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("OS.Domain.Models.CartProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("OS.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Cà phê"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Trà"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Sinh tố"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Nước ép"
                        });
                });

            modelBuilder.Entity("OS.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "trunghuy0501@gmail.com",
                            Name = "Lê Trung Huy",
                            PhoneNumber = "0903796984"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ngothithuytien1603@gmail.com",
                            Name = "Ngô Thị Thủy Tiên",
                            PhoneNumber = "0383860994"
                        },
                        new
                        {
                            Id = 3,
                            Email = "myquynn1703@gmail.com",
                            Name = "Lê Mỹ Quỳnh",
                            PhoneNumber = "0234567891"
                        },
                        new
                        {
                            Id = 4,
                            Email = "nhathanh@gmail.com",
                            Name = "Tiêu Nhã Thanh",
                            PhoneNumber = "0345678912"
                        },
                        new
                        {
                            Id = 5,
                            Email = "quyntram@gmail.com",
                            Name = "Vũ Ngọc Quỳnh Trâm",
                            PhoneNumber = "0456789123"
                        });
                });

            modelBuilder.Entity("OS.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("OS.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Image = "images/1.jpg",
                            Name = "Cà phê sữa",
                            Price = 35000
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Image = "images/2.jpg",
                            Name = "Cà phê Americano",
                            Price = 50000
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Image = "images/3.jpg",
                            Name = "Cappuchino",
                            Price = 50000
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Image = "images/4.jpg",
                            Name = "Espresso",
                            Price = 55000
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            Image = "images/5.jpg",
                            Name = "Latte",
                            Price = 50000
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Image = "images/6.jpg",
                            Name = "Trà hoa cúc",
                            Price = 40000
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Image = "images/7.jpg",
                            Name = "Trà Earl Grey",
                            Price = 40000
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Image = "images/8.jpg",
                            Name = "Trà xanh bạc hà",
                            Price = 40000
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Image = "images/9.jpg",
                            Name = "Trà đen",
                            Price = 40000
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 2,
                            Image = "images/10.jpg",
                            Name = "Trà hoa hồng",
                            Price = 40000
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Image = "images/11.jpg",
                            Name = "Sinh tố dâu",
                            Price = 35000
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            Image = "images/12.jpg",
                            Name = "Sinh tố bơ",
                            Price = 35000
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 3,
                            Image = "images/13.jpg",
                            Name = "Sinh tố chuối",
                            Price = 35000
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 3,
                            Image = "images/14.jpg",
                            Name = "Sinh tố dưa hấu",
                            Price = 35000
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 3,
                            Image = "images/15.jpg",
                            Name = "Sinh tố xoài",
                            Price = 35000
                        },
                        new
                        {
                            Id = 16,
                            CategoryId = 4,
                            Image = "images/16.jpg",
                            Name = "Nước ép dâu ",
                            Price = 40000
                        },
                        new
                        {
                            Id = 17,
                            CategoryId = 4,
                            Image = "images/17.jpg",
                            Name = "Nước ép táo",
                            Price = 40000
                        },
                        new
                        {
                            Id = 18,
                            CategoryId = 4,
                            Image = "images/18.jpg",
                            Name = "Nước ép bưởi",
                            Price = 40000
                        },
                        new
                        {
                            Id = 19,
                            CategoryId = 4,
                            Image = "images/19.jpg",
                            Name = "Nước ép nho",
                            Price = 40000
                        },
                        new
                        {
                            Id = 20,
                            CategoryId = 4,
                            Image = "images/20.jpg",
                            Name = "Nước ép lựu",
                            Price = 40000
                        });
                });

            modelBuilder.Entity("OS.Domain.Models.Bill", b =>
                {
                    b.HasOne("OS.Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("OS.Domain.Models.Employee", "Employee")
                        .WithMany("Bills")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("OS.Domain.Models.CartProduct", b =>
                {
                    b.HasOne("OS.Domain.Models.Bill", null)
                        .WithMany("CartProducts")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OS.Domain.Models.Customer", null)
                        .WithMany("CartProducts")
                        .HasForeignKey("CustomerId");

                    b.HasOne("OS.Domain.Models.Product", "Product")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OS.Domain.Models.Category", b =>
                {
                    b.HasOne("OS.Domain.Models.Employee", "Employee")
                        .WithMany("Categories")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("OS.Domain.Models.Product", b =>
                {
                    b.HasOne("OS.Domain.Models.Bill", null)
                        .WithMany("Products")
                        .HasForeignKey("BillId");

                    b.HasOne("OS.Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OS.Domain.Models.Bill", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OS.Domain.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OS.Domain.Models.Customer", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("OS.Domain.Models.Employee", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("OS.Domain.Models.Product", b =>
                {
                    b.Navigation("CartProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
