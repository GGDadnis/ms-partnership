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

            Builder.Entity<Address>()
            .HasOne(address => address.Company)
            .WithMany(company => company.Addresses)
            .HasForeignKey(address => address.CompanyId);

            Builder.Entity<Category>();

            Builder.Entity<Company>()
            .HasOne(company => company.Category)
            .WithMany(category => category.Companies)
            .HasForeignKey(company => company.CategoryId);

            Builder.Entity<Login>()
            .HasOne(login => login.Company)
            .WithMany(company => company.Logins)
            .HasForeignKey(login => login.CompanyId);

            Builder.Entity<Promo>()
            .HasOne(promo => promo.Company)
            .WithMany(company => company.Promos)
            .HasForeignKey(promo => promo.CompanyId);

            Builder.Entity<Review>()
            .HasOne(review => review.User)
            .WithMany(user => user.Reviews)
            .HasForeignKey(review => review.UserId);

            Builder.Entity<Review>()
            .HasOne(review => review.Company)
            .WithMany(company => company.Reviews)
            .HasForeignKey(review => review.CompanyId);

            Builder.Entity<User>();

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