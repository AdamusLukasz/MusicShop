using Microsoft.EntityFrameworkCore;
using MusicShop.Models;

namespace MusicShop.Data
{
    public class MusicShopContext : DbContext
    {
        private string _connectionString =
           "Server=(localdb)\\MSSQLLocalDB;Database=MusicShopDb;Trusted_Connection=True;";
        public MusicShopContext()
        {

        }
        public MusicShopContext(DbContextOptions<MusicShopContext> options) : base(options)
        {

        }
        public DbSet<Album>? Albums { get; set; }
        public DbSet<Artist>? Artists { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().Property(a => a.Price).HasColumnType("decimal(4,2)");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
