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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Host = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Port = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    View = table.Column<int>(nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 4, 5, 8, 15, 1, 232, DateTimeKind.Local).AddTicks(352)),
                    EditDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 4, 12, 8, 15, 1, 232, DateTimeKind.Local).AddTicks(9036)),
                    FinalDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 4, 16, 8, 15, 1, 232, DateTimeKind.Local).AddTicks(9378)),
                    IsAnonymously = table.Column<bool>(nullable: false, defaultValue: false),
                    UserId = table.Column<Guid>(nullable: false),
                    AcademicYearId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: false),
                    IsAnonymously = table.Column<bool>(nullable: false, defaultValue: false),
                    IdeaId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdeaCategories",
                columns: table => new
                {
                    IdeaId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
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
                    IdeaId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsLike = table.Column<bool>(nullable: false, defaultValue: false),
                    IsDislike = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeOrDislikes", x => new { x.IdeaId, x.UserId });
                    table.ForeignKey(
                        name: "FK_LikeOrDislikes_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LikeOrDislikes_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
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
                    { new Guid("1dc1d809-44b4-41b0-adee-4d065514deac"), "951ba16b-0687-4b92-b5b2-81533f991fed", "Administrator role", "admin", "admin" },
                    { new Guid("0cbb2642-9baf-4c67-b7ac-e779725f4fde"), "49b5058f-32b2-4727-a413-205f6885207b", "QA Manager role", "QAManager", "QAManager" },
                    { new Guid("c0ae3cf5-18ad-4a30-a5d3-8e3a453f05e0"), "ac8ab307-3159-4673-be4b-580dee3725ce", "QA Coordinator role", "QACoordinator", "QACoordinator" },
                    { new Guid("3aa8dd63-ed0c-4837-b5b5-dff8baa22675"), "d5578ae0-4d0f-42c0-a587-8df2cd0caf3b", "Staff role", "staff", "staff" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("62c98f45-b822-4744-bbde-0766a031fbf5"), new Guid("1dc1d809-44b4-41b0-adee-4d065514deac") },
                    { new Guid("c05a404a-60ee-45a9-ac75-6745ff2e285c"), new Guid("0cbb2642-9baf-4c67-b7ac-e779725f4fde") },
                    { new Guid("50ae9836-3f80-4874-9602-f130c0072195"), new Guid("c0ae3cf5-18ad-4a30-a5d3-8e3a453f05e0") },
                    { new Guid("90434e7d-8dfa-44da-8839-2a478fc2145d"), new Guid("c0ae3cf5-18ad-4a30-a5d3-8e3a453f05e0") },
                    { new Guid("2ad24c53-df48-4289-8121-d4ae9e79c766"), new Guid("3aa8dd63-ed0c-4837-b5b5-dff8baa22675") },
                    { new Guid("2aac2b7a-6be4-4689-b574-c1f7eba19a3a"), new Guid("3aa8dd63-ed0c-4837-b5b5-dff8baa22675") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("62c98f45-b822-4744-bbde-0766a031fbf5"), 0, "6a934a09-cf4f-4b45-94b2-3a9d18cdc1a0", new DateTime(2022, 4, 5, 8, 15, 1, 258, DateTimeKind.Local).AddTicks(819), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "admin", "AQAAAAEAACcQAAAAEEvSetDBj51euox8sNzKgskUyhju9+otAktonhGFcwUKeGGLl+dVgwp8D1SYasK0fQ==", "0123", false, "", false, "admin" },
                    { new Guid("c05a404a-60ee-45a9-ac75-6745ff2e285c"), 0, "79e57ba7-7a36-4b21-91f7-e77431382eda", new DateTime(2022, 4, 5, 8, 15, 1, 265, DateTimeKind.Local).AddTicks(926), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "manager", "AQAAAAEAACcQAAAAEBGyo/V0XhizrelW2rr2umEzeHSO5+ENF4tKafW/c9aQNsOQ4HlV40vqbVuYmjFOHg==", "0123", false, "", false, "manager" }
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
                    { new Guid("50ae9836-3f80-4874-9602-f130c0072195"), 0, "0b5dce54-e06d-42e3-8e77-e6de719a8542", new DateTime(2022, 4, 5, 8, 15, 1, 271, DateTimeKind.Local).AddTicks(8995), 1, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "QACoordinatorAcademic", "AQAAAAEAACcQAAAAEC2mAU6VwU81zZC+tYMLDJAmSuv2YvmmPuntTXCRaQ3YpSLzck1o1t4VoT88KNdvow==", "0123", false, "", false, "QACoordinatorAcademic" },
                    { new Guid("2ad24c53-df48-4289-8121-d4ae9e79c766"), 0, "624bf962-bee5-4ef6-b328-5ab82730d3ce", new DateTime(2022, 4, 5, 8, 15, 1, 285, DateTimeKind.Local).AddTicks(6271), 1, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "StaffAcademic", "AQAAAAEAACcQAAAAEMb/7s8j188udRlsaLHQZWJNe5/1N9FGYaf1OqjqYnW7PkPnGcyyHmFcV8d3q7fk4A==", "0123", false, "", false, "StaffAcademic" },
                    { new Guid("90434e7d-8dfa-44da-8839-2a478fc2145d"), 0, "a0b9651c-93bb-438b-949c-315ad9df846f", new DateTime(2022, 4, 5, 8, 15, 1, 278, DateTimeKind.Local).AddTicks(7983), 2, "hungnd342000@gmail.com", true, false, null, "hungnd342000@gmail.com", "QACoordinatorSupport", "AQAAAAEAACcQAAAAEFIMKDJvVZE46b7JEulnvR0lXPfeq0KnqA94ERTrbflcp68DN/ADDdQMtJRLf8TrEw==", "0123", false, "", false, "QACoordinatorSupport" },
                    { new Guid("2aac2b7a-6be4-4689-b574-c1f7eba19a3a"), 0, "83ea2f69-c1c5-46e1-8e09-b0a998033966", new DateTime(2022, 4, 5, 8, 15, 1, 292, DateTimeKind.Local).AddTicks(5201), 2, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "StaffSupport", "AQAAAAEAACcQAAAAEA51WtXRjoXlv7o+GrlR+X4h23tQzsiqZ6eLJ4lbXk9OrTvUAkmCRLIxhNAPqGxZGg==", "0123", false, "", false, "StaffSupport" }
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
