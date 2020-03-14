using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;

namespace Model
{
    public class ModelDBContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database = ShopDb; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Staff
            modelBuilder.Entity<Staff>()
                .ToTable("staffs");

            modelBuilder.Entity<Staff>()
                .Property(st => st.Id)
                .HasColumnName("staff_id");

            modelBuilder.Entity<Staff>()
                .Property(st => st.FirstName)
                .HasColumnName("first_name");

            modelBuilder.Entity<Staff>()
                .Property(st => st.LastName)
                .HasColumnName("last_name");

            modelBuilder.Entity<Staff>()
                .Property(st => st.Email)
                .HasColumnName("email");

            modelBuilder.Entity<Staff>()
                .Property(st => st.Phone)
                .HasColumnName("phone");

            modelBuilder.Entity<Staff>()
                .Property(st => st.Active)
                .HasColumnName("active");

            modelBuilder.Entity<Staff>()
                .Property(st => st.StoreId)
                .HasColumnName("store_id");

            modelBuilder.Entity<Staff>()
                .Property(st => st.ManagerId)
                .HasColumnName("manager_id");

            modelBuilder.Entity<Staff>()
                .HasData(new Staff 
                { 
                    Id = 1,
                    FirstName = "Elena", 
                    LastName = "Zub",
                    Email = "e.zub",
                    Phone = "02",
                    Active = true, 
                    StoreId = 1
                }
                , new Staff
                {
                    Id = 2,
                    FirstName = "Oleg",
                    LastName = "Reshetilo",
                    Email = "e.reshetilo",
                    Phone = "04",
                    Active = false,
                    StoreId = 2
                });

            //Order
            modelBuilder.Entity<Order>()
                .ToTable("order");

            modelBuilder.Entity<Order>()
                .Property(or => or.Id)
                .HasColumnName("order_id");

            modelBuilder.Entity<Order>()
                .Property(or => or.CustomerId)
                .HasColumnName("customer_id");

            modelBuilder.Entity<Order>()
                .Property(or => or.Status)
                .HasColumnName("order_status");

            modelBuilder.Entity<Order>()
                .Property(or => or.Date)
                .HasColumnName("order_date");

            modelBuilder.Entity<Order>()
                .Property(or => or.RequiredDate)
                .HasColumnName("required_date");

            modelBuilder.Entity<Order>()
                .Property(or => or.ShippedDate)
                .HasColumnName("shipped_date");

            modelBuilder.Entity<Order>()
                .Property(or => or.StoreId)
                .HasColumnName("store_id");

            modelBuilder.Entity<Order>()
                .Property(or => or.StaffId)
                .HasColumnName("staff_id");

