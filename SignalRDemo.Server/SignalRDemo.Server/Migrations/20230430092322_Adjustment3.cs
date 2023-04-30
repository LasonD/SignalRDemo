using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Adjustment3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "6a5cefd6-9197-4b82-90f5-751ac32e909b", null, "User", "USER" },
                    { "6f8bb596-5ade-4a78-87a1-bde268da5229", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e2f4b95-db12-4f0e-a5ec-369458b14e5d", 0, "3f2e74c0-1fe6-4e75-a5bf-ba39de6e13a2", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEG62zFvxQxYBwCcTkbSc3sVlkvrPlLDsdefLdp2HWPk7P4V0cJzX4IlqVpwFdMsPww==", null, false, "276a6fd5-622c-4dd6-b692-b96919e73be2", false, null },
                    { "76ca7449-97ce-49a2-83bc-2707b0f37ce7", 0, "4ac549a5-a92f-4c56-9b15-7a15b11d487b", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEAfF7MimJiiuKRkAA9AcYe7/Bgvw/9mwIX1zjkXGzVV+eYrolyz0JVcxYhBIO0sO1g==", null, false, "ed9bdd11-68dc-4299-afb7-75b45e9986e0", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6a5cefd6-9197-4b82-90f5-751ac32e909b", "1e2f4b95-db12-4f0e-a5ec-369458b14e5d" },
                    { "6f8bb596-5ade-4a78-87a1-bde268da5229", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" }
                });

            migrationBuilder.InsertData(
                table: "Declarations",
                columns: new[] { "Id", "CreationDate", "DeclarantId", "Description", "JurisdictionCode", "NetMass" },
                values: new object[,]
                {
                    { "00f63ff3-9957-494e-b799-b06be8aeaa9d", new DateTime(2023, 4, 28, 9, 23, 22, 64, DateTimeKind.Utc).AddTicks(2513), "76ca7449-97ce-49a2-83bc-2707b0f37ce7", "Test BE declaration 1", "BE", 60m },
                    { "1dac13ed-ef79-42c9-90d3-7777776ff00f", new DateTime(2023, 4, 29, 9, 23, 22, 64, DateTimeKind.Utc).AddTicks(2518), "76ca7449-97ce-49a2-83bc-2707b0f37ce7", "Test DE declaration 1", "DE", 50m },
                    { "4971ee15-f448-468b-8bcf-b315cc40bac5", new DateTime(2023, 4, 27, 9, 23, 22, 64, DateTimeKind.Utc).AddTicks(2500), "76ca7449-97ce-49a2-83bc-2707b0f37ce7", "Test GB declaration 1", "GB", 80m },
                    { "75ce3ab6-8e52-4216-9c7d-ab350da87fbd", new DateTime(2023, 4, 28, 21, 23, 22, 64, DateTimeKind.Utc).AddTicks(2522), "1e2f4b95-db12-4f0e-a5ec-369458b14e5d", "Test GB declaration 2", "GB", 90m },
                    { "c1e70986-448a-4879-8cec-2e0625613f4b", new DateTime(2023, 4, 29, 21, 23, 22, 64, DateTimeKind.Utc).AddTicks(2526), "1e2f4b95-db12-4f0e-a5ec-369458b14e5d", "Test BE declaration 2", "BE", 70m },
                    { "ee1254a7-fbaa-427c-915d-97dcbce198c0", new DateTime(2023, 4, 30, 9, 23, 22, 64, DateTimeKind.Utc).AddTicks(2531), "1e2f4b95-db12-4f0e-a5ec-369458b14e5d", "Test DE declaration 2", "DE", 40m }
                });

            migrationBuilder.InsertData(
                table: "UserJurisdiction",
                columns: new[] { "JurisdictionCode", "UserId" },
                values: new object[,]
                {
                    { "BE", "1e2f4b95-db12-4f0e-a5ec-369458b14e5d" },
                    { "BE", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" },
                    { "DE", "1e2f4b95-db12-4f0e-a5ec-369458b14e5d" },
                    { "DE", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" },
                    { "GB", "1e2f4b95-db12-4f0e-a5ec-369458b14e5d" },
                    { "GB", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" },
                    { "IE", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" },
                    { "NL", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" },
                    { "PL", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a5cefd6-9197-4b82-90f5-751ac32e909b", "1e2f4b95-db12-4f0e-a5ec-369458b14e5d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6f8bb596-5ade-4a78-87a1-bde268da5229", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" });

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "00f63ff3-9957-494e-b799-b06be8aeaa9d");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "1dac13ed-ef79-42c9-90d3-7777776ff00f");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "4971ee15-f448-468b-8bcf-b315cc40bac5");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "75ce3ab6-8e52-4216-9c7d-ab350da87fbd");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "c1e70986-448a-4879-8cec-2e0625613f4b");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "ee1254a7-fbaa-427c-915d-97dcbce198c0");

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "1e2f4b95-db12-4f0e-a5ec-369458b14e5d" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "1e2f4b95-db12-4f0e-a5ec-369458b14e5d" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "1e2f4b95-db12-4f0e-a5ec-369458b14e5d" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "IE", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "NL", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "PL", "76ca7449-97ce-49a2-83bc-2707b0f37ce7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a5cefd6-9197-4b82-90f5-751ac32e909b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f8bb596-5ade-4a78-87a1-bde268da5229");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e2f4b95-db12-4f0e-a5ec-369458b14e5d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76ca7449-97ce-49a2-83bc-2707b0f37ce7");

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
    }
}
