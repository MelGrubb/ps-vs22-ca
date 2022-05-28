using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Greenfield.Web.Model.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_PropertyTypes_PropertyTypeId",
                        column: x => x.PropertyTypeId,
                        principalTable: "PropertyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availabilities_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2b320ce5-2f11-41bf-7ee8-08da38685344"), 0, "eabedbb8-ff91-42db-8aff-2bb92e479b59", "greenfield.test@globomantics.com", true, false, null, "GREENFIELD.TEST@GLOBOMANTICS.COM", "GREENFIELD.TEST@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEPWmcKFWAlMNbjzMMiGqTn/jl7cOGBvgL+qMH9K+WHHxXZJnpP2xXH2nR1WSk6iGig==", null, false, "R5USH7ZAJLIAN6I4BMBUMMBLGLENARSZ", false, "greenfield.test@globomantics.com" },
                    { new Guid("47726565-6e66-6965-6c64-2041646d696e"), 0, "8c466f08-5952-4030-8314-095370e8fa5f", "greenfield.admin@globomantics.com", true, false, null, "GREENFIELD.ADMIN@GLOBOMANTICS.COM", "GREENFIELD.ADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAELLgUo3k2B/a/LRJIU5ucgdyS7oozdKeHyNikehK1tOKVpiZUgDdLlFeByjqhWXqdQ==", null, false, "BJTXU4I4ZJQKOES6TL2J5BLDWQ7ORJU4", false, "greenfield.admin@globomantics.com" }
                });

            migrationBuilder.InsertData(
                table: "PropertyTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("50726f70-6572-7479-5479-7065436c6561"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", "Cleared land, fairly flat, mowed occasionally.", "Cleared", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("50726f70-6572-7479-5479-70654d616e69"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", "A meticulously maintained meadow, matchless for meditative mollification and mitigation of metropolitan misery. May contain mosquitoes.", "Manicured", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("50726f70-6572-7479-5479-7065526f7567"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", "Raw, undeveloped prairie land. May contain gopher holes. Watch your step, and bring bug repellant.", "Rough", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "OwnerId", "PropertyTypeId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("47726565-6e66-6965-6c64-50726f703031"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", "A plain, undeveloped field to the North of Greenfield's own headquarters.", "Greenfield Property #1", new Guid("47726565-6e66-6965-6c64-2041646d696e"), new Guid("50726f70-6572-7479-5479-7065526f7567"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-50726f703032"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", "A plain, but somewhat nicer field to the East of Greenfield's own headquarters.", "Greenfield Property #2", new Guid("47726565-6e66-6965-6c64-2041646d696e"), new Guid("50726f70-6572-7479-5479-7065436c6561"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-50726f703033"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", "A flower-filled meadow on the outskirts of town to the West of Greenfield's headquarters. Far enough to escape the city, but close enough to order pizza.", "Greenfield Property #3", new Guid("47726565-6e66-6965-6c64-2041646d696e"), new Guid("50726f70-6572-7479-5479-70654d616e69"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("54657374-5573-6572-5072-6f7065723031"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", "Test User's back yard.", "Test User Property #1", new Guid("2b320ce5-2f11-41bf-7ee8-08da38685344"), new Guid("50726f70-6572-7479-5479-7065436c6561"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Id", "CheckIn", "CheckOut", "CreatedAt", "CreatedBy", "DayOfWeek", "Notes", "PropertyId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("47726565-6e66-6965-6c64-303141763031"), "3PM", "11AM", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", 5, "Friday availability at GreenfieldProperty1", new Guid("47726565-6e66-6965-6c64-50726f703031"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-303141763032"), "3PM", "11AM", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", 6, "Saturday availability at GreenfieldProperty1", new Guid("47726565-6e66-6965-6c64-50726f703031"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-303141763033"), "3PM", "11AM", new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", 0, "Sunday availability at GreenfieldProperty1", new Guid("47726565-6e66-6965-6c64-50726f703031"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "ClientId", "CreatedAt", "CreatedBy", "Date", "PropertyId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("47726565-6e66-6965-6c64-315265733031"), new Guid("2b320ce5-2f11-41bf-7ee8-08da38685344"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47726565-6e66-6965-6c64-50726f703031"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-315265733032"), new Guid("2b320ce5-2f11-41bf-7ee8-08da38685344"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47726565-6e66-6965-6c64-50726f703031"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-325265733031"), new Guid("2b320ce5-2f11-41bf-7ee8-08da38685344"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47726565-6e66-6965-6c64-50726f703032"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-325265733032"), new Guid("2b320ce5-2f11-41bf-7ee8-08da38685344"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47726565-6e66-6965-6c64-50726f703032"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-335265733031"), new Guid("2b320ce5-2f11-41bf-7ee8-08da38685344"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47726565-6e66-6965-6c64-50726f703033"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" },
                    { new Guid("47726565-6e66-6965-6c64-335265733032"), new Guid("2b320ce5-2f11-41bf-7ee8-08da38685344"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47726565-6e66-6965-6c64-50726f703033"), new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed Data" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Availabilities_PropertyId",
                table: "Availabilities",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PropertyId",
                table: "Reservations",
                column: "PropertyId");
        }

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
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PropertyTypes");
        }
    }
}
