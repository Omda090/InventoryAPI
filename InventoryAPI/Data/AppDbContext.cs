using InventoryAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace InventoryAPI.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }


        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // InventoryItem → Category Relationship (Many-to-One)
        //    modelBuilder.Entity<InventoryItem>()
        //        .HasOne(i => i.Category)
        //        .WithMany(c => c.InventoryItems)
        //        .HasForeignKey(i => i.CategoryId)
        //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

        //    // InventoryItem → Supplier Relationship (Many-to-One)
        //    modelBuilder.Entity<InventoryItem>()
        //        .HasOne(i => i.Supplier)
        //        .WithMany(s => s.InventoryItems)
        //        .HasForeignKey(i => i.SupplierId)
        //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete



        //}
    }
}
