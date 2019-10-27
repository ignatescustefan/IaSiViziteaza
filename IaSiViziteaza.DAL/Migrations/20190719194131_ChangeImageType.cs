using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IaSiViziteaza.DAL.Migrations
{
    public partial class ChangeImageType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AttractionType");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Attraction");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AttractionType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Attraction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AttractionType");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Attraction");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "AttractionType",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Attraction",
                nullable: true);
        }
    }
}
