using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jurisdictions",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayColor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurisdictions", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Declarations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    NetMass = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JurisdictionCode = table.Column<string>(type: "TEXT", nullable: false),
                    DeclarantId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Declarations_AspNetUsers_DeclarantId",
                        column: x => x.DeclarantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Declarations_Jurisdictions_JurisdictionCode",
                        column: x => x.JurisdictionCode,
                        principalTable: "Jurisdictions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJurisdiction",
                columns: table => new
                {
                    JurisdictionCode = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJurisdiction", x => new { x.JurisdictionCode, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserJurisdiction_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJurisdiction_Jurisdictions_JurisdictionCode",
                        column: x => x.JurisdictionCode,
                        principalTable: "Jurisdictions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Jurisdictions",
                columns: new[] { "Code", "DisplayColor" },
                values: new object[,]
                {
                    { "BE", "orange" },
                    { "DE", "olive" },
                    { "GB", "blue" },
                    { "IE", "green" },
                    { "NL", "aqua" },
                    { "PL", "red" }
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_DeclarantId",
                table: "Declarations",
                column: "DeclarantId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_JurisdictionCode",
                table: "Declarations",
                column: "JurisdictionCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserJurisdiction_UserId",
                table: "UserJurisdiction",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Declarations");

            migrationBuilder.DropTable(
                name: "UserJurisdiction");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jurisdictions");
        }
    }
}
