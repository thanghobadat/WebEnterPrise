using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
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
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
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
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    View = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Like = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Dislike = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 21, 17, 2, 32, 491, DateTimeKind.Local).AddTicks(9345)),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 28, 17, 2, 32, 492, DateTimeKind.Local).AddTicks(8132)),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 4, 17, 2, 32, 492, DateTimeKind.Local).AddTicks(8573)),
                    IsAnonymously = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdeaCategories",
                columns: table => new
                {
                    IdeaId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaCategories", x => new { x.IdeaId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_IdeaCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaCategories_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnonymously = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdeaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("f5a907e7-bbee-40a5-9d35-8ee97fd67843"), "9a111c00-c547-4876-8bd8-a39170f5c3f0", "Administrator role", "admin", "admin" },
                    { new Guid("f1edecfd-58b9-4a2b-b52c-d4b138741dce"), "46abd5b0-5938-4da1-b9b0-a51ed9da6bed", "QA Manager role", "QAManager", "QAManager" },
                    { new Guid("3146da19-a31b-4026-86fb-ea519d9d108b"), "01877eb9-ed4c-4c98-8997-e7481f89f6ca", "QA Coordinator role", "QACoordinator", "QACoordinator" },
                    { new Guid("28f8ceb5-928d-4c55-845b-3a15d89d9311"), "f6120c0f-aceb-4050-8ef7-7e7c96aaf0bd", "Staff role", "staff", "staff" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f5a907e7-bbee-40a5-9d35-8ee97fd67843"), new Guid("56030beb-f704-4dd6-b237-7c9178273a22") },
                    { new Guid("f1edecfd-58b9-4a2b-b52c-d4b138741dce"), new Guid("2307dac6-95ba-4840-b22a-10ce96275c2d") },
                    { new Guid("3146da19-a31b-4026-86fb-ea519d9d108b"), new Guid("b5a5d948-391f-42e3-8db9-6f07c570a8e2") },
                    { new Guid("3146da19-a31b-4026-86fb-ea519d9d108b"), new Guid("dc42a35f-bf6b-4aee-b0a7-c95b64159f81") },
                    { new Guid("28f8ceb5-928d-4c55-845b-3a15d89d9311"), new Guid("d3bba69e-3468-40a2-9eea-fa596e3fee15") },
                    { new Guid("28f8ceb5-928d-4c55-845b-3a15d89d9311"), new Guid("7ebb5441-a0f3-423c-8fe1-4666aaf569b7") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("56030beb-f704-4dd6-b237-7c9178273a22"), 0, "ba4c6034-ecae-4b2b-918a-2a457764e84c", new DateTime(2022, 2, 21, 17, 2, 32, 519, DateTimeKind.Local).AddTicks(2016), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "admin", "AQAAAAEAACcQAAAAEFtMIuy/AkkYidDZ57DCrQVTrSwZSi8dCTVQNpo+XvvjLpuJGGVHzx5K4vB4OT9dsA==", "0123", false, "", false, "admin" },
                    { new Guid("2307dac6-95ba-4840-b22a-10ce96275c2d"), 0, "afe81ee4-fdc0-4f39-a77d-9a2de32b7589", new DateTime(2022, 2, 21, 17, 2, 32, 526, DateTimeKind.Local).AddTicks(4437), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "manager", "AQAAAAEAACcQAAAAENYHVVHPuCa6x7U322TUyM9vI9poeV59NAWXhA0NmRCEveY8ND4nM8WttxsOtnviGQ==", "0123", false, "", false, "manager" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Academic Department", "Academic" },
                    { 2, "This is Support Department", "Support" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("b5a5d948-391f-42e3-8db9-6f07c570a8e2"), 0, "d72cbe06-5cd3-41a8-a489-279da7dcf078", new DateTime(2022, 2, 21, 17, 2, 32, 533, DateTimeKind.Local).AddTicks(2838), 1, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "QACoordinatorAcademic", "AQAAAAEAACcQAAAAEDDp2eWbFjcZ1VeBDhr468fQg85oP+KHA5yRaNtBO0C4okGHg/inQ7BY6WKXscmxNA==", "0123", false, "", false, "QACoordinatorAcademic" },
                    { new Guid("d3bba69e-3468-40a2-9eea-fa596e3fee15"), 0, "069c147f-d412-4f23-a705-8e9fa7823a86", new DateTime(2022, 2, 21, 17, 2, 32, 547, DateTimeKind.Local).AddTicks(1887), 1, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "StaffAcademic", "AQAAAAEAACcQAAAAEIgaz3hVLJixuu3yJxRcwWogsyGnYgHKNxvIugo9cJwtRbUJNYgmYdiaPhqMIlDprw==", "0123", false, "", false, "StaffAcademic" },
                    { new Guid("dc42a35f-bf6b-4aee-b0a7-c95b64159f81"), 0, "22f0868d-e30a-40f6-bd67-efdf48588a7e", new DateTime(2022, 2, 21, 17, 2, 32, 540, DateTimeKind.Local).AddTicks(2130), 2, "hungnd342000@gmail.com", true, false, null, "hungnd342000@gmail.com", "QACoordinatorSupport", "AQAAAAEAACcQAAAAEF5NMJUrrKxKtjFUnhe5bVqGo3UFytX5696dDbXwVs7yr6zak21Tw2LNKNTfInR6Qg==", "0123", false, "", false, "QACoordinatorSupport" },
                    { new Guid("7ebb5441-a0f3-423c-8fe1-4666aaf569b7"), 0, "5e504b08-847e-419e-a579-36c6a51ca883", new DateTime(2022, 2, 21, 17, 2, 32, 554, DateTimeKind.Local).AddTicks(190), 2, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "StaffSupport", "AQAAAAEAACcQAAAAENyhQkOyVY+XRFfkjMEikGx2PjrCIhUHE8cccugQKBeakBMkM7E4d6hgM3NsWANHDw==", "0123", false, "", false, "StaffSupport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_DepartmentId",
                table: "AppUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IdeaId",
                table: "Comments",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaCategories_CategoryId",
                table: "IdeaCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "IdeaCategories");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
