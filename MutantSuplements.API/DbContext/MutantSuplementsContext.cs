using MutantSuplements.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MutantSuplements.API.DBContext
{
    public class MutantSuplementsContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

        public MutantSuplementsContext(DbContextOptions<MutantSuplementsContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            //modelBuilder.Entity<Order>()
            //   .HasOne(o => o.user)
            //   .WithMany(u => u.Orders)
            //   .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Product)
            //    .WithMany()
            //    .HasForeignKey(od => od.ProductId)
            //    .OnDelete(DeleteBehavior.ClientSetNull); //asegura que no se pueda eliminar un producto si hay detalles de pedido relacionados con ese producto

            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Product)
            //    .WithMany()
            //    .HasForeignKey(od => od.ProductId)
            //    .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)             // Un producto tiene una categoría
                .WithMany(c => c.Products)           // Una categoría tiene muchos productos
                .HasForeignKey(p => p.CategoryId);           
        }
    }
}