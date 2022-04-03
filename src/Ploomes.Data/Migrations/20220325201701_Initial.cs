using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ploomes.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Identification = table.Column<string>(type: "VARCHAR(14)", nullable: true),
                    ProviderType = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Additional = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    ZipCode = table.Column<string>(type: "VARCHAR(8)", nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    State = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProviderId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    Image = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProviderId",
                table: "Address",
                column: "ProviderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProviderId",
                table: "Products",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
