using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Adjustment6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1b5781f6-0247-4f6f-8504-46466c1297fb", null, "Administrator", "ADMINISTRATOR" },
                    { "fc7c8015-1349-4eff-bd1a-1e843dc3a892", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "42d4b7bb-4e69-4663-9f15-1c28378d2811", 0, "193ec07e-6585-4597-b844-f441c8553fe1", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEIV2Hpbrp6V75LP6hkAojnsOq0RTpYDLQafiSSUhSb5TYxhc/9ISUUX5uw9402dhYA==", null, false, "17d62c49-6f7d-4458-9dfb-da67d5cdd594", false, null },
                    { "b5a4c411-f70a-4fc4-9304-8ae1f9cde910", 0, "dd9dc2cb-8d59-4e92-84f0-bcb7fa3e20b0", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPbEtWjSh511Lbq3oBBcZVjifO5Aww2ICJudd4B7Q//MHbNLk3OCki6UTOE0eykklw==", null, false, "13cf3400-d6f4-4a4d-a6ce-d68b6ad6d8f3", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1b5781f6-0247-4f6f-8504-46466c1297fb", "42d4b7bb-4e69-4663-9f15-1c28378d2811" },
                    { "fc7c8015-1349-4eff-bd1a-1e843dc3a892", "b5a4c411-f70a-4fc4-9304-8ae1f9cde910" }
                });

            migrationBuilder.InsertData(
                table: "Declarations",
                columns: new[] { "Id", "CreationDate", "DeclarantId", "Description", "JurisdictionCode", "LastUpdatedDate", "NetMass" },
                values: new object[,]
                {
                    { "026f15f5-2b09-4f04-bd9e-18966e566ccf", new DateTime(2023, 4, 28, 16, 22, 49, 892, DateTimeKind.Utc).AddTicks(8052), "42d4b7bb-4e69-4663-9f15-1c28378d2811", "Test BE declaration 1", "BE", null, 60m },
                    { "447e26c9-d82a-4877-a765-af458764832f", new DateTime(2023, 4, 30, 16, 22, 49, 892, DateTimeKind.Utc).AddTicks(8086), "b5a4c411-f70a-4fc4-9304-8ae1f9cde910", "Test DE declaration 2", "DE", null, 40m },
                    { "6b37c62c-c63a-43f9-80c6-fdcff4313a1a", new DateTime(2023, 4, 29, 16, 22, 49, 892, DateTimeKind.Utc).AddTicks(8056), "42d4b7bb-4e69-4663-9f15-1c28378d2811", "Test DE declaration 1", "DE", null, 50m },
                    { "aea78a7f-df93-432a-a641-aa22095b9f10", new DateTime(2023, 4, 29, 4, 22, 49, 892, DateTimeKind.Utc).AddTicks(8077), "b5a4c411-f70a-4fc4-9304-8ae1f9cde910", "Test GB declaration 2", "GB", null, 90m },
                    { "cf9404a5-8e0d-4fc2-9f85-f51c5c22ac6a", new DateTime(2023, 4, 27, 16, 22, 49, 892, DateTimeKind.Utc).AddTicks(8027), "42d4b7bb-4e69-4663-9f15-1c28378d2811", "Test GB declaration 1", "GB", null, 80m },
                    { "fbeace8f-e3ab-46ba-8ada-3a27a6e13773", new DateTime(2023, 4, 30, 4, 22, 49, 892, DateTimeKind.Utc).AddTicks(8081), "b5a4c411-f70a-4fc4-9304-8ae1f9cde910", "Test BE declaration 2", "BE", null, 70m }
                });

            migrationBuilder.InsertData(
                table: "UserJurisdiction",
                columns: new[] { "JurisdictionCode", "UserId" },
                values: new object[,]
                {
                    { "BE", "42d4b7bb-4e69-4663-9f15-1c28378d2811" },
                    { "BE", "b5a4c411-f70a-4fc4-9304-8ae1f9cde910" },
                    { "DE", "42d4b7bb-4e69-4663-9f15-1c28378d2811" },
                    { "DE", "b5a4c411-f70a-4fc4-9304-8ae1f9cde910" },
                    { "GB", "42d4b7bb-4e69-4663-9f15-1c28378d2811" },
                    { "GB", "b5a4c411-f70a-4fc4-9304-8ae1f9cde910" },
                    { "IE", "42d4b7bb-4e69-4663-9f15-1c28378d2811" },
                    { "NL", "42d4b7bb-4e69-4663-9f15-1c28378d2811" },
                    { "PL", "42d4b7bb-4e69-4663-9f15-1c28378d2811" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1b5781f6-0247-4f6f-8504-46466c1297fb", "42d4b7bb-4e69-4663-9f15-1c28378d2811" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc7c8015-1349-4eff-bd1a-1e843dc3a892", "b5a4c411-f70a-4fc4-9304-8ae1f9cde910" });

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "026f15f5-2b09-4f04-bd9e-18966e566ccf");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "447e26c9-d82a-4877-a765-af458764832f");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "6b37c62c-c63a-43f9-80c6-fdcff4313a1a");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "aea78a7f-df93-432a-a641-aa22095b9f10");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "cf9404a5-8e0d-4fc2-9f85-f51c5c22ac6a");

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: "fbeace8f-e3ab-46ba-8ada-3a27a6e13773");

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "42d4b7bb-4e69-4663-9f15-1c28378d2811" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "b5a4c411-f70a-4fc4-9304-8ae1f9cde910" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "42d4b7bb-4e69-4663-9f15-1c28378d2811" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "b5a4c411-f70a-4fc4-9304-8ae1f9cde910" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "42d4b7bb-4e69-4663-9f15-1c28378d2811" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "b5a4c411-f70a-4fc4-9304-8ae1f9cde910" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "IE", "42d4b7bb-4e69-4663-9f15-1c28378d2811" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "NL", "42d4b7bb-4e69-4663-9f15-1c28378d2811" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "PL", "42d4b7bb-4e69-4663-9f15-1c28378d2811" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b5781f6-0247-4f6f-8504-46466c1297fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc7c8015-1349-4eff-bd1a-1e843dc3a892");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42d4b7bb-4e69-4663-9f15-1c28378d2811");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5a4c411-f70a-4fc4-9304-8ae1f9cde910");

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
    }
}
