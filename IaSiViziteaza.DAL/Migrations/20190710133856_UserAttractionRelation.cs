using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IaSiViziteaza.DAL.Migrations
{
    public partial class UserAttractionRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Attraction",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Attraction_UserId",
                table: "Attraction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attraction_User_UserId",
                table: "Attraction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attraction_User_UserId",
                table: "Attraction");

            migrationBuilder.DropIndex(
                name: "IX_Attraction_UserId",
                table: "Attraction");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Attraction",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
