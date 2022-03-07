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
                    Like = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Dislike = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 6, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(164)),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 13, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(8667)),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 3, 17, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(9077)),
                    IsAnonymously = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7f7f2580-651e-47e5-a9d8-6e8a90f4e64f"), "621e1073-d909-4343-9932-b56d9e0ec7b5", "Administrator role", "admin", "admin" },
                    { new Guid("923cbd1d-3d58-44f5-9f8f-707a8edd6249"), "0a752d20-bba4-4ddf-a274-4f416ad6d0f3", "QA Manager role", "QAManager", "QAManager" },
                    { new Guid("83a226a5-f7c7-4fc5-83ff-bdd88019f98d"), "69ce8cba-bd70-40ac-9421-3a92e5e0830a", "QA Coordinator role", "QACoordinator", "QACoordinator" },
                    { new Guid("1e84833f-96af-4611-9684-49de78cfc897"), "31c20564-1e83-4f12-b66a-88fb4c4bc878", "Staff role", "staff", "staff" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7f7f2580-651e-47e5-a9d8-6e8a90f4e64f"), new Guid("73e15ce4-064b-446a-9005-1c3687b55db3") },
                    { new Guid("923cbd1d-3d58-44f5-9f8f-707a8edd6249"), new Guid("20f0e1c0-9e73-48cd-b863-9d4d2aa3d6e8") },
                    { new Guid("83a226a5-f7c7-4fc5-83ff-bdd88019f98d"), new Guid("f05890a2-fe56-4f77-9470-b893c36db0ff") },
                    { new Guid("83a226a5-f7c7-4fc5-83ff-bdd88019f98d"), new Guid("ede32135-4ebf-4455-93fa-fcaaf8e55dfc") },
                    { new Guid("1e84833f-96af-4611-9684-49de78cfc897"), new Guid("a6a5acd3-f702-4c5e-a2b8-332c05ec1e26") },
                    { new Guid("1e84833f-96af-4611-9684-49de78cfc897"), new Guid("fd4d8a74-d342-43a6-9729-7a8e3332a5ce") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("73e15ce4-064b-446a-9005-1c3687b55db3"), 0, "fa88e41d-5ffa-4ff1-936c-ef0608566aef", new DateTime(2022, 3, 6, 10, 2, 48, 503, DateTimeKind.Local).AddTicks(3529), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "admin", "AQAAAAEAACcQAAAAEI8pdBm1uoXjJeThv49Cu9lEr336UP9Dbr/Rq+ggi1iUxysypXsdekbModISvbW64Q==", "0123", false, "", false, "admin" },
                    { new Guid("20f0e1c0-9e73-48cd-b863-9d4d2aa3d6e8"), 0, "d9295411-02bd-444c-aed0-f45b9ce78300", new DateTime(2022, 3, 6, 10, 2, 48, 510, DateTimeKind.Local).AddTicks(4630), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "manager", "AQAAAAEAACcQAAAAELVymqeEKFo/S6TLFOHKAwroGzoaIi/dl7XUNWYevl2M5M1GOKMb0vJHJC9SnPLv2A==", "0123", false, "", false, "manager" }
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
                    { new Guid("f05890a2-fe56-4f77-9470-b893c36db0ff"), 0, "8f725e1d-cbcf-4d4c-957a-6e7d2068a8e7", new DateTime(2022, 3, 6, 10, 2, 48, 517, DateTimeKind.Local).AddTicks(2550), 1, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "QACoordinatorAcademic", "AQAAAAEAACcQAAAAEFnwkUM6YTczF89EikbuuTN9HYDdjnWVbyHc37aN46eFQRd/6WnhxA/EYYWdEQLdZw==", "0123", false, "", false, "QACoordinatorAcademic" },
                    { new Guid("a6a5acd3-f702-4c5e-a2b8-332c05ec1e26"), 0, "a5dfc807-ef69-418f-849f-c13cf03436eb", new DateTime(2022, 3, 6, 10, 2, 48, 530, DateTimeKind.Local).AddTicks(8965), 1, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "StaffAcademic", "AQAAAAEAACcQAAAAEC4gU1d1pCgMbdipgzo+1r7Jt4NCpxHhB1IbCt5R6gfCUdUzkKHlJi6kMO+GkuDdGA==", "0123", false, "", false, "StaffAcademic" },
                    { new Guid("ede32135-4ebf-4455-93fa-fcaaf8e55dfc"), 0, "0e3a00c1-71bc-402d-bbd5-cb43dddfb07f", new DateTime(2022, 3, 6, 10, 2, 48, 524, DateTimeKind.Local).AddTicks(1208), 2, "hungnd342000@gmail.com", true, false, null, "hungnd342000@gmail.com", "QACoordinatorSupport", "AQAAAAEAACcQAAAAEKN33kxPdxfsDitowktA9+PG+rONImLvb2J1wOWJ6G4JzUQJWfapPF08k/gQbpUaTA==", "0123", false, "", false, "QACoordinatorSupport" },
                    { new Guid("fd4d8a74-d342-43a6-9729-7a8e3332a5ce"), 0, "97ff8f3d-6e42-49bc-98a3-54c9bff2ce20", new DateTime(2022, 3, 6, 10, 2, 48, 537, DateTimeKind.Local).AddTicks(6679), 2, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "StaffSupport", "AQAAAAEAACcQAAAAECUui9R+8NJQp8wZHBXZUcZbsfNyjb9TI8jieBGvlkBwCnv+1CP9P8a6aA7qp5Y1rw==", "0123", false, "", false, "StaffSupport" }
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
                name: "IX_Ideas_UserId",
                table: "Ideas",
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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
