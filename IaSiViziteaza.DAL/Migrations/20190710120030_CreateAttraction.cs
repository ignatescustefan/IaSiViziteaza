using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IaSiViziteaza.DAL.Migrations
{
    public partial class CreateAttraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccessRights_AccessRight_AccessRightId",
                table: "UserAccessRights");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccessRights_User_UserId",
                table: "UserAccessRights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccessRights",
                table: "UserAccessRights");

            migrationBuilder.RenameTable(
                name: "UserAccessRights",
                newName: "UserAccesRight");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccessRights_AccessRightId",
                table: "UserAccesRight",
                newName: "IX_UserAccesRight_AccessRightId");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationOfAttractionId",
                table: "Location",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccesRight",
                table: "UserAccesRight",
                columns: new[] { "UserId", "AccessRightId" });

            migrationBuilder.CreateTable(
                name: "Attraction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AttractionTypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    OpenTime = table.Column<TimeSpan>(nullable: false),
                    CloseTime = table.Column<TimeSpan>(nullable: false),
                    CreateAtractionTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attraction", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationOfAttractionId",
                table: "Location",
                column: "LocationOfAttractionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Attraction_LocationOfAttractionId",
                table: "Location",
                column: "LocationOfAttractionId",
                principalTable: "Attraction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccesRight_AccessRight_AccessRightId",
                table: "UserAccesRight",
                column: "AccessRightId",
                principalTable: "AccessRight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccesRight_User_UserId",
                table: "UserAccesRight",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Attraction_LocationOfAttractionId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccesRight_AccessRight_AccessRightId",
                table: "UserAccesRight");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccesRight_User_UserId",
                table: "UserAccesRight");

            migrationBuilder.DropTable(
                name: "Attraction");

            migrationBuilder.DropIndex(
                name: "IX_Location_LocationOfAttractionId",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccesRight",
                table: "UserAccesRight");

            migrationBuilder.DropColumn(
                name: "LocationOfAttractionId",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "UserAccesRight",
                newName: "UserAccessRights");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccesRight_AccessRightId",
                table: "UserAccessRights",
                newName: "IX_UserAccessRights_AccessRightId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccessRights",
                table: "UserAccessRights",
                columns: new[] { "UserId", "AccessRightId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccessRights_AccessRight_AccessRightId",
                table: "UserAccessRights",
                column: "AccessRightId",
                principalTable: "AccessRight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccessRights_User_UserId",
                table: "UserAccessRights",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
