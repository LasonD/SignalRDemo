using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Adjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f30cfe87-b8f8-495b-857a-acd444192d34", "04fb52bc-821b-43d7-9995-576d52025a28" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0afcad75-ddf0-4062-8b40-ce1506caeda3", "36cdea02-f282-40c4-8fca-a62e62825a5c" });

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "2e6b3059-0dbd-41ed-81bd-197acee92a76");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "74e5ebab-e280-4932-8b76-99235e78b08d");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "8fc1a202-00eb-4e37-a970-57a7fdd8cd3f");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "99a24116-3fba-48e0-8256-dd08c72cfd4c");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "a5f1c866-0233-4d02-99a5-59a02a191c0f");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "b5926c56-a88c-43ef-aeb8-a87478b0f525");

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "04fb52bc-821b-43d7-9995-576d52025a28" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "36cdea02-f282-40c4-8fca-a62e62825a5c" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "04fb52bc-821b-43d7-9995-576d52025a28" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "36cdea02-f282-40c4-8fca-a62e62825a5c" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "04fb52bc-821b-43d7-9995-576d52025a28" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "36cdea02-f282-40c4-8fca-a62e62825a5c" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "IE", "36cdea02-f282-40c4-8fca-a62e62825a5c" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "NL", "36cdea02-f282-40c4-8fca-a62e62825a5c" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "PL", "36cdea02-f282-40c4-8fca-a62e62825a5c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0afcad75-ddf0-4062-8b40-ce1506caeda3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f30cfe87-b8f8-495b-857a-acd444192d34");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04fb52bc-821b-43d7-9995-576d52025a28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36cdea02-f282-40c4-8fca-a62e62825a5c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ad2adf9-0d8a-46e1-9a8f-b7d00ed08ab3", null, "User", "USER" },
                    { "50999c17-15c6-49a3-a8e7-72931ec8d839", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "07636587-5345-4130-9ec3-74c458d784ce", 0, "084972a8-1f90-4f74-8ccf-5bd98f19253c", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEB1BziAuWqUGsWvLJSp+pF16+93fjnljp1sVDNsRMwfS84USrqNg9TdqAxOceWFyCA==", null, false, "e63ba252-8355-42e4-b27d-80cc778d88d0", false, null },
                    { "76f2774d-98c5-4e8e-aee6-66194c03c16d", 0, "8717b0bc-8392-48fe-b1bd-462b91106527", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEL/z0xcQmmTq78jUt3zf1pFdKvJEyRQS55vqusaf55p72c5id0zJbwL+wtqtpNMzOQ==", null, false, "fe0b4715-463a-4929-8fa2-33e90aa07405", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0ad2adf9-0d8a-46e1-9a8f-b7d00ed08ab3", "07636587-5345-4130-9ec3-74c458d784ce" },
                    { "50999c17-15c6-49a3-a8e7-72931ec8d839", "76f2774d-98c5-4e8e-aee6-66194c03c16d" }
                });

            migrationBuilder.InsertData(
                table: "Declarations",
                columns: new[] { "Id", "CreationDate", "DeclarantId", "Description", "JurisdictionCode", "NetMass" },
                values: new object[,]
                {
                    { "167f57b9-ca9f-4a03-9639-67b1582ba449", new DateTime(2023, 4, 29, 19, 58, 13, 481, DateTimeKind.Utc).AddTicks(3850), "07636587-5345-4130-9ec3-74c458d784ce", "Test DE declaration 2", "DE", 40m },
                    { "6162a110-3105-4b43-854e-95eee46c0a83", new DateTime(2023, 4, 28, 19, 58, 13, 481, DateTimeKind.Utc).AddTicks(3665), "76f2774d-98c5-4e8e-aee6-66194c03c16d", "Test DE declaration 1", "DE", 50m },
                    { "7a9250a6-4537-4487-b174-ff8a3f76a6cc", new DateTime(2023, 4, 29, 7, 58, 13, 481, DateTimeKind.Utc).AddTicks(3844), "07636587-5345-4130-9ec3-74c458d784ce", "Test BE declaration 2", "BE", 70m },
                    { "877e122b-fba2-4870-bcc0-54a2cff9f750", new DateTime(2023, 4, 27, 19, 58, 13, 481, DateTimeKind.Utc).AddTicks(3661), "76f2774d-98c5-4e8e-aee6-66194c03c16d", "Test BE declaration 1", "BE", 60m },
                    { "8bea2dc7-3b0a-4e7e-a427-f53954f632dc", new DateTime(2023, 4, 28, 7, 58, 13, 481, DateTimeKind.Utc).AddTicks(3829), "07636587-5345-4130-9ec3-74c458d784ce", "Test GB declaration 2", "GB", 90m },
                    { "b9f69a98-c2dc-4dcd-b74f-60f9b9fa1a93", new DateTime(2023, 4, 26, 19, 58, 13, 481, DateTimeKind.Utc).AddTicks(3648), "76f2774d-98c5-4e8e-aee6-66194c03c16d", "Test GB declaration 1", "GB", 80m }
                });

            migrationBuilder.InsertData(
                table: "UserJurisdiction",
                columns: new[] { "JurisdictionCode", "UserId" },
                values: new object[,]
                {
                    { "BE", "07636587-5345-4130-9ec3-74c458d784ce" },
                    { "BE", "76f2774d-98c5-4e8e-aee6-66194c03c16d" },
                    { "DE", "07636587-5345-4130-9ec3-74c458d784ce" },
                    { "DE", "76f2774d-98c5-4e8e-aee6-66194c03c16d" },
                    { "GB", "07636587-5345-4130-9ec3-74c458d784ce" },
                    { "GB", "76f2774d-98c5-4e8e-aee6-66194c03c16d" },
                    { "IE", "76f2774d-98c5-4e8e-aee6-66194c03c16d" },
                    { "NL", "76f2774d-98c5-4e8e-aee6-66194c03c16d" },
                    { "PL", "76f2774d-98c5-4e8e-aee6-66194c03c16d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0ad2adf9-0d8a-46e1-9a8f-b7d00ed08ab3", "07636587-5345-4130-9ec3-74c458d784ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "50999c17-15c6-49a3-a8e7-72931ec8d839", "76f2774d-98c5-4e8e-aee6-66194c03c16d" });

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "167f57b9-ca9f-4a03-9639-67b1582ba449");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "6162a110-3105-4b43-854e-95eee46c0a83");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "7a9250a6-4537-4487-b174-ff8a3f76a6cc");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "877e122b-fba2-4870-bcc0-54a2cff9f750");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "8bea2dc7-3b0a-4e7e-a427-f53954f632dc");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "b9f69a98-c2dc-4dcd-b74f-60f9b9fa1a93");

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "07636587-5345-4130-9ec3-74c458d784ce" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "76f2774d-98c5-4e8e-aee6-66194c03c16d" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "07636587-5345-4130-9ec3-74c458d784ce" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "76f2774d-98c5-4e8e-aee6-66194c03c16d" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "07636587-5345-4130-9ec3-74c458d784ce" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "76f2774d-98c5-4e8e-aee6-66194c03c16d" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "IE", "76f2774d-98c5-4e8e-aee6-66194c03c16d" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "NL", "76f2774d-98c5-4e8e-aee6-66194c03c16d" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "PL", "76f2774d-98c5-4e8e-aee6-66194c03c16d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ad2adf9-0d8a-46e1-9a8f-b7d00ed08ab3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50999c17-15c6-49a3-a8e7-72931ec8d839");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07636587-5345-4130-9ec3-74c458d784ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76f2774d-98c5-4e8e-aee6-66194c03c16d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0afcad75-ddf0-4062-8b40-ce1506caeda3", null, "Administrator", "ADMINISTRATOR" },
                    { "f30cfe87-b8f8-495b-857a-acd444192d34", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04fb52bc-821b-43d7-9995-576d52025a28", 0, "3aceb061-9889-44d0-ac56-2564a574d5eb", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAi0aNGNhaKfwc1H+fsfgL6+mndNcC62SvMzImEjIdSDav+qixOajKN7JXo1DijlsQ==", null, false, "afa56254-3547-4091-9a3c-a21162eb2b4d", false, null },
                    { "36cdea02-f282-40c4-8fca-a62e62825a5c", 0, "3a522e1c-53ee-4ad2-a170-f993bc5086d5", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMf+wHQ49DWVzE83F9ymXNoK14VjhwsTvithOs/c2PA+V3TJ37001dC+o/ZUSpqltw==", null, false, "04302775-9345-4f3f-a878-9534afc539db", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f30cfe87-b8f8-495b-857a-acd444192d34", "04fb52bc-821b-43d7-9995-576d52025a28" },
                    { "0afcad75-ddf0-4062-8b40-ce1506caeda3", "36cdea02-f282-40c4-8fca-a62e62825a5c" }
                });

            migrationBuilder.InsertData(
                table: "Declarations",
                columns: new[] { "Id", "CreationDate", "DeclarantId", "Description", "JurisdictionCode", "NetMass" },
                values: new object[,]
                {
                    { "2e6b3059-0dbd-41ed-81bd-197acee92a76", new DateTime(2023, 4, 27, 19, 32, 26, 442, DateTimeKind.Utc).AddTicks(867), "36cdea02-f282-40c4-8fca-a62e62825a5c", "Test BE declaration 1", "BE", 60m },
                    { "74e5ebab-e280-4932-8b76-99235e78b08d", new DateTime(2023, 4, 28, 19, 32, 26, 442, DateTimeKind.Utc).AddTicks(874), "36cdea02-f282-40c4-8fca-a62e62825a5c", "Test DE declaration 1", "DE", 50m },
                    { "8fc1a202-00eb-4e37-a970-57a7fdd8cd3f", new DateTime(2023, 4, 29, 19, 32, 26, 442, DateTimeKind.Utc).AddTicks(913), "04fb52bc-821b-43d7-9995-576d52025a28", "Test DE declaration 2", "DE", 40m },
                    { "99a24116-3fba-48e0-8256-dd08c72cfd4c", new DateTime(2023, 4, 28, 7, 32, 26, 442, DateTimeKind.Utc).AddTicks(899), "04fb52bc-821b-43d7-9995-576d52025a28", "Test GB declaration 2", "GB", 90m },
                    { "a5f1c866-0233-4d02-99a5-59a02a191c0f", new DateTime(2023, 4, 29, 7, 32, 26, 442, DateTimeKind.Utc).AddTicks(905), "04fb52bc-821b-43d7-9995-576d52025a28", "Test BE declaration 2", "BE", 70m },
                    { "b5926c56-a88c-43ef-aeb8-a87478b0f525", new DateTime(2023, 4, 26, 19, 32, 26, 442, DateTimeKind.Utc).AddTicks(851), "36cdea02-f282-40c4-8fca-a62e62825a5c", "Test GB declaration 1", "GB", 80m }
                });

            migrationBuilder.InsertData(
                table: "UserJurisdiction",
                columns: new[] { "JurisdictionCode", "UserId" },
                values: new object[,]
                {
                    { "BE", "04fb52bc-821b-43d7-9995-576d52025a28" },
                    { "BE", "36cdea02-f282-40c4-8fca-a62e62825a5c" },
                    { "DE", "04fb52bc-821b-43d7-9995-576d52025a28" },
                    { "DE", "36cdea02-f282-40c4-8fca-a62e62825a5c" },
                    { "GB", "04fb52bc-821b-43d7-9995-576d52025a28" },
                    { "GB", "36cdea02-f282-40c4-8fca-a62e62825a5c" },
                    { "IE", "36cdea02-f282-40c4-8fca-a62e62825a5c" },
                    { "NL", "36cdea02-f282-40c4-8fca-a62e62825a5c" },
                    { "PL", "36cdea02-f282-40c4-8fca-a62e62825a5c" }
                });
        }
    }
}
