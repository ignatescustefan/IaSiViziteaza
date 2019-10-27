using Microsoft.EntityFrameworkCore.Migrations;

namespace IaSiViziteaza.DAL.Migrations
{
    public partial class AddOnDeleteCascadeContraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attraction_AttractionType_AttractionTypeId",
                table: "Attraction");

            migrationBuilder.DropForeignKey(
                name: "FK_Attraction_User_UserId",
                table: "Attraction");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Attraction_AttractionId",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_Attraction_AttractionType_AttractionTypeId",
                table: "Attraction",
                column: "AttractionTypeId",
                principalTable: "AttractionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attraction_User_UserId",
                table: "Attraction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Attraction_AttractionId",
                table: "Comment",
                column: "AttractionId",
                principalTable: "Attraction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attraction_AttractionType_AttractionTypeId",
                table: "Attraction");

            migrationBuilder.DropForeignKey(
                name: "FK_Attraction_User_UserId",
                table: "Attraction");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Attraction_AttractionId",
                table: "Comment");

            migrationBuilder.AddForeignKey(
                name: "FK_Attraction_AttractionType_AttractionTypeId",
                table: "Attraction",
                column: "AttractionTypeId",
                principalTable: "AttractionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attraction_User_UserId",
                table: "Attraction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Attraction_AttractionId",
                table: "Comment",
                column: "AttractionId",
                principalTable: "Attraction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
