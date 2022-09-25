using Microsoft.EntityFrameworkCore.Migrations;

namespace ps_DutchTreat.Migrations
{
    public partial class Adddefaultschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PS-241");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItem",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "PS-241");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "PS-241");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Products",
                schema: "PS-241",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "PS-241",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                schema: "PS-241",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "PS-241",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "PS-241",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "PS-241",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "PS-241",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "PS-241",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "PS-241",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "PS-241",
                newName: "AspNetRoleClaims");
        }
    }
}
