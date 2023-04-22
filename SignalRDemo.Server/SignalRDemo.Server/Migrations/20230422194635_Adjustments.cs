using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Adjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8f474092-4b21-40a0-a09c-a9fcc9d3fbd4", "27241cdd-e16b-4755-bb51-fd3561273c46" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94f98f25-b5b4-47e5-b7cb-4141f276b472", "ddac18d6-c588-4987-910c-2987885871f5" });

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("4408e0c5-ace9-4997-b2b1-5fdd8b3f2a6d"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("8b2d771b-2569-4799-998c-d5132e7521e2"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("bf21cda8-74f4-4d9b-b264-8aaab33c9503"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("da8b5ed7-e6e9-47c8-9072-d14e4871475a"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("e5991c07-649c-48f6-a218-1673fb3b0159"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("ecdf4745-6c8a-419f-ad47-4183e3da145b"));

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "27241cdd-e16b-4755-bb51-fd3561273c46" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "ddac18d6-c588-4987-910c-2987885871f5" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "27241cdd-e16b-4755-bb51-fd3561273c46" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "ddac18d6-c588-4987-910c-2987885871f5" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "27241cdd-e16b-4755-bb51-fd3561273c46" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "ddac18d6-c588-4987-910c-2987885871f5" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "IE", "27241cdd-e16b-4755-bb51-fd3561273c46" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "NL", "27241cdd-e16b-4755-bb51-fd3561273c46" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "PL", "27241cdd-e16b-4755-bb51-fd3561273c46" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f474092-4b21-40a0-a09c-a9fcc9d3fbd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94f98f25-b5b4-47e5-b7cb-4141f276b472");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27241cdd-e16b-4755-bb51-fd3561273c46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddac18d6-c588-4987-910c-2987885871f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "269bc825-9b13-4052-b27b-d01fb7a178ec", null, "User", "USER" },
                    { "ab67bd10-e53a-4243-8f8b-3fc664cb2e38", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a2090da3-5da7-4f2b-b473-ec31beda2fe3", 0, "d4a5ebd8-906e-42b6-a646-a448b8b485df", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEPZqloTJduiwTDWxPA3q6jW8qNqEXBhjQFPV+MiLM00me4X/xR87tNT7YCFKBcLvQQ==", null, false, "905ec33e-1c61-4cb0-9994-bb7a8d6d3ef0", false, null },
                    { "fe6df223-5926-4d16-87fd-4a085b0387a2", 0, "0544be8e-fb8b-4a8d-a50e-19aeb477e302", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEda2r/MZdZ7JA4eWisYcC+qKjkdpf/zJ0R0FXpH/0uj8BYqxofHSZdmv/PnfNQxXA==", null, false, "018bb3bf-6a78-4670-9f57-0492cd50de9e", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ab67bd10-e53a-4243-8f8b-3fc664cb2e38", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" },
                    { "269bc825-9b13-4052-b27b-d01fb7a178ec", "fe6df223-5926-4d16-87fd-4a085b0387a2" }
                });

            migrationBuilder.InsertData(
                table: "Declarations",
                columns: new[] { "Id", "CreationDate", "DeclarantId", "Description", "JurisdictionCode", "NetMass" },
                values: new object[,]
                {
                    { new Guid("075ac29f-0748-4ba4-bb3d-03dd7255bbf4"), new DateTime(2023, 4, 21, 7, 46, 34, 997, DateTimeKind.Utc).AddTicks(1448), "fe6df223-5926-4d16-87fd-4a085b0387a2", "Test GB declaration 2", "GB", 90m },
                    { new Guid("a1068e92-a463-4f18-afc1-8efb4765587b"), new DateTime(2023, 4, 22, 19, 46, 34, 997, DateTimeKind.Utc).AddTicks(1464), "fe6df223-5926-4d16-87fd-4a085b0387a2", "Test DE declaration 2", "DE", 40m },
                    { new Guid("a7fc9126-163d-43ee-a416-33130e6530b1"), new DateTime(2023, 4, 20, 19, 46, 34, 997, DateTimeKind.Utc).AddTicks(1443), "a2090da3-5da7-4f2b-b473-ec31beda2fe3", "Test BE declaration 1", "BE", 60m },
                    { new Guid("bb79903b-93ed-4b4b-98fc-56be2a3d4a7d"), new DateTime(2023, 4, 21, 19, 46, 34, 997, DateTimeKind.Utc).AddTicks(1445), "a2090da3-5da7-4f2b-b473-ec31beda2fe3", "Test DE declaration 1", "DE", 50m },
                    { new Guid("c05514d5-9a97-49a7-bd7c-c4fb420da359"), new DateTime(2023, 4, 22, 7, 46, 34, 997, DateTimeKind.Utc).AddTicks(1460), "fe6df223-5926-4d16-87fd-4a085b0387a2", "Test BE declaration 2", "BE", 70m },
                    { new Guid("ec56f512-f1be-4ae3-9fbf-3e60ea5b97c1"), new DateTime(2023, 4, 19, 19, 46, 34, 997, DateTimeKind.Utc).AddTicks(1433), "a2090da3-5da7-4f2b-b473-ec31beda2fe3", "Test GB declaration 1", "GB", 80m }
                });

            migrationBuilder.InsertData(
                table: "UserJurisdiction",
                columns: new[] { "JurisdictionCode", "UserId" },
                values: new object[,]
                {
                    { "BE", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" },
                    { "BE", "fe6df223-5926-4d16-87fd-4a085b0387a2" },
                    { "DE", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" },
                    { "DE", "fe6df223-5926-4d16-87fd-4a085b0387a2" },
                    { "GB", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" },
                    { "GB", "fe6df223-5926-4d16-87fd-4a085b0387a2" },
                    { "IE", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" },
                    { "NL", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" },
                    { "PL", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab67bd10-e53a-4243-8f8b-3fc664cb2e38", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "269bc825-9b13-4052-b27b-d01fb7a178ec", "fe6df223-5926-4d16-87fd-4a085b0387a2" });

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("075ac29f-0748-4ba4-bb3d-03dd7255bbf4"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("a1068e92-a463-4f18-afc1-8efb4765587b"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("a7fc9126-163d-43ee-a416-33130e6530b1"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("bb79903b-93ed-4b4b-98fc-56be2a3d4a7d"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("c05514d5-9a97-49a7-bd7c-c4fb420da359"));

            migrationBuilder.DeleteData(
                table: "Declarations",
                keyColumn: "Id",
                keyValue: new Guid("ec56f512-f1be-4ae3-9fbf-3e60ea5b97c1"));

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "BE", "fe6df223-5926-4d16-87fd-4a085b0387a2" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "DE", "fe6df223-5926-4d16-87fd-4a085b0387a2" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "GB", "fe6df223-5926-4d16-87fd-4a085b0387a2" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "IE", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "NL", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" });

            migrationBuilder.DeleteData(
                table: "UserJurisdiction",
                keyColumns: new[] { "JurisdictionCode", "UserId" },
                keyValues: new object[] { "PL", "a2090da3-5da7-4f2b-b473-ec31beda2fe3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "269bc825-9b13-4052-b27b-d01fb7a178ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab67bd10-e53a-4243-8f8b-3fc664cb2e38");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2090da3-5da7-4f2b-b473-ec31beda2fe3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe6df223-5926-4d16-87fd-4a085b0387a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f474092-4b21-40a0-a09c-a9fcc9d3fbd4", null, "Administrator", "ADMINISTRATOR" },
                    { "94f98f25-b5b4-47e5-b7cb-4141f276b472", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "27241cdd-e16b-4755-bb51-fd3561273c46", 0, "f538b547-7379-4008-9eaf-fcf4a2f8c712", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAED+PWgXpTB3fczGEFMc8PZ3Nn/Yh7ZcuY5Z2HYN5PL1McZJLY0P+iB5VUPOZ82zlbw==", null, false, "50b1279f-aaaf-45ae-8420-291025a93021", false, null },
                    { "ddac18d6-c588-4987-910c-2987885871f5", 0, "68f136c5-cd51-429a-860f-c567ba8a6390", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHloJAcjpcRBtbgok+GHRFJWn4KFrYunp8gNG3OuQhoEqh1RRINzhVIKH63VPDAzaQ==", null, false, "2024f74e-57c8-4ee5-8695-6897e34a151e", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8f474092-4b21-40a0-a09c-a9fcc9d3fbd4", "27241cdd-e16b-4755-bb51-fd3561273c46" },
                    { "94f98f25-b5b4-47e5-b7cb-4141f276b472", "ddac18d6-c588-4987-910c-2987885871f5" }
                });

            migrationBuilder.InsertData(
                table: "Declarations",
                columns: new[] { "Id", "CreationDate", "DeclarantId", "Description", "JurisdictionCode", "NetMass" },
                values: new object[,]
                {
                    { new Guid("4408e0c5-ace9-4997-b2b1-5fdd8b3f2a6d"), new DateTime(2023, 4, 22, 18, 58, 51, 393, DateTimeKind.Utc).AddTicks(8383), "ddac18d6-c588-4987-910c-2987885871f5", "Test DE declaration 2", "DE", 40m },
                    { new Guid("8b2d771b-2569-4799-998c-d5132e7521e2"), new DateTime(2023, 4, 20, 18, 58, 51, 393, DateTimeKind.Utc).AddTicks(8237), "27241cdd-e16b-4755-bb51-fd3561273c46", "Test BE declaration 1", "BE", 60m },
                    { new Guid("bf21cda8-74f4-4d9b-b264-8aaab33c9503"), new DateTime(2023, 4, 21, 18, 58, 51, 393, DateTimeKind.Utc).AddTicks(8241), "27241cdd-e16b-4755-bb51-fd3561273c46", "Test DE declaration 1", "DE", 50m },
                    { new Guid("da8b5ed7-e6e9-47c8-9072-d14e4871475a"), new DateTime(2023, 4, 22, 6, 58, 51, 393, DateTimeKind.Utc).AddTicks(8376), "ddac18d6-c588-4987-910c-2987885871f5", "Test BE declaration 2", "BE", 70m },
                    { new Guid("e5991c07-649c-48f6-a218-1673fb3b0159"), new DateTime(2023, 4, 21, 6, 58, 51, 393, DateTimeKind.Utc).AddTicks(8253), "ddac18d6-c588-4987-910c-2987885871f5", "Test GB declaration 2", "GB", 90m },
                    { new Guid("ecdf4745-6c8a-419f-ad47-4183e3da145b"), new DateTime(2023, 4, 19, 18, 58, 51, 393, DateTimeKind.Utc).AddTicks(8225), "27241cdd-e16b-4755-bb51-fd3561273c46", "Test GB declaration 1", "GB", 80m }
                });

            migrationBuilder.InsertData(
                table: "UserJurisdiction",
                columns: new[] { "JurisdictionCode", "UserId" },
                values: new object[,]
                {
                    { "BE", "27241cdd-e16b-4755-bb51-fd3561273c46" },
                    { "BE", "ddac18d6-c588-4987-910c-2987885871f5" },
                    { "DE", "27241cdd-e16b-4755-bb51-fd3561273c46" },
                    { "DE", "ddac18d6-c588-4987-910c-2987885871f5" },
                    { "GB", "27241cdd-e16b-4755-bb51-fd3561273c46" },
                    { "GB", "ddac18d6-c588-4987-910c-2987885871f5" },
                    { "IE", "27241cdd-e16b-4755-bb51-fd3561273c46" },
                    { "NL", "27241cdd-e16b-4755-bb51-fd3561273c46" },
                    { "PL", "27241cdd-e16b-4755-bb51-fd3561273c46" }
                });
        }
    }
}
