using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IaSiViziteaza.DAL.Migrations
{
    public partial class AddImageColumnToAttrAndAttrType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "AttractionType",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Attraction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AttractionType");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Attraction");
        }
    }
}
