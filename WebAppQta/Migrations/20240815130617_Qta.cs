using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppQta.Migrations
{
    public partial class Qta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Qualidade = table.Column<string>(nullable: true),
                    Refatorar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qta", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qta");
        }
    }
}
