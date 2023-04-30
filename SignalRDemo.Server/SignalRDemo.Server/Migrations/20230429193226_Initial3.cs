using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SignalRDemo.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
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
                    Id = table.Column<string>(type: "TEXT", nullable: false),
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
