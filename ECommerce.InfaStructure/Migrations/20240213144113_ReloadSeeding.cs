using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.InfaStructure.Migrations
{
    /// <inheritdoc />
    public partial class ReloadSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DB");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "DB");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "DB");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresses",
                newSchema: "DB");

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89cb02aa-154a-4ccf-92fd-981434b6ef31",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "9752d138-83b6-4478-9d57-b186b38954ce", "USER" });

            migrationBuilder.UpdateData(
                schema: "Security",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9752d138-83b6-4478-9d57-b186b38954ce",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "89cb02aa-154a-4ccf-92fd-981434b6ef31", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Products",
                schema: "DB",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "DB",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Security",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Security",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Security",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Security",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Security",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Security",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Security",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "DB",
                newName: "Addresses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89cb02aa-154a-4ccf-92fd-981434b6ef31",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9752d138-83b6-4478-9d57-b186b38954ce",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { null, null });
        }
    }
}
