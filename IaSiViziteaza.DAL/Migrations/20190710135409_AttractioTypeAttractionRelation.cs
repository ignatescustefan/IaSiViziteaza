using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IaSiViziteaza.DAL.Migrations
{
    public partial class AttractioTypeAttractionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AttractionTypeId",
                table: "Attraction",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Attraction_AttractionTypeId",
                table: "Attraction",
                column: "AttractionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attraction_AttractionType_AttractionTypeId",
                table: "Attraction",
                column: "AttractionTypeId",
                principalTable: "AttractionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attraction_AttractionType_AttractionTypeId",
                table: "Attraction");

            migrationBuilder.DropIndex(
                name: "IX_Attraction_AttractionTypeId",
                table: "Attraction");

            migrationBuilder.AlterColumn<Guid>(
                name: "AttractionTypeId",
                table: "Attraction",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
