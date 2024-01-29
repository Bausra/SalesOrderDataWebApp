using Microsoft.EntityFrameworkCore;
using SalesOrderDataWebApp.Shared.Models;

namespace SalesOrderDataWebApp.Server.DB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Element> Elements { get; set; }
        public DbSet<Order> Orders { get; set; }    
        public DbSet<Window> Windows { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, BuyerName = "New York Building 1", State = "NY" },
                new Order { Id = 2, BuyerName = "California Hotel AJK", State = "CA" }
            );

            modelBuilder.Entity<Window>().HasData(
                new Window { Id = 1, Quantity = 4, WindowName = "A51", OrderId = 1 },
                new Window { Id = 2, Quantity = 2, WindowName = "C Zone 5", OrderId = 1 },
                new Window { Id = 3, Quantity = 3, WindowName = "GLB", OrderId = 2 },
                new Window { Id = 4, Quantity = 10, WindowName = "OHF", OrderId = 2 }
            );

            modelBuilder.Entity<Element>().HasData(
                new Element { Id = 1, ElementNo = 1, Width = 1200, Height = 1850, ElementType = "Doors", WindowId = 1},
                new Element { Id = 2, ElementNo = 2, Width = 800, Height = 1850, ElementType = "Window", WindowId = 1 },
                new Element { Id = 3, ElementNo = 3, Width = 700, Height = 1850, ElementType = "Window", WindowId = 1 },
                new Element { Id = 4, ElementNo = 1, Width = 1500, Height = 2000, ElementType = "Window", WindowId = 2 },
                new Element { Id = 5, ElementNo = 1, Width = 1400, Height = 2200, ElementType = "Doors", WindowId = 3 },
                new Element { Id = 6, ElementNo = 2, Width = 600, Height = 2200, ElementType = "Window", WindowId = 3 },
                new Element { Id = 7, ElementNo = 1, Width = 1500, Height = 2000, ElementType = "Window", WindowId = 4 },
                new Element { Id = 8, ElementNo = 1, Width = 1500, Height = 2000, ElementType = "Window", WindowId = 4 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
