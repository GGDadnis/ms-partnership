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

            // Builder.Entity<Promo>()
            // .Property<DateTime>("StartDate")
            // .HasColumnType("date")
            // .HasColumnName("start_date");

            // Builder.Entity<Promo>()
            // .Property<DateTime>("EndDate")
            // .HasColumnType("date")
            // .HasColumnName("end_date");

            //https://guidgenerator.com/online-guid-generator.aspx
            //https://www.4devs.com.br
            Builder.Entity<Category>().HasData(
                new Category { Id = new Guid("f88de2f7-b3a2-4675-a364-0989de28b16c"), Name = "Beauty"},
                new Category { Id = new Guid("32885749-4cc2-4445-86f5-c2b310cc5c9f"), Name = "Commerce"},
                new Category { Id = new Guid("47367ee8-86ea-40d2-a672-b6acd1f8e2ad"), Name = "Educational"},
                new Category { Id = new Guid("ccc12f58-e67f-4922-9070-c85c02d2243c"), Name = "Food"},
                new Category { Id = new Guid("c2e4c432-4e32-4bd3-a974-bd483c68c3cd"), Name = "Gym & Sports"},
                new Category { Id = new Guid("4e4cb863-9645-407b-8b3f-460c6ae9a163"), Name = "Health"},
                new Category { Id = new Guid("841d7bfb-b080-4871-9774-6df240acaa06"), Name = "Legal"},
                new Category { Id = new Guid("9e6e6cbb-0a0f-47b0-9410-8b9af03f03f3"), Name = "Others"});

            Builder.Entity<Company>().HasData(   
                new Company { Id = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"), Name = "ProBmx", Cnpj = "87.374.287/0001-06", LogoImg = "", TotalGrade = 100, CategoryId = new Guid("9e6e6cbb-0a0f-47b0-9410-8b9af03f03f3")},
                new Company { Id = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"), Name = "Quality Quidditch Supplies", Cnpj = "82.509.987/0001-39", LogoImg = "", TotalGrade = 70, CategoryId = new Guid("c2e4c432-4e32-4bd3-a974-bd483c68c3cd")},
                new Company { Id = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"), Name = "Weasleys’ Wizard Wheezes", Cnpj = "66.235.852/0001-76", LogoImg = "", TotalGrade = 40, CategoryId = new Guid("32885749-4cc2-4445-86f5-c2b310cc5c9f")});
            
            Builder.Entity<User>().HasData(   
                new User { Id = new Guid("ae0d5c55-7053-42be-a56d-e0a24cb2ecc9"), FirstName = "Admin", LastName = "Partnership", Cpf = "674.213.970-60", AvatarImg = ""},
                new User { Id = new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc"), FirstName = "Guilherme", LastName = "Gusman", Cpf = "772.445.270-98", AvatarImg = ""},
                new User { Id = new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9"), FirstName = "Higor", LastName = "Nascimento", Cpf = "700.160.090-37", AvatarImg = ""});

            Builder.Entity<Login>().HasData(   
                new Login { Id = new Guid("36865be7-1394-49c6-9b32-3c7c4ac13504"), Email = "admin@partnership.com", Password = "admin", Role = "Admin", Professional = false},
                new Login { Id = new Guid("be6afb20-a5a1-4c1e-9b80-72f07dfd195b"), Email = "dadnis@gmail.com", Password = "123", Role = "User", Professional = false, UserId = new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc")},
                new Login { Id = new Guid("990d2b9a-ff86-40c8-bb08-9c305f34df62"), Email = "higornascimento@gmail.com", Password = "123", Role = "User", Professional = false, UserId = new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9")},
                new Login { Id = new Guid("45b34f39-14ec-4ab9-885e-66f8ed264a1f"), Email = "probmx1@gmail.com", Password = "123", Role = "Company", Professional = true, CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c")},
                new Login { Id = new Guid("dc185e37-6254-419d-a54a-4db071483a1e"), Email = "probmx2@gmail.com", Password = "123", Role = "Company", Professional = true, CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c")},
                new Login { Id = new Guid("19d797d2-877f-445d-8771-c0ade1cc3088"), Email = "quidditchsupplies@diagonalley.com", Password = "123", Role = "Company", Professional = true, CompanyId = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976")},
                new Login { Id = new Guid("822157e7-8770-413b-9adc-bd5fc7ddc5bd"), Email = "georgeweasley@diagonalley.com", Password = "123", Role = "Company", Professional = true, CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c")},
                new Login { Id = new Guid("a859aa2a-3cb1-48c2-a2c1-7a6f25fe6477"), Email = "fredweasley@diagonalley.com", Password = "123", Role = "Company", Professional = true, CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c")},
                new Login { Id = new Guid("854e1b60-d6ed-45f6-92cc-12b9880e57db"), Email = "ronweasley@diagonalley.com", Password = "123", Role = "Company", Professional = true, CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c")});

            Builder.Entity<Address>().HasData(
                new Address { Id = Guid.NewGuid(), Cep = "40385640", Logradouro = "Rua José Tibério", Bairro = "Boa Vista de São Caetano", Localidade = "Salvador", Uf = "BA", Complemento = "", UserId = new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc")},
                new Address { Id = Guid.NewGuid(), Cep = "35430505", Logradouro = "Rua Rio Doce", Bairro = "Santo Antônio I", Localidade = "Ponte Nova", Uf = "MG", Complemento = "", UserId = new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9")},
                new Address { Id = Guid.NewGuid(), Cep = "03162160", Logradouro = "Rua Tagi", Bairro = "Mooca", Localidade = "São Paulo", Uf = "SP", Complemento = "", CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c")},
                new Address { Id = Guid.NewGuid(), Cep = "20080020", Logradouro = "Rua dos Andradas", Bairro = "Centro", Localidade = "Rio de Janeiro", Uf = "RJ", Complemento = "", CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c")},
                new Address { Id = Guid.NewGuid(), Cep = "North Side", Logradouro = "Charing Cross Road", Bairro = "Diagon Alley", Localidade = "London", Uf = "LO", Complemento = "", CompanyId = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976")},
                new Address { Id = Guid.NewGuid(), Cep = "North Side", Logradouro = "Charing Cross Road", Bairro = "Diagon Alley", Localidade = "London", Uf = "LO", Complemento = "93, Giant sir with hat at entrance", CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c")});
        
            Builder.Entity<Promo>().HasData(
                new Promo { Id = Guid.NewGuid(), Discount = 0, Condition = false, DiscountDescription = "We're to good to give discount", Created = DateTime.UtcNow, CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c")},
                new Promo { Id = Guid.NewGuid(), Discount = 50, Condition = true, DiscountDescription = "HOT DEAL: Firebolt at 50% OFF", Created = DateTime.UtcNow, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(5), CompanyId = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976")},
                new Promo { Id = Guid.NewGuid(), Discount = 10, Condition = false, DiscountDescription = "Everything with 10% OFF", Created = DateTime.UtcNow, StartDate = DateTime.UtcNow.AddDays(5), CompanyId = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976")},
                new Promo { Id = Guid.NewGuid(), Discount = 30, Condition = true, DiscountDescription = "Everyone seeking happiness", Created = DateTime.UtcNow, CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c")});
        }
    }
}