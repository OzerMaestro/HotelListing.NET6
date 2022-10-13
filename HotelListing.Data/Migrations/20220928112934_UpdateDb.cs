using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85fdbf82-bccd-4802-abdc-1d409cf4cbce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "effa98be-83c7-4342-a229-a4087b4bdd44");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47caa569-f0ec-4b68-8f5a-cd5f899ecd9a", "4a89b226-9416-4da9-b247-c21582cfd457", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca876716-5a5b-4861-ab06-7fbaf40fa815", "c743b424-13bb-46e4-8573-afb05a0a2ab6", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47caa569-f0ec-4b68-8f5a-cd5f899ecd9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca876716-5a5b-4861-ab06-7fbaf40fa815");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85fdbf82-bccd-4802-abdc-1d409cf4cbce", "2192a4dd-7912-40cc-9eb6-e3c0271e74f3", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "effa98be-83c7-4342-a229-a4087b4bdd44", "81ebd8dc-9beb-4acd-ada6-c8785acb2bf5", "User", "USER" });
        }
    }
}
