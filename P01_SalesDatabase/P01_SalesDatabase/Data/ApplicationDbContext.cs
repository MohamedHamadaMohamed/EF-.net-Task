using Microsoft.EntityFrameworkCore;
using P01_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EF;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasKey(e => e.CustomerId);
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .HasColumnType("varchar(100)");
            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .HasColumnType("varchar(80)");
            modelBuilder.Entity<Customer>()
                .Property(e => e.CreaditCardNumber)
                .HasColumnType("varchar(30)");
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Sales)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<Product>()
                .HasKey(e => e.ProductId);
            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Product>()
           .Property(e => e.Quantity)
           .HasColumnType("decimal(10,5)");

            modelBuilder.Entity<Product>()
            .Property(e => e.Description)
            .HasMaxLength(100)
            .IsUnicode(true);


          modelBuilder.Entity<Store>()
           .HasKey(e=>e.StoreId);

            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(true);

            modelBuilder.Entity<Sale>()
                .HasKey(e => e.SaleId);

            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.Product_Id);
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Sales)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.Product_Id);

            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Customer)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.Customer_Id);
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Sales)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<Sale>()
                .HasOne(e => e.Store)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.Store_Id);
            modelBuilder.Entity<Store>()
                .HasMany(e => e.Sales)
                .WithOne(e => e.Store)
                .HasForeignKey(e => e.Store_Id);

            modelBuilder.Entity<Sale>()
                .Property(e => e.Date)
                .HasColumnType("date");



        }
    }
}
