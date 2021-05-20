using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogWebApp.Migrations
{
    public partial class PopulateDogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dog",
                columns: new[] { "Id", "Age", "Birthday", "Breed", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, (short)11, new DateTime(2010, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Havanese", "Treasure", 10f },
                    { 2, (short)6, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shih Tzu", "Teegan", 16f },
                    { 3, (short)13, new DateTime(2008, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Golden Retriever", "Declan", 80f },
                    { 4, (short)11, new DateTime(2009, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chihuahua-Toy Poodle Mix", "Cloe", 7f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dog",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
