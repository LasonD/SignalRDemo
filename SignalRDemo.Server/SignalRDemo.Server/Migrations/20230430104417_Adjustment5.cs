using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Adjustment5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45632f48-dc44-40af-a494-e6f4c2de1b8e", null, "User", "USER" },
                    { "be26ff94-ef6d-42b1-a9b2-f58dcc908539", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b221912-04fd-4901-8644-c8ead49dadbd", 0, "34d58936-2b3b-4f0b-a5bc-a4ff238f98da", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEButEkR/s5qZK34Qaw/ZAIXvIbCmtlYV3HAy95wJQeKb0zcQzTtDroT6dXGemTl6RQ==", null, false, "6f475b03-b110-404d-af0e-b5d1c5830cc5", false, null },
                    { "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9", 0, "30f920fd-a263-4dad-9a0e-d83333d50afb", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPCeXJRBiwxhGaTwVkZ382CBgi7LnyE6o1XwXJDoqabSqvZVtuznsa5i54mCvuF09g==", null, false, "2b4c8fbb-0bdc-460b-a5b4-2ddebe24e79e", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "45632f48-dc44-40af-a494-e6f4c2de1b8e", "1b221912-04fd-4901-8644-c8ead49dadbd" },
                    { "be26ff94-ef6d-42b1-a9b2-f58dcc908539", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" }
                });

            migrationBuilder.InsertData(
                table: "Declarations",
                columns: new[] { "Id", "CreationDate", "DeclarantId", "Description", "JurisdictionCode", "LastUpdatedDate", "NetMass" },
                values: new object[,]
                {
                    { "0cd4a98e-f18b-45a1-ba1c-fa59b45292e6", new DateTime(2023, 4, 30, 10, 44, 17, 436, DateTimeKind.Utc).AddTicks(3432), "1b221912-04fd-4901-8644-c8ead49dadbd", "Test DE declaration 2", "DE", null, 40m },
                    { "1fa27d33-7489-44b5-9e14-74533c903fb8", new DateTime(2023, 4, 29, 22, 44, 17, 436, DateTimeKind.Utc).AddTicks(3305), "1b221912-04fd-4901-8644-c8ead49dadbd", "Test BE declaration 2", "BE", null, 70m },
                    { "5cd64d9c-ad80-4e8a-8efc-79377aeaf573", new DateTime(2023, 4, 29, 10, 44, 17, 436, DateTimeKind.Utc).AddTicks(3297), "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9", "Test DE declaration 1", "DE", null, 50m },
                    { "ab4a794e-0de8-468a-b2e5-8fcf66f34f10", new DateTime(2023, 4, 28, 10, 44, 17, 436, DateTimeKind.Utc).AddTicks(3292), "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9", "Test BE declaration 1", "BE", null, 60m },
                    { "d4b59a78-dd38-4dfb-ae4c-b3d43a77dfde", new DateTime(2023, 4, 28, 22, 44, 17, 436, DateTimeKind.Utc).AddTicks(3301), "1b221912-04fd-4901-8644-c8ead49dadbd", "Test GB declaration 2", "GB", null, 90m },
                    { "f3cac9eb-c72f-4ef9-be46-a59dca7214ba", new DateTime(2023, 4, 27, 10, 44, 17, 436, DateTimeKind.Utc).AddTicks(3281), "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9", "Test GB declaration 1", "GB", null, 80m }
                });

            migrationBuilder.InsertData(
                table: "UserJurisdiction",
                columns: new[] { "JurisdictionCode", "UserId" },
                values: new object[,]
                {
                    { "BE", "1b221912-04fd-4901-8644-c8ead49dadbd" },
                    { "BE", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" },
                    { "DE", "1b221912-04fd-4901-8644-c8ead49dadbd" },
                    { "DE", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" },
                    { "GB", "1b221912-04fd-4901-8644-c8ead49dadbd" },
                    { "GB", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" },
                    { "IE", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" },
                    { "NL", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" },
                    { "PL", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45632f48-dc44-40af-a494-e6f4c2de1b8e", "1b221912-04fd-4901-8644-c8ead49dadbd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be26ff94-ef6d-42b1-a9b2-f58dcc908539", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" });

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "0cd4a98e-f18b-45a1-ba1c-fa59b45292e6");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "1fa27d33-7489-44b5-9e14-74533c903fb8");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "5cd64d9c-ad80-4e8a-8efc-79377aeaf573");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "ab4a794e-0de8-468a-b2e5-8fcf66f34f10");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "d4b59a78-dd38-4dfb-ae4c-b3d43a77dfde");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "f3cac9eb-c72f-4ef9-be46-a59dca7214ba");

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "1b221912-04fd-4901-8644-c8ead49dadbd" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "1b221912-04fd-4901-8644-c8ead49dadbd" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "1b221912-04fd-4901-8644-c8ead49dadbd" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "IE", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "NL", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "PL", "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45632f48-dc44-40af-a494-e6f4c2de1b8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be26ff94-ef6d-42b1-a9b2-f58dcc908539");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b221912-04fd-4901-8644-c8ead49dadbd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ccfa53b-6d53-4bfd-b955-6e7c42712dc9");

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
    }
}
