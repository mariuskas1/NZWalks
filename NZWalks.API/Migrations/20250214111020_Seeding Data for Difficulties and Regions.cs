using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b86165c-e230-4030-8b3e-a448cd332f31"), "Easy" },
                    { new Guid("0dac46db-6c58-435a-b622-0b7e55662382"), "Medium" },
                    { new Guid("3c9f6b56-ff26-4f30-9003-aeb561c1dc94"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("37fc2fb1-85eb-478d-a412-56bf6e6b0124"), "NTL", "Northland", null },
                    { new Guid("385adf04-04ac-44cf-8d3e-2029387f81b0"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("576a791e-b80e-4c54-9c92-58b46c201e2f"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("8bdbe7cb-e8c6-472f-b349-3bcd7ad7ee91"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("a3580dd3-d98a-44ca-9dca-51d827af68fd"), "BOP", "Bay of Plenty", null },
                    { new Guid("ec2ae41e-f810-4ac1-9dca-b1597d5b624d"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0b86165c-e230-4030-8b3e-a448cd332f31"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0dac46db-6c58-435a-b622-0b7e55662382"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3c9f6b56-ff26-4f30-9003-aeb561c1dc94"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("37fc2fb1-85eb-478d-a412-56bf6e6b0124"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("385adf04-04ac-44cf-8d3e-2029387f81b0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("576a791e-b80e-4c54-9c92-58b46c201e2f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8bdbe7cb-e8c6-472f-b349-3bcd7ad7ee91"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a3580dd3-d98a-44ca-9dca-51d827af68fd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ec2ae41e-f810-4ac1-9dca-b1597d5b624d"));
        }
    }
}
