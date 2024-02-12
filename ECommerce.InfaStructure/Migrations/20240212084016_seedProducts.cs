using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.InfaStructure.Migrations
{
    /// <inheritdoc />
    public partial class seedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d8837f7-da77-4933-8bda-615ca2a7dc06"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dbc37cb6-4daf-45e7-87ef-9d539ebf1f33"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fdd5f3c3-1c86-424a-8364-79e0f598bb38"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"), "Description", "Category 2" },
                    { new Guid("71707f88-4722-4df1-b34f-8df6341e806c"), "Description", "Category 3" },
                    { new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"), "Description", "Category 1" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discound", "Name", "OriginalPrice", "Picture", "Price", "Quentity" },
                values: new object[,]
                {
                    { new Guid("0d315240-fcec-489e-b805-603d52ccf322"), new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"), null, null, "Product 2", null, null, 150.0, 10 },
                    { new Guid("3cad3669-9148-4ce8-9ccb-ffbe3d9c0de2"), new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"), null, null, "Product 5", null, null, 150.90000000000001, 20 },
                    { new Guid("57d73b93-7366-4b85-847f-fa561ecf75dc"), new Guid("71707f88-4722-4df1-b34f-8df6341e806c"), null, null, "Product 1", null, null, 300.0, 27 },
                    { new Guid("654518b7-887f-4443-a4c1-bf600d1d99c8"), new Guid("71707f88-4722-4df1-b34f-8df6341e806c"), null, null, "Product 6", null, null, 200.0, 5 },
                    { new Guid("a5c9de4a-351a-471e-b300-1a15896fc883"), new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"), null, null, "Product 3", null, null, 150.5, 50 },
                    { new Guid("af96a519-281b-4e6b-8cb2-fe66d3a9d1f1"), new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"), null, null, "Product 4", null, null, 300.0, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6e2fe03d-0b89-4613-921e-c7eb7b0e708a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("71707f88-4722-4df1-b34f-8df6341e806c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b41b2ba0-b99b-41d2-83b7-744dd943fc91"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d315240-fcec-489e-b805-603d52ccf322"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3cad3669-9148-4ce8-9ccb-ffbe3d9c0de2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57d73b93-7366-4b85-847f-fa561ecf75dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("654518b7-887f-4443-a4c1-bf600d1d99c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a5c9de4a-351a-471e-b300-1a15896fc883"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("af96a519-281b-4e6b-8cb2-fe66d3a9d1f1"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6d8837f7-da77-4933-8bda-615ca2a7dc06"), "Description", "Category 3" },
                    { new Guid("dbc37cb6-4daf-45e7-87ef-9d539ebf1f33"), "Description", "Category 2" },
                    { new Guid("fdd5f3c3-1c86-424a-8364-79e0f598bb38"), "Description", "Category 1" }
                });
        }
    }
}
