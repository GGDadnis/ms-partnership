using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mspartnership.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    cnpj = table.Column<string>(type: "text", nullable: false),
                    logoimg = table.Column<string>(name: "logo_img", type: "text", nullable: true),
                    totalgrade = table.Column<double>(name: "total_grade", type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    goodgrade = table.Column<bool>(name: "good_grade", type: "boolean", nullable: false),
                    badgrade = table.Column<bool>(name: "bad_grade", type: "boolean", nullable: false),
                    comentaries = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.id);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
