using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Adjustment4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Declarations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8249e1f0-d959-476b-a96e-eaee38b99a34", null, "Administrator", "ADMINISTRATOR" },
                    { "f315c57b-fa3a-4f28-8943-4021d2e21e27", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d638e60a-ba31-44aa-af2e-624df1bde177", 0, "ff83248c-a6f4-4934-8237-a99817397ff0", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPAoujfzckCbrth2kVHhf76M94WGa6YETTqEBD/XkIf7RLzZ21BgTRMXpbFcLNoZWQ==", null, false, "43846f31-4ab6-459e-a0f5-c989d1c87498", false, null },
                    { "ffc652f7-a045-4cba-bfba-ed8497859fff", 0, "fb5edfbd-35ad-4484-8713-0799d2fdb638", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMtKWV1N6fm40Db6Urk2MyyfcSSiPJ7OP3E+VDoylgBwB0Rlhx7uDhzUkriGu9Bb9w==", null, false, "54c59156-d073-4314-b9f3-abf4ce7f737d", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f315c57b-fa3a-4f28-8943-4021d2e21e27", "d638e60a-ba31-44aa-af2e-624df1bde177" },
                    { "8249e1f0-d959-476b-a96e-eaee38b99a34", "ffc652f7-a045-4cba-bfba-ed8497859fff" }
                });

            migrationBuilder.InsertData(
                table: "Declarations",
                columns: new[] { "Id", "CreationDate", "DeclarantId", "Description", "JurisdictionCode", "LastUpdatedDate", "NetMass" },
                values: new object[,]
                {
                    { "238c424c-09b6-4fe5-9157-7d9d9b8605f0", new DateTime(2023, 4, 28, 22, 11, 45, 481, DateTimeKind.Utc).AddTicks(7317), "d638e60a-ba31-44aa-af2e-624df1bde177", "Test GB declaration 2", "GB", null, 90m },
                    { "4410772f-43c1-44f4-8350-8ecbac745431", new DateTime(2023, 4, 27, 10, 11, 45, 481, DateTimeKind.Utc).AddTicks(7263), "ffc652f7-a045-4cba-bfba-ed8497859fff", "Test GB declaration 1", "GB", null, 80m },
                    { "50fadeab-5470-4bcb-ba81-4f57286bb91d", new DateTime(2023, 4, 28, 10, 11, 45, 481, DateTimeKind.Utc).AddTicks(7292), "ffc652f7-a045-4cba-bfba-ed8497859fff", "Test BE declaration 1", "BE", null, 60m },
                    { "954cce4e-378d-4b72-a3e0-d4232888e1d6", new DateTime(2023, 4, 29, 22, 11, 45, 481, DateTimeKind.Utc).AddTicks(7321), "d638e60a-ba31-44aa-af2e-624df1bde177", "Test BE declaration 2", "BE", null, 70m },
                    { "abb0585e-8145-46f6-bb29-29b1a8675a08", new DateTime(2023, 4, 29, 10, 11, 45, 481, DateTimeKind.Utc).AddTicks(7296), "ffc652f7-a045-4cba-bfba-ed8497859fff", "Test DE declaration 1", "DE", null, 50m },
                    { "bebed2e2-78c7-43f0-b786-0d98f273b2bf", new DateTime(2023, 4, 30, 10, 11, 45, 481, DateTimeKind.Utc).AddTicks(7326), "d638e60a-ba31-44aa-af2e-624df1bde177", "Test DE declaration 2", "DE", null, 40m }
                });

            migrationBuilder.InsertData(
                table: "UserJurisdiction",
                columns: new[] { "JurisdictionCode", "UserId" },
                values: new object[,]
                {
                    { "BE", "d638e60a-ba31-44aa-af2e-624df1bde177" },
                    { "BE", "ffc652f7-a045-4cba-bfba-ed8497859fff" },
                    { "DE", "d638e60a-ba31-44aa-af2e-624df1bde177" },
                    { "DE", "ffc652f7-a045-4cba-bfba-ed8497859fff" },
                    { "GB", "d638e60a-ba31-44aa-af2e-624df1bde177" },
                    { "GB", "ffc652f7-a045-4cba-bfba-ed8497859fff" },
                    { "IE", "ffc652f7-a045-4cba-bfba-ed8497859fff" },
                    { "NL", "ffc652f7-a045-4cba-bfba-ed8497859fff" },
                    { "PL", "ffc652f7-a045-4cba-bfba-ed8497859fff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f315c57b-fa3a-4f28-8943-4021d2e21e27", "d638e60a-ba31-44aa-af2e-624df1bde177" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8249e1f0-d959-476b-a96e-eaee38b99a34", "ffc652f7-a045-4cba-bfba-ed8497859fff" });

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "238c424c-09b6-4fe5-9157-7d9d9b8605f0");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "4410772f-43c1-44f4-8350-8ecbac745431");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "50fadeab-5470-4bcb-ba81-4f57286bb91d");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "954cce4e-378d-4b72-a3e0-d4232888e1d6");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "abb0585e-8145-46f6-bb29-29b1a8675a08");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "bebed2e2-78c7-43f0-b786-0d98f273b2bf");

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "d638e60a-ba31-44aa-af2e-624df1bde177" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "ffc652f7-a045-4cba-bfba-ed8497859fff" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "d638e60a-ba31-44aa-af2e-624df1bde177" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "ffc652f7-a045-4cba-bfba-ed8497859fff" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "d638e60a-ba31-44aa-af2e-624df1bde177" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "ffc652f7-a045-4cba-bfba-ed8497859fff" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "IE", "ffc652f7-a045-4cba-bfba-ed8497859fff" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "NL", "ffc652f7-a045-4cba-bfba-ed8497859fff" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "PL", "ffc652f7-a045-4cba-bfba-ed8497859fff" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8249e1f0-d959-476b-a96e-eaee38b99a34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f315c57b-fa3a-4f28-8943-4021d2e21e27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d638e60a-ba31-44aa-af2e-624df1bde177");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc652f7-a045-4cba-bfba-ed8497859fff");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Declarations");

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
    }
}
