using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                });

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
                name: "MailSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailSettings", x => x.Id);
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
                name: "Ideas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    View = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 22, 12, 52, 4, 169, DateTimeKind.Local).AddTicks(3253)),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 29, 12, 52, 4, 170, DateTimeKind.Local).AddTicks(1608)),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 2, 12, 52, 4, 170, DateTimeKind.Local).AddTicks(2048)),
                    IsAnonymously = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ideas_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ideas_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
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
                name: "LikeOrDislikes",
                columns: table => new
                {
                    IdeaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLike = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsDislike = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeOrDislikes", x => new { x.IdeaId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LikeOrDislikes_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LikeOrDislikes_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AcademicYears",
                columns: new[] { "Id", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sprint 2022", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer 2022", new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("53d78053-d999-4fd3-a14d-50e476960cca"), "ddce15fc-e12c-4bbf-98e8-e5f20f42b002", "Administrator role", "admin", "admin" },
                    { new Guid("25c55e6a-d027-4fc9-a4cd-ed7eca4a7067"), "2f8175db-f4b1-43c2-bc54-ab7e3a1c5efe", "QA Manager role", "QAManager", "QAManager" },
                    { new Guid("1e275fdf-041e-4c60-a750-4d3ec08cf947"), "069a4467-7383-4caf-b0a1-e0e9937a44d5", "QA Coordinator role", "QACoordinator", "QACoordinator" },
                    { new Guid("1a63efbd-8a4b-4cab-8aa2-23886aeeb5f2"), "ba3c0e3c-23ce-4c77-a54b-97348e94b256", "Staff role", "staff", "staff" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("53d78053-d999-4fd3-a14d-50e476960cca"), new Guid("558b81cc-9376-49c4-8f82-467988807134") },
                    { new Guid("25c55e6a-d027-4fc9-a4cd-ed7eca4a7067"), new Guid("e208e482-4dfb-4a49-bc41-f8a5abbe5f91") },
                    { new Guid("1e275fdf-041e-4c60-a750-4d3ec08cf947"), new Guid("0e2066a4-ff28-4f4d-83dc-ea14ce13ea18") },
                    { new Guid("1e275fdf-041e-4c60-a750-4d3ec08cf947"), new Guid("ddb5db77-b6b3-470a-9af1-ee5af8a99928") },
                    { new Guid("1a63efbd-8a4b-4cab-8aa2-23886aeeb5f2"), new Guid("efb6f2bb-b30a-49ae-9ab4-fe76ed16885e") },
                    { new Guid("1a63efbd-8a4b-4cab-8aa2-23886aeeb5f2"), new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("558b81cc-9376-49c4-8f82-467988807134"), 0, "10421817-1b88-44b5-83f1-145184c20b9a", new DateTime(2022, 3, 22, 12, 52, 4, 194, DateTimeKind.Local).AddTicks(9162), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "admin", "AQAAAAEAACcQAAAAEHPeIfPmTAYJqrVo5OaqNqbkGqDP7eyZ261h5ZuO7Pzh7vt4uxZCz7hpsXatrit80w==", "0123", false, "", false, "admin" },
                    { new Guid("e208e482-4dfb-4a49-bc41-f8a5abbe5f91"), 0, "0f3e4549-b85f-4844-88ce-64ce01a62c95", new DateTime(2022, 3, 22, 12, 52, 4, 201, DateTimeKind.Local).AddTicks(9387), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "manager", "AQAAAAEAACcQAAAAEIdw4WHocFRDyC4J7QpvxNagVt9NVTCEiHGOc7Ep6UkorcmdOaZoS60Jf8QZeJTutg==", "0123", false, "", false, "manager" }
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
                    { new Guid("0e2066a4-ff28-4f4d-83dc-ea14ce13ea18"), 0, "81db2eaa-3cab-4bb5-8836-313cb742627f", new DateTime(2022, 3, 22, 12, 52, 4, 208, DateTimeKind.Local).AddTicks(7193), 1, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "QACoordinatorAcademic", "AQAAAAEAACcQAAAAEGLftVUgxnOWlhzgQEZdiy01xP1DDJ3qao9UClKWAr9DaD7EUcDkXY87Gfpe1Cu7tQ==", "0123", false, "", false, "QACoordinatorAcademic" },
                    { new Guid("efb6f2bb-b30a-49ae-9ab4-fe76ed16885e"), 0, "b487deef-8c61-4656-9e30-62fee202c0e8", new DateTime(2022, 3, 22, 12, 52, 4, 222, DateTimeKind.Local).AddTicks(3745), 1, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "StaffAcademic", "AQAAAAEAACcQAAAAEJAX9FlCEjSKETz7I5h+298Ivnhi0jrwJxHEgXi5G7s7qoLrw27WqciJ/TBth9FJWQ==", "0123", false, "", false, "StaffAcademic" },
                    { new Guid("ddb5db77-b6b3-470a-9af1-ee5af8a99928"), 0, "c834d332-2982-429a-a60d-05154e3f68c3", new DateTime(2022, 3, 22, 12, 52, 4, 215, DateTimeKind.Local).AddTicks(5632), 2, "hungnd342000@gmail.com", true, false, null, "hungnd342000@gmail.com", "QACoordinatorSupport", "AQAAAAEAACcQAAAAEBEbwWnYtsPa4lY1xJ7VvZAWuq6+UzfhKSJ9oiNCi/RNC9u/qaIqu4/AnOEgc6xBpg==", "0123", false, "", false, "QACoordinatorSupport" },
                    { new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"), 0, "660b49c3-2270-4906-b057-8d54b5ac8927", new DateTime(2022, 3, 22, 12, 52, 4, 229, DateTimeKind.Local).AddTicks(1796), 2, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "StaffSupport", "AQAAAAEAACcQAAAAEM0PNHk0pOY3v2Z8T7pWFv9c4P+BBnVR3KjYXGpKkxluxpKkZpuWC10icflLKnl9EA==", "0123", false, "", false, "StaffSupport" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_AcademicYearId",
                table: "Ideas",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_UserId",
                table: "Ideas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeOrDislikes_UserId",
                table: "LikeOrDislikes",
                column: "UserId");
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
                name: "LikeOrDislikes");

            migrationBuilder.DropTable(
                name: "MailSettings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
