using MutantSuplements.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MutantSuplements.API.DBContext
{
    public class MutantSuplementsContext : DbContext
    {
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        //public DbSet<User> Users { get; set; }

        public MutantSuplementsContext(DbContextOptions<MutantSuplementsContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)             // Un producto tiene una categoría
            .WithMany(c => c.Products)           // Una categoría tiene muchos productos
            .HasForeignKey(p => p.CategoryId);

            var productCategories = new ProductCategory[3]
            {
                new ProductCategory()
                {
                    Id = 1,
                    Name = "Muebles de Madera",
                    Description = "Muebles grandes de madera."
                },
                new ProductCategory()
                {
                    Id = 2,
                    Name = "Muebles medianos",
                    Description = "Muebles medianos en oferta"
                },
                new ProductCategory()
                {
                    Id = 3,
                    Name = "Muebles pequeños",
                    Description = "Muebles pequeños para decoracion"
                },
            };
            modelBuilder.Entity<ProductCategory>().HasData(productCategories);

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Mesa",
                    Description = "La mesa de madera.",
                    Price = 420,
                    CategoryId = productCategories[0].Id
                },
                new Product()
                {
                    Id = 2,
                    Name = "Silla",
                    Description = "La silla de madera.",
                    Price = 320,
                    CategoryId = productCategories[0].Id
                },
                new Product()
                {
                    Id = 3,
                    Name = "Sillon",
                    Description = "El sillon comodo y lujoso.",
                    Price = 520,
                    CategoryId = productCategories[1].Id
                },
                new Product()
                {
                    Id = 4,
                    Name = "Ropero",
                    Description = "El ropero mas grande.",
                    Price = 520,
                    CategoryId = productCategories[1].Id
                },
                new Product()
                {
                    Id = 5,
                    Name = "Mesita pequeña",
                    Description = "Mesita pequeña con 3 patas.",
                    Price = 520,
                    CategoryId = productCategories[2].Id
                },
                new Product()
                {
                    Id = 6,
                    Name = "Cajonera",
                    Description = "La cajonera con espacios divididos.",
                    Price = 520,
                    CategoryId = productCategories[2].Id
                });

            //-----------------------------------------------------

            //var orders = new Order[3]
            //{
            //    new Order()
            //    {
            //        Id = 1,
            //        OrderDate = DateTime.UtcNow,
            //        UserId = 34
            //    },
            //    new Order()
            //    {
            //        Id = 2,
            //        OrderDate = DateTime.UtcNow,
            //        UserId = 45
            //    },
            //    new Order()
            //    {
            //        Id = 3,
            //        OrderDate = DateTime.UtcNow,
            //        UserId = 23
            //    },
            //};
            //modelBuilder.Entity<Order>().HasData(orders);

            //modelBuilder.Entity<OrderDetail>().HasData(
            //    new OrderDetail()
            //    {
            //        Id = 1,
            //        OrderId = orders[0].Id,
            //        ProductId = 1,
            //        Quantity = 3,
            //        Price = 1260
            //    },
            //    new OrderDetail()
            //    {
            //        Id = 2,
            //        OrderId = orders[0].Id,
            //        ProductId = 3,
            //        Quantity = 5,
            //        Price = 2600
            //    },
            //    new OrderDetail()
            //    {
            //        Id = 3,
            //        OrderId = orders[1].Id,
            //        ProductId = 2,
            //        Quantity = 2,
            //        Price = 640
            //    },
            //    new OrderDetail()
            //    {
            //        Id = 4,
            //        OrderId = orders[1].Id,
            //        ProductId = 4,
            //        Quantity = 1,
            //        Price = 520
            //    },
            //    new OrderDetail()
            //    {
            //        Id = 5,
            //        OrderId = orders[2].Id,
            //        ProductId = 2,
            //        Quantity = 3,
            //        Price = 960
            //    },
            //    new OrderDetail()
            //    {
            //        Id = 6,
            //        OrderId = orders[2].Id,
            //        ProductId = 4,
            //        Quantity = 4,
            //        Price = 2080
            //    });

            //var users = new User[2]
            //{
            //    new User("Elias")
            //    {
            //        Id = 1,
            //        //Username = "Elias",
            //        Password = "has3vgHdhDfbsSajsd",
            //        Email = "usuario1@gmail.com",
            //        Role = "Admin"
            //    },
            //    new User("Mauri")
            //    {
            //        Id = 2,
            //        //Username = "Mauri",
            //        Password = "sdDEasdegR12FgDsnasfdA",
            //        Email = "usuario1@gmail.com",
            //        Role = "Admin"
            //    }
            //    //new User()
            //    //{
            //    //    Id = 3,
            //    //    Username = "nadiemas",
            //    //    Password = "sdDEasdegR12FgDsnasfdA",
            //    //    Email = "nadie@gmail.com",
            //    //    Role = "nadie"
            //    //},
            //};
            //modelBuilder.Entity<User>().HasData(users);

            base.OnModelCreating(modelBuilder);
        }
    }
}