using Microsoft.EntityFrameworkCore;
using ms_partnership.Models.Entities;

namespace ms_partnership.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Promo> Promos { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            Builder.Entity<User>();
            Builder.Entity<Company>();
            Builder.Entity<Review>();
            Builder.Entity<Promo>();
        }
    }
}