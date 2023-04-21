using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Jurisdictions");

            migrationBuilder.InsertData(
                table: "Jurisdictions",
                columns: new[] { "Code", "DisplayColor", "UserId" },
                values: new object[,]
                {
                    { "BE", "orange", null },
                    { "DE", "olive", null },
                    { "GB", "blue", null },
                    { "IE", "green", null },
                    { "NL", "aqua", null },
                    { "PL", "red", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jurisdictions",
                keyColumn: "Code",
                keyValue: "BE");

            migrationBuilder.DeleteData(
                table: "Jurisdictions",
                keyColumn: "Code",
                keyValue: "DE");

            migrationBuilder.DeleteData(
                table: "Jurisdictions",
                keyColumn: "Code",
                keyValue: "GB");

            migrationBuilder.DeleteData(
                table: "Jurisdictions",
                keyColumn: "Code",
                keyValue: "IE");

            migrationBuilder.DeleteData(
                table: "Jurisdictions",
                keyColumn: "Code",
                keyValue: "NL");

            migrationBuilder.DeleteData(
                table: "Jurisdictions",
                keyColumn: "Code",
                keyValue: "PL");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Jurisdictions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
