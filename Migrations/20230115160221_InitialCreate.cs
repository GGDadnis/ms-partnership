using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mspartnership.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "text", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "text", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: false),
                    avatarimg = table.Column<string>(name: "avatar_img", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    cnpj = table.Column<string>(type: "text", nullable: false),
                    logoimg = table.Column<string>(name: "logo_img", type: "text", nullable: true),
                    totalgrade = table.Column<double>(name: "total_grade", type: "double precision", nullable: true),
                    categoryid = table.Column<Guid>(name: "category_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                    table.ForeignKey(
                        name: "FK_company_category_category_id",
                        column: x => x.categoryid,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    logradouro = table.Column<string>(type: "text", nullable: false),
                    bairro = table.Column<string>(type: "text", nullable: false),
                    localidade = table.Column<string>(type: "text", nullable: false),
                    uf = table.Column<string>(type: "text", nullable: false),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    companyid = table.Column<Guid>(name: "company_id", type: "uuid", nullable: true),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_company_company_id",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_address_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    professional = table.Column<bool>(type: "boolean", nullable: false),
                    salt = table.Column<string>(type: "text", nullable: true),
                    companyid = table.Column<Guid>(name: "company_id", type: "uuid", nullable: true),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.id);
                    table.ForeignKey(
                        name: "FK_Logins_company_company_id",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Logins_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "promo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    discount = table.Column<double>(type: "double precision", nullable: false),
                    condition = table.Column<bool>(type: "boolean", nullable: false),
                    discountdescription = table.Column<string>(name: "discount_description", type: "text", nullable: true),
                    startdate = table.Column<DateTime>(name: "start_date", type: "timestamp with time zone", nullable: true),
                    enddate = table.Column<DateTime>(name: "end_date", type: "timestamp with time zone", nullable: true),
                    companyid = table.Column<Guid>(name: "company_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promo", x => x.id);
                    table.ForeignKey(
                        name: "FK_promo_company_company_id",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    goodgrade = table.Column<bool>(name: "good_grade", type: "boolean", nullable: false),
                    badgrade = table.Column<bool>(name: "bad_grade", type: "boolean", nullable: false),
                    comentaries = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: true),
                    companyid = table.Column<Guid>(name: "company_id", type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.id);
                    table.ForeignKey(
                        name: "FK_Review_company_company_id",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Review_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "id", "company_id", "email", "password", "professional", "role", "salt", "user_id" },
                values: new object[] { new Guid("36865be7-1394-49c6-9b32-3c7c4ac13504"), null, "admin@partnership.com", "admin", false, "Admin", null, null });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("32885749-4cc2-4445-86f5-c2b310cc5c9f"), "Commerce" },
                    { new Guid("47367ee8-86ea-40d2-a672-b6acd1f8e2ad"), "Educational" },
                    { new Guid("4e4cb863-9645-407b-8b3f-460c6ae9a163"), "Health" },
                    { new Guid("841d7bfb-b080-4871-9774-6df240acaa06"), "Legal" },
                    { new Guid("9e6e6cbb-0a0f-47b0-9410-8b9af03f03f3"), "Others" },
                    { new Guid("c2e4c432-4e32-4bd3-a974-bd483c68c3cd"), "Gym & Sports" },
                    { new Guid("ccc12f58-e67f-4922-9070-c85c02d2243c"), "Food" },
                    { new Guid("f88de2f7-b3a2-4675-a364-0989de28b16c"), "Beauty" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "avatar_img", "cpf", "first_name", "last_name" },
                values: new object[,]
                {
                    { new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9"), "", "700.160.090-37", "Higor", "Nascimento" },
                    { new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc"), "", "772.445.270-98", "Guilherme", "Gusman" },
                    { new Guid("ae0d5c55-7053-42be-a56d-e0a24cb2ecc9"), "", "674.213.970-60", "Admin", "Partnership" }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "id", "company_id", "email", "password", "professional", "role", "salt", "user_id" },
                values: new object[,]
                {
                    { new Guid("990d2b9a-ff86-40c8-bb08-9c305f34df62"), null, "higornascimento@gmail.com", "123", false, "User", null, new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9") },
                    { new Guid("be6afb20-a5a1-4c1e-9b80-72f07dfd195b"), null, "dadnis@gmail.com", "123", false, "User", null, new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc") }
                });

            migrationBuilder.InsertData(
                table: "address",
                columns: new[] { "id", "bairro", "cep", "company_id", "complemento", "localidade", "logradouro", "uf", "user_id" },
                values: new object[,]
                {
                    { new Guid("9fbae565-0091-4a22-845f-f0543e5109d8"), "Santo Antônio I", "35430505", null, "", "Ponte Nova", "Rua Rio Doce", "MG", new Guid("0ae4a7a5-5314-4312-ba10-e074d32ed6b9") },
                    { new Guid("e4af91f7-6744-4550-8f16-b6224c8e7e75"), "Boa Vista de São Caetano", "40385640", null, "", "Salvador", "Rua José Tibério", "BA", new Guid("5e30cb9e-5e09-4d8c-84b6-33a4effb46bc") }
                });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "id", "category_id", "cnpj", "logo_img", "name", "total_grade" },
                values: new object[,]
                {
                    { new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"), new Guid("c2e4c432-4e32-4bd3-a974-bd483c68c3cd"), "82.509.987/0001-39", "", "Quality Quidditch Supplies", 70.0 },
                    { new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"), new Guid("9e6e6cbb-0a0f-47b0-9410-8b9af03f03f3"), "87.374.287/0001-06", "", "ProBmx", 100.0 },
                    { new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"), new Guid("32885749-4cc2-4445-86f5-c2b310cc5c9f"), "66.235.852/0001-76", "", "Weasleys’ Wizard Wheezes", 40.0 }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "id", "company_id", "email", "password", "professional", "role", "salt", "user_id" },
                values: new object[,]
                {
                    { new Guid("19d797d2-877f-445d-8771-c0ade1cc3088"), new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"), "quidditchsupplies@diagonalley.com", "123", true, "Company", null, null },
                    { new Guid("45b34f39-14ec-4ab9-885e-66f8ed264a1f"), new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"), "probmx1@gmail.com", "123", true, "Company", null, null },
                    { new Guid("822157e7-8770-413b-9adc-bd5fc7ddc5bd"), new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"), "georgeweasley@diagonalley.com", "123", true, "Company", null, null },
                    { new Guid("854e1b60-d6ed-45f6-92cc-12b9880e57db"), new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"), "ronweasley@diagonalley.com", "123", true, "Company", null, null },
                    { new Guid("a859aa2a-3cb1-48c2-a2c1-7a6f25fe6477"), new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"), "fredweasley@diagonalley.com", "123", true, "Company", null, null },
                    { new Guid("dc185e37-6254-419d-a54a-4db071483a1e"), new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"), "probmx2@gmail.com", "123", true, "Company", null, null }
                });

            migrationBuilder.InsertData(
                table: "address",
                columns: new[] { "id", "bairro", "cep", "company_id", "complemento", "localidade", "logradouro", "uf", "user_id" },
                values: new object[,]
                {
                    { new Guid("3992e730-ea4a-4280-9178-797c94d5bb6e"), "Mooca", "03162160", new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"), "", "São Paulo", "Rua Tagi", "SP", null },
                    { new Guid("95e28ea0-3608-48f3-ba1e-1d5c8d58f646"), "Diagon Alley", "North Side", new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"), "", "London", "Charing Cross Road", "LO", null },
                    { new Guid("a6ea55ed-f3c5-4bf0-be7b-084eb3c88ba0"), "Centro", "20080020", new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"), "", "Rio de Janeiro", "Rua dos Andradas", "RJ", null },
                    { new Guid("d20ef20c-fe08-4341-a386-9e8d527ca846"), "Diagon Alley", "North Side", new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"), "93, Giant sir with hat at entrance", "London", "Charing Cross Road", "LO", null }
                });

            migrationBuilder.InsertData(
                table: "promo",
                columns: new[] { "id", "company_id", "condition", "discount", "discount_description", "end_date", "start_date" },
                values: new object[,]
                {
                    { new Guid("1d740c32-afe1-4137-aab0-a4843b398fe0"), new Guid("80d66e15-8c2c-4420-a0ef-5d40d050d52c"), false, 0.0, "We're to good to give discount", null, null },
                    { new Guid("715680b7-00d4-448a-b892-7cd61a3e57cc"), new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"), true, 50.0, "HOT DEAL: Firebolt at 50% OFF", new DateTime(2023, 1, 20, 16, 2, 21, 67, DateTimeKind.Utc).AddTicks(7673), new DateTime(2023, 1, 15, 16, 2, 21, 67, DateTimeKind.Utc).AddTicks(7671) },
                    { new Guid("8af2d467-d7d8-4b3f-9ac1-34102d4585e2"), new Guid("43b478b0-8667-4c05-a905-dcb00b7cd976"), false, 10.0, "Everything with 10% OFF", null, new DateTime(2023, 1, 20, 16, 2, 21, 67, DateTimeKind.Utc).AddTicks(7682) },
                    { new Guid("907bd72f-b890-4032-b6e2-3f137f6f6835"), new Guid("f7418b55-cca4-4f03-badc-cf194f82b57c"), true, 30.0, "Everyone seeking happiness", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_company_id",
                table: "address",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_address_user_id",
                table: "address",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_company_category_id",
                table: "company",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_company_id",
                table: "Logins",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_user_id",
                table: "Logins",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_promo_company_id",
                table: "promo",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_company_id",
                table: "Review",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_user_id",
                table: "Review",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "promo");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
