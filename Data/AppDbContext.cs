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
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            Builder.Entity<User>();
            Builder.Entity<Company>();
            Builder.Entity<Review>();
            Builder.Entity<Promo>();
            Builder.Entity<Category>();
            Builder.Entity<Address>();            
            Builder.Entity<Login>();
            // .HasKey(login => login.Id)
            // .HasRequired(login => login.AcessType)
            // .WithRequiredDependent(userRoles => userRoles.);

            Builder.Entity<Promo>()
            .Property<DateTime>("StartDate")
            .HasColumnType("date")
            .HasColumnName("start_date");

            Builder.Entity<Promo>()
            .Property<DateTime>("EndDate")
            .HasColumnType("date")
            .HasColumnName("end_date");

        }
    }
}