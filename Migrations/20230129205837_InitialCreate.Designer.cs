﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ms_partnership.Data;

#nullable disable

namespace mspartnership.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230129205837_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ms_partnership.Models.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<string>("Complemento")
                        .HasColumnType("text")
                        .HasColumnName("complemento");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("localidade");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("logradouro");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("uf");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("address");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ca365168-dccf-4c4f-a497-38ee1ef439ae"),
                            Bairro = "Boa Vista de São Caetano",
                            Cep = "40385640",
                            Complemento = "",
                            Localidade = "Salvador",
                            Logradouro = "Rua José Tibério",
                            Uf = "BA",
                            UserId = new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc")
                        },
                        new
                        {
                            Id = new Guid("34351e1b-fe21-4829-87ee-9d8d9367025c"),
                            Bairro = "Santo Antônio I",
                            Cep = "35430505",
                            Complemento = "",
                            Localidade = "Ponte Nova",
                            Logradouro = "Rua Rio Doce",
                            Uf = "MG",
                            UserId = new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9")
                        },
                        new
                        {
                            Id = new Guid("de715ec7-d1b4-4a4d-8bd0-04c2a215b8a0"),
                            Bairro = "Mooca",
                            Cep = "03162160",
                            CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"),
                            Complemento = "",
                            Localidade = "São Paulo",
                            Logradouro = "Rua Tagi",
                            Uf = "SP"
                        },
                        new
                        {
                            Id = new Guid("9196194e-e4ea-4c41-af9d-8d85fb8c9849"),
                            Bairro = "Centro",
                            Cep = "20080020",
                            CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"),
                            Complemento = "",
                            Localidade = "Rio de Janeiro",
                            Logradouro = "Rua dos Andradas",
                            Uf = "RJ"
                        },
                        new
                        {
                            Id = new Guid("ff5a7cc0-a5ce-42e7-a2b5-327253e15fd6"),
                            Bairro = "Diagon Alley",
                            Cep = "North Side",
                            CompanyId = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"),
                            Complemento = "",
                            Localidade = "London",
                            Logradouro = "Charing Cross Road",
                            Uf = "LO"
                        },
                        new
                        {
                            Id = new Guid("87ecd9d1-43ec-4b53-aa5c-ffba2ce56162"),
                            Bairro = "Diagon Alley",
                            Cep = "North Side",
                            CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"),
                            Complemento = "93, Giant sir with hat at entrance",
                            Localidade = "London",
                            Logradouro = "Charing Cross Road",
                            Uf = "LO"
                        });
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f88de2f7-b3a2-4675-a364-0989de28b16c"),
                            Name = "Beauty"
                        },
                        new
                        {
                            Id = new Guid("32885749-4cc2-4445-86f5-c2b310cc5c9f"),
                            Name = "Commerce"
                        },
                        new
                        {
                            Id = new Guid("47367ee8-86ea-40d2-a672-b6acd1f8e2ad"),
                            Name = "Educational"
                        },
                        new
                        {
                            Id = new Guid("ccc12f58-e67f-4922-9070-c85c02d2243c"),
                            Name = "Food"
                        },
                        new
                        {
                            Id = new Guid("c2e4c432-4e32-4bd3-a974-bd483c68c3cd"),
                            Name = "Gym & Sports"
                        },
                        new
                        {
                            Id = new Guid("4e4cb863-9645-407b-8b3f-460c6ae9a163"),
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("841d7bfb-b080-4871-9774-6df240acaa06"),
                            Name = "Legal"
                        },
                        new
                        {
                            Id = new Guid("9e6e6cbb-0a0f-47b0-9410-8b9af03f03f3"),
                            Name = "Others"
                        });
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cnpj");

                    b.Property<string>("LogoImg")
                        .HasColumnType("text")
                        .HasColumnName("logo_img");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double?>("TotalGrade")
                        .HasColumnType("double precision")
                        .HasColumnName("total_grade");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("company");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"),
                            Active = true,
                            CategoryId = new Guid("9e6e6cbb-0a0f-47b0-9410-8b9af03f03f3"),
                            Cnpj = "87.374.287/0001-06",
                            LogoImg = "",
                            Name = "ProBmx",
                            TotalGrade = 100.0
                        },
                        new
                        {
                            Id = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"),
                            Active = true,
                            CategoryId = new Guid("c2e4c432-4e32-4bd3-a974-bd483c68c3cd"),
                            Cnpj = "82.509.987/0001-39",
                            LogoImg = "",
                            Name = "Quality Quidditch Supplies",
                            TotalGrade = 70.0
                        },
                        new
                        {
                            Id = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"),
                            Active = true,
                            CategoryId = new Guid("32885749-4cc2-4445-86f5-c2b310cc5c9f"),
                            Cnpj = "66.235.852/0001-76",
                            LogoImg = "",
                            Name = "Weasleys’ Wizard Wheezes",
                            TotalGrade = 40.0
                        });
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<bool>("Professional")
                        .HasColumnType("boolean")
                        .HasColumnName("professional");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("Salt")
                        .HasColumnType("text")
                        .HasColumnName("salt");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("login");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36865be7-1394-49c6-9b32-3c7c4ac13504"),
                            Email = "admin@partnership.com",
                            Password = "admin",
                            Professional = false,
                            Role = "Admin"
                        },
                        new
                        {
                            Id = new Guid("be6afb20-a5a1-4c1e-9b80-72f07dfd195b"),
                            Email = "dadnis@gmail.com",
                            Password = "123",
                            Professional = false,
                            Role = "User",
                            UserId = new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc")
                        },
                        new
                        {
                            Id = new Guid("990d2b9a-ff86-40c8-bb08-9c305f34df62"),
                            Email = "higornascimento@gmail.com",
                            Password = "123",
                            Professional = false,
                            Role = "User",
                            UserId = new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9")
                        },
                        new
                        {
                            Id = new Guid("45b34f39-14ec-4ab9-885e-66f8ed264a1f"),
                            CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"),
                            Email = "probmx1@gmail.com",
                            Password = "123",
                            Professional = true,
                            Role = "Company"
                        },
                        new
                        {
                            Id = new Guid("dc185e37-6254-419d-a54a-4db071483a1e"),
                            CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"),
                            Email = "probmx2@gmail.com",
                            Password = "123",
                            Professional = true,
                            Role = "Company"
                        },
                        new
                        {
                            Id = new Guid("19d797d2-877f-445d-8771-c0ade1cc3088"),
                            CompanyId = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"),
                            Email = "quidditchsupplies@diagonalley.com",
                            Password = "123",
                            Professional = true,
                            Role = "Company"
                        },
                        new
                        {
                            Id = new Guid("822157e7-8770-413b-9adc-bd5fc7ddc5bd"),
                            CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"),
                            Email = "georgeweasley@diagonalley.com",
                            Password = "123",
                            Professional = true,
                            Role = "Company"
                        },
                        new
                        {
                            Id = new Guid("a859aa2a-3cb1-48c2-a2c1-7a6f25fe6477"),
                            CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"),
                            Email = "fredweasley@diagonalley.com",
                            Password = "123",
                            Professional = true,
                            Role = "Company"
                        },
                        new
                        {
                            Id = new Guid("854e1b60-d6ed-45f6-92cc-12b9880e57db"),
                            CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"),
                            Email = "ronweasley@diagonalley.com",
                            Password = "123",
                            Professional = true,
                            Role = "Company"
                        });
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Promo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<bool>("Condition")
                        .HasColumnType("boolean")
                        .HasColumnName("condition");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision")
                        .HasColumnName("discount");

                    b.Property<string>("DiscountDescription")
                        .HasColumnType("text")
                        .HasColumnName("discount_description");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("promo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe9a1dc3-019b-4d43-96f9-a7ea5c9ea347"),
                            CompanyId = new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"),
                            Condition = false,
                            Created = new DateTime(2023, 1, 29, 20, 58, 37, 829, DateTimeKind.Utc).AddTicks(462),
                            Discount = 0.0,
                            DiscountDescription = "We're to good to give discount"
                        },
                        new
                        {
                            Id = new Guid("ac70920a-9a89-46b5-b48d-92f4989327b9"),
                            CompanyId = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"),
                            Condition = true,
                            Created = new DateTime(2023, 1, 29, 20, 58, 37, 829, DateTimeKind.Utc).AddTicks(477),
                            Discount = 50.0,
                            DiscountDescription = "HOT DEAL: Firebolt at 50% OFF",
                            EndDate = new DateTime(2023, 2, 3, 20, 58, 37, 829, DateTimeKind.Utc).AddTicks(480),
                            StartDate = new DateTime(2023, 1, 29, 20, 58, 37, 829, DateTimeKind.Utc).AddTicks(478)
                        },
                        new
                        {
                            Id = new Guid("8a291df7-c7d8-4b17-9cee-dfd286198b4c"),
                            CompanyId = new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"),
                            Condition = false,
                            Created = new DateTime(2023, 1, 29, 20, 58, 37, 829, DateTimeKind.Utc).AddTicks(488),
                            Discount = 10.0,
                            DiscountDescription = "Everything with 10% OFF",
                            StartDate = new DateTime(2023, 2, 3, 20, 58, 37, 829, DateTimeKind.Utc).AddTicks(488)
                        },
                        new
                        {
                            Id = new Guid("6d1f6012-e324-4d82-8451-2c065c4ab57c"),
                            CompanyId = new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"),
                            Condition = true,
                            Created = new DateTime(2023, 1, 29, 20, 58, 37, 829, DateTimeKind.Utc).AddTicks(490),
                            Discount = 30.0,
                            DiscountDescription = "Everyone seeking happiness"
                        });
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("BadGrade")
                        .HasColumnType("boolean")
                        .HasColumnName("bad_grade");

                    b.Property<string>("Comentaries")
                        .HasColumnType("text")
                        .HasColumnName("comentaries");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<bool>("GoodGrade")
                        .HasColumnType("boolean")
                        .HasColumnName("good_grade");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("review");
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<string>("AvatarImg")
                        .HasColumnType("text")
                        .HasColumnName("avatar_img");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae0d5c55-7053-42be-a56d-e0a24cb2ecc9"),
                            Active = true,
                            AvatarImg = "",
                            Cpf = "674.213.970-60",
                            FirstName = "Admin",
                            LastName = "Partnership"
                        },
                        new
                        {
                            Id = new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc"),
                            Active = true,
                            AvatarImg = "",
                            Cpf = "772.445.270-98",
                            FirstName = "Guilherme",
                            LastName = "Gusman"
                        },
                        new
                        {
                            Id = new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9"),
                            Active = true,
                            AvatarImg = "",
                            Cpf = "700.160.090-37",
                            FirstName = "Higor",
                            LastName = "Nascimento"
                        });
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Address", b =>
                {
                    b.HasOne("ms_partnership.Models.Entities.Company", "Company")
                        .WithMany("Addresses")
                        .HasForeignKey("CompanyId");

                    b.HasOne("ms_partnership.Models.Entities.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("ms_partnership.Models.Entities.Address", "UserId");

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Company", b =>
                {
                    b.HasOne("ms_partnership.Models.Entities.Category", "Category")
                        .WithMany("Companies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Login", b =>
                {
                    b.HasOne("ms_partnership.Models.Entities.Company", "Company")
                        .WithMany("Logins")
                        .HasForeignKey("CompanyId");

                    b.HasOne("ms_partnership.Models.Entities.User", "User")
                        .WithOne("Login")
                        .HasForeignKey("ms_partnership.Models.Entities.Login", "UserId");

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Promo", b =>
                {
                    b.HasOne("ms_partnership.Models.Entities.Company", "Company")
                        .WithMany("Promos")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Review", b =>
                {
                    b.HasOne("ms_partnership.Models.Entities.Company", "Company")
                        .WithMany("Reviews")
                        .HasForeignKey("CompanyId");

                    b.HasOne("ms_partnership.Models.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Category", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.Company", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Logins");

                    b.Navigation("Promos");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ms_partnership.Models.Entities.User", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
