using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.InfaStructure.Migrations
{
    /// <inheritdoc />
    public partial class smallEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b4451ea-90e9-4e05-9f35-385d35b67c4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d27c4b6-50ec-4bd1-9549-497f1ac6a965");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2205cd4b-2eba-4fae-a57a-9c640a68f0c4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3909a549-35d4-4f4e-b29f-1b25e192dba7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("552a199e-0e20-4af7-9f5a-c66659c1d683"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a050d4ff-4b2b-495b-aefb-405e07056176"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2eb6925-3a87-44c0-bd47-93d303484c83"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e365d096-2776-48df-bdf2-c95464dc630a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "89cb02aa-154a-4ccf-92fd-981434b6ef31", null, "User", null },
                    { "9752d138-83b6-4478-9d57-b186b38954ce", null, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discound", "Name", "OriginalPrice", "Picture", "Price", "Quentity" },
                values: new object[,]
                {
                    { new Guid("0cdb9ac8-d1e4-436e-9039-2ee6bd6647a9"), new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"), null, null, "Product 4", null, null, 300.0, 100 },
                    { new Guid("2f8206af-bc7f-4edf-8688-75cee9448329"), new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"), null, null, "Product 5", null, null, 150.90000000000001, 20 },
                    { new Guid("83680c33-bd20-4401-b553-44e2fcc072ee"), new Guid("71707f88-4722-4df1-b34f-8df6341e806c"), null, null, "Product 6", null, null, 200.0, 5 },
                    { new Guid("ec113c17-0d52-4b86-a98b-ba2e6135b639"), new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"), null, null, "Product 2", null, null, 150.0, 10 },
                    { new Guid("f088a3ea-6085-4ffd-9082-2a1cd45e742c"), new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"), null, null, "Product 3", null, null, 150.5, 50 },
                    { new Guid("f508d83d-0d42-49f4-8d73-c238332b8d53"), new Guid("71707f88-4722-4df1-b34f-8df6341e806c"), null, null, "Product 1", null, null, 300.0, 27 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89cb02aa-154a-4ccf-92fd-981434b6ef31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9752d138-83b6-4478-9d57-b186b38954ce");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0cdb9ac8-d1e4-436e-9039-2ee6bd6647a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f8206af-bc7f-4edf-8688-75cee9448329"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83680c33-bd20-4401-b553-44e2fcc072ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec113c17-0d52-4b86-a98b-ba2e6135b639"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f088a3ea-6085-4ffd-9082-2a1cd45e742c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f508d83d-0d42-49f4-8d73-c238332b8d53"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b4451ea-90e9-4e05-9f35-385d35b67c4d", null, "User", null },
                    { "3d27c4b6-50ec-4bd1-9549-497f1ac6a965", null, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discound", "Name", "OriginalPrice", "Picture", "Price", "Quentity" },
                values: new object[,]
                {
                    { new Guid("2205cd4b-2eba-4fae-a57a-9c640a68f0c4"), new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"), null, null, "Product 4", null, null, 300.0, 100 },
                    { new Guid("3909a549-35d4-4f4e-b29f-1b25e192dba7"), new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"), null, null, "Product 5", null, null, 150.90000000000001, 20 },
                    { new Guid("552a199e-0e20-4af7-9f5a-c66659c1d683"), new Guid("71707f88-4722-4df1-b34f-8df6341e806c"), null, null, "Product 6", null, null, 200.0, 5 },
                    { new Guid("a050d4ff-4b2b-495b-aefb-405e07056176"), new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"), null, null, "Product 3", null, null, 150.5, 50 },
                    { new Guid("b2eb6925-3a87-44c0-bd47-93d303484c83"), new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"), null, null, "Product 2", null, null, 150.0, 10 },
                    { new Guid("e365d096-2776-48df-bdf2-c95464dc630a"), new Guid("71707f88-4722-4df1-b34f-8df6341e806c"), null, null, "Product 1", null, null, 300.0, 27 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
