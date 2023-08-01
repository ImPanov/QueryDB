using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics.Metrics;
using System.Threading;
using System;

namespace Packet.Shared;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        if(Database.CanConnect())
        {
            Database.EnsureDeleted();
        }
        Database.EnsureCreated();        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product[]
        {
            new Product { ProductId= 1, ProductName = "War and Peace", Cost= 500, Count = 10, CategoryId=1, },
            new Product { ProductId= 2, ProductName = "Harry Potter and the Philosopher’s Stone", Cost= 300, Count = 15, CategoryId=1, },
            new Product { ProductId= 3, ProductName = "Levi’s Jeans", Cost= 2000, Count = 5, CategoryId=2, },
            new Product { ProductId= 4, ProductName = "Nike T-shirt", Cost= 1000, Count = 8, CategoryId=2, },
            new Product { ProductId= 5, ProductName = "Lego Star Wars", Cost= 1500, Count = 12, CategoryId=3, },
            new Product { ProductId= 6, ProductName = "Barbie", Cost= 800, Count = 20, CategoryId=3, },
            new Product { ProductId= 7, ProductName = "Pizza", Cost= 400, Count = 50, CategoryId=4, },
            new Product { ProductId= 8, ProductName = "Sushi", Cost= 600, Count = 30, CategoryId=4, },
            new Product { ProductId= 9, ProductName = "iPhone 14", Cost= 50000, Count = 3, CategoryId=5, },
            new Product { ProductId= 10, ProductName="Asus Laptop", Cost= 30000, Count= 7, CategoryId= 5, },
            new Product { ProductId= 11, ProductName="The Master and Margarita", Cost= 400, Count= 13, CategoryId= 1, },
            new Product { ProductId= 12, ProductName="The Hobbit", Cost= 350, Count= 18, CategoryId= 1, },
            new Product { ProductId= 13, ProductName="Zara Coat", Cost= 2500, Count= 6, CategoryId= 2, },
            new Product { ProductId= 14, ProductName="H&M Dress", Cost= 1500, Count= 10, CategoryId= 2, },
            new Product { ProductId= 15, ProductName="Soft Rabbit", Cost= 500, Count= 25, CategoryId= 3, },
            new Product { ProductId= 16, ProductName="Monopoly Board Game", Cost= 1000, Count= 15, },
            new Product { ProductId= 17, ProductName="Burger", Cost= 300, Count= 40, CategoryId=4},
            new Product { ProductId= 18, ProductName="Caesar Salad", Cost= 450, Count= 35, CategoryId= 4, },
            new Product { ProductId= 19, ProductName="AirPods Headphones", Cost= 8000, Count= 5, CategoryId= 5, },
            new Product { ProductId= 20, ProductName="Samsung Tablet", Cost= 20000, Count= 8,CategoryId= 5},
        });
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category { CategoryId = 1, CategoryName = "Books" },
            new Category { CategoryId = 2, CategoryName = "Clothes" },
            new Category { CategoryId = 3, CategoryName = "Toys" },
            new Category { CategoryId = 4, CategoryName = "Food" },
            new Category { CategoryId = 5, CategoryName = "Electronics" },
        });
    }
}
