using Microsoft.EntityFrameworkCore;
using OS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Data.Context
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Type = "Cà phê" },
                new Category { Id = 2, Type = "Trà" },
                new Category { Id = 3, Type = "Sinh tố" },
                new Category { Id = 4, Type = "Nước ép" }
            );
            builder.Entity<Product>().HasData(
               new Product { Id = 1, Image = "images/1.jpg", Name = "Cà phê sữa", Price = 35000, CategoryId = 1 },
               new Product { Id = 2, Image = "images/2.jpg", Name = "Cà phê Americano", Price = 50000, CategoryId = 1 },
               new Product { Id = 3, Image = "images/3.jpg", Name = "Cappuchino", Price = 50000, CategoryId = 1 },
               new Product { Id = 4, Image = "images/4.jpg", Name = "Espresso", Price = 55000, CategoryId = 1 },
               new Product { Id = 5, Image = "images/5.jpg", Name = "Latte", Price = 50000, CategoryId = 1 },
               new Product { Id = 6, Image = "images/6.jpg", Name = "Trà hoa cúc", Price = 40000, CategoryId = 2 },
               new Product { Id = 7, Image = "images/7.jpg", Name = "Trà Earl Grey", Price = 40000, CategoryId = 2 },
               new Product { Id = 8, Image = "images/8.jpg", Name = "Trà xanh bạc hà", Price = 40000, CategoryId = 2 },
               new Product { Id = 9, Image = "images/9.jpg", Name = "Trà đen", Price = 40000, CategoryId = 2 },
               new Product { Id = 10, Image = "images/10.jpg", Name = "Trà hoa hồng", Price = 40000, CategoryId = 2 },
               new Product { Id = 11, Image = "images/11.jpg", Name = "Sinh tố dâu", Price = 35000, CategoryId = 3 },
               new Product { Id = 12, Image = "images/12.jpg", Name = "Sinh tố bơ", Price = 35000, CategoryId = 3 },
               new Product { Id = 13, Image = "images/13.jpg", Name = "Sinh tố chuối", Price = 35000, CategoryId = 3 },
               new Product { Id = 14, Image = "images/14.jpg", Name = "Sinh tố dưa hấu", Price = 35000, CategoryId = 3 },
               new Product { Id = 15, Image = "images/15.jpg", Name = "Sinh tố xoài", Price = 35000, CategoryId = 3 },
               new Product { Id = 16, Image = "images/16.jpg", Name = "Nước ép dâu ", Price = 40000, CategoryId = 4 },
               new Product { Id = 17, Image = "images/17.jpg", Name = "Nước ép táo", Price = 40000, CategoryId = 4 },
               new Product { Id = 18, Image = "images/18.jpg", Name = "Nước ép bưởi", Price = 40000, CategoryId = 4 },
               new Product { Id = 19, Image = "images/19.jpg", Name = "Nước ép nho", Price = 40000, CategoryId = 4 },
               new Product { Id = 20, Image = "images/20.jpg", Name = "Nước ép lựu", Price = 40000, CategoryId = 4 }
           );
            builder.Entity<Customer>().HasData(
                new Customer { Id = 1, Email="trunghuy0501@gmail.com",Name="Lê Trung Huy",PhoneNumber="0903796984" },
                new Customer { Id = 2, Email = "ngothithuytien1603@gmail.com", Name = "Ngô Thị Thủy Tiên", PhoneNumber = "0383860994" },
                new Customer { Id = 3, Email = "myquynn1703@gmail.com", Name = "Lê Mỹ Quỳnh", PhoneNumber = "0234567891" },
                new Customer { Id = 4, Email = "nhathanh@gmail.com", Name = "Tiêu Nhã Thanh", PhoneNumber = "0345678912" },
                new Customer { Id = 5, Email = "quyntram@gmail.com", Name = "Vũ Ngọc Quỳnh Trâm", PhoneNumber = "0456789123" }
            );
        }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