            modelBuilder.Entity<Order>()
                .HasOne(or => or.Store)
                .WithMany(st => st.Orders)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasData(new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    Status = "go",
                    StoreId = 1,
                    StaffId = 1
                }
                , new Order
                {
                    Id = 2,
                    CustomerId = 2,
                    Status = "done",
                    StoreId = 2,
                    StaffId = 2
                });

            //OrderItem
            modelBuilder.Entity<OrderItem>()
                .ToTable("order_items");

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.OrderId)
                .HasColumnName("order_id");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.ProductId)
                .HasColumnName("product_id");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Quantity)
                .HasColumnName("quantity");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.ListPrice)
                .HasColumnName("list_price");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Discount)
                .HasColumnName("discount");

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(pr => pr.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<OrderItem>()
                .HasData(new OrderItem
                {
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 5,
                    ListPrice = 20,
                    Discount = 1
                }
                , new OrderItem
                {
                    OrderId = 2,
                    ProductId = 2,
                    Quantity = 10,
                    ListPrice = 30,
                    Discount = 3
                });

            //Store
            modelBuilder.Entity<Store>()
                .ToTable("stores");

            modelBuilder.Entity<Store>()
                .Property(st => st.Id)
                .HasColumnName("store_id");

            modelBuilder.Entity<Store>()
                .Property(st => st.Name)
                .HasColumnName("store_name");

            modelBuilder.Entity<Store>()
                .Property(st => st.Phone)
                .HasColumnName("phone");

            modelBuilder.Entity<Store>()
                .Property(st => st.Email)
                .HasColumnName("email");

            modelBuilder.Entity<Store>()
                .Property(st => st.Street)
                .HasColumnName("street");

            modelBuilder.Entity<Store>()
                .Property(st => st.City)
                .HasColumnName("city");

            modelBuilder.Entity<Store>()
                .Property(st => st.State)
                .HasColumnName("state");

            modelBuilder.Entity<Store>()
                .Property(st => st.ZipCode)
                .HasColumnName("zip_code");

            modelBuilder.Entity<Store>()
                .HasData(new Store
                {
                    Id = 1,
                    Name = "Klass",
                    Phone = "0987654",
                    Email = "klass.com",
                    Street = "23 Seprnya",
                    City = "Kharkiv",
                    State = "UK",
                    ZipCode = "8976",
                }
                , new Store
                {
                    Id = 2,
                    Name = "Rost",
                    Phone = "0578u56767",
                    Email = "rost.com",
                    Street = "23 Seprnya",
                    City = "Kharkiv",
                    State = "UK",
                    ZipCode = "0986",
                });

            //Customer
            modelBuilder.Entity<Customer>()
                .ToTable("customers");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.Id)
                .HasColumnName("customer_id");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.FirstName)
                .HasColumnName("first_name");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.LastName)
                .HasColumnName("last_name");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.Phone)
                .HasColumnName("phone");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.Email)
                .HasColumnName("email");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.Street)
                .HasColumnName("street");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.City)
                .HasColumnName("city");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.State)
                .HasColumnName("state");

            modelBuilder.Entity<Customer>()
                .Property(cus => cus.ZipCode)
                .HasColumnName("zip_code");

            modelBuilder.Entity<Customer>()
                .HasData(new Customer
                {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    Phone = "0987654",
                    Email = "klass.com",
                    Street = "23 Seprnya",
                    City = "Kharkiv",
                    State = "UK",
                    ZipCode = "8976",
                }
                , new Customer
                {
                    Id = 2,
                    FirstName = "Petr",
                    LastName = "Petrov",
                    Phone = "0987654",
                    Email = "klass.com",
                    Street = "23 Seprnya",
                    City = "Kharkiv",
                    State = "UK",
                    ZipCode = "8976",
                });

            //Stocks
            modelBuilder.Entity<Stock>()
               .ToTable("stocks");

            modelBuilder.Entity<Stock>()
                .HasKey(st => new { st.StoreId, st.ProductId });

            modelBuilder.Entity<Stock>()
                .Property(st => st.StoreId)
                .HasColumnName("store_id");

            modelBuilder.Entity<Stock>()
                .Property(st => st.ProductId)
                .HasColumnName("product_id");

            modelBuilder.Entity<Stock>()
                .Property(st => st.Quantity)
                .HasColumnName("quantity");

            modelBuilder.Entity<Stock>()
                .HasOne(stock => stock.Store)
                .WithMany(store => store.Stocks)
                .HasForeignKey(stock => stock.StoreId);

            modelBuilder.Entity<Stock>()
                .HasOne(stock => stock.Product)
                .WithMany(product => product.Stocks)
                .HasForeignKey(stock => stock.ProductId);

            modelBuilder.Entity<Stock>()
                .HasData(new Stock
                {
                    StoreId = 1,
                    ProductId =1,
                    Quantity = 4
                }
                , new Stock
                {
                    StoreId = 2,
                    ProductId = 2,
                    Quantity = 4
                });

            //Product
            modelBuilder.Entity<Product>()
                .ToTable("products");

            modelBuilder.Entity<Product>()
                .Property(pr => pr.Id)
                .HasColumnName("product_id");

            modelBuilder.Entity<Product>()
                .Property(pr => pr.Name)
                .HasColumnName("product_name");

            modelBuilder.Entity<Product>()
                .Property(pr => pr.BrandId)
                .HasColumnName("brand_id");

            modelBuilder.Entity<Product>()
                .Property(pr => pr.CategoryId)
                .HasColumnName("category_id");

            modelBuilder.Entity<Product>()
                .Property(pr => pr.ModelYear)
                .HasColumnName("model_year");

            modelBuilder.Entity<Product>()
                .Property(pr => pr.ListPrice)
                .HasColumnName("list_price");

            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    Id = 1,
                    Name = "Electrocar",
                    BrandId = 2,
                    CategoryId = 1,
                    ModelYear = 2015,
                    ListPrice = 20
                }
                , new Product
                {
                    Id = 2,
                    Name = "Car",
                    BrandId = 2,
                    CategoryId = 1,
                    ModelYear = 2015,
                    ListPrice = 20
                });

            //Brand
            modelBuilder.Entity<Brand>()
                .ToTable("brands");

            modelBuilder.Entity<Brand>()
                .Property(br => br.Id)
                .HasColumnName("brand_id");

            modelBuilder.Entity<Brand>()
                .Property(br => br.Name)
                .HasColumnName("brand_name");

            modelBuilder.Entity<Brand>()
                .HasData(new Brand
                {
                    Id = 1,
                    Name = "BMW"
                }
                , new Brand
                {
                    Id = 2,
                    Name = "Audi"
                });

            //Category
            modelBuilder.Entity<Category>()
                .ToTable("categories");

            modelBuilder.Entity<Category>()
                .Property(br => br.Id)
                .HasColumnName("category_id");

            modelBuilder.Entity<Category>()
                .Property(br => br.Name)
                .HasColumnName("category_name");

            modelBuilder.Entity<Category>()
                .HasData(new Category
                {
                    Id = 1,
                    Name = "Car"
                }
                , new Category
                {
                    Id = 2,
                    Name = "Bicycle"
                });
        }
    }
}