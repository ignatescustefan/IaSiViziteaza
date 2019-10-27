using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IaSiViziteaza.DAL.Migrations
{
    public partial class CreateAccessRight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessRight",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Priority = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRight", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessRight");
        }
    }
}
