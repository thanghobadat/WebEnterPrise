using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddMailSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e84833f-96af-4611-9684-49de78cfc897"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f7f2580-651e-47e5-a9d8-6e8a90f4e64f"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("83a226a5-f7c7-4fc5-83ff-bdd88019f98d"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("923cbd1d-3d58-44f5-9f8f-707a8edd6249"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("923cbd1d-3d58-44f5-9f8f-707a8edd6249"), new Guid("20f0e1c0-9e73-48cd-b863-9d4d2aa3d6e8") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7f7f2580-651e-47e5-a9d8-6e8a90f4e64f"), new Guid("73e15ce4-064b-446a-9005-1c3687b55db3") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1e84833f-96af-4611-9684-49de78cfc897"), new Guid("a6a5acd3-f702-4c5e-a2b8-332c05ec1e26") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("83a226a5-f7c7-4fc5-83ff-bdd88019f98d"), new Guid("ede32135-4ebf-4455-93fa-fcaaf8e55dfc") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("83a226a5-f7c7-4fc5-83ff-bdd88019f98d"), new Guid("f05890a2-fe56-4f77-9470-b893c36db0ff") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1e84833f-96af-4611-9684-49de78cfc897"), new Guid("fd4d8a74-d342-43a6-9729-7a8e3332a5ce") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("20f0e1c0-9e73-48cd-b863-9d4d2aa3d6e8"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("73e15ce4-064b-446a-9005-1c3687b55db3"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a6a5acd3-f702-4c5e-a2b8-332c05ec1e26"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("ede32135-4ebf-4455-93fa-fcaaf8e55dfc"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("f05890a2-fe56-4f77-9470-b893c36db0ff"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("fd4d8a74-d342-43a6-9729-7a8e3332a5ce"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                table: "Ideas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 17, 17, 17, 13, 746, DateTimeKind.Local).AddTicks(5457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 17, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditDate",
                table: "Ideas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 13, 17, 17, 13, 746, DateTimeKind.Local).AddTicks(4665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 13, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Ideas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 6, 17, 17, 13, 745, DateTimeKind.Local).AddTicks(4964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 6, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(164));

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

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ab0c85ab-2c37-43b0-a658-0270e1c2d53e"), "7525043c-34cf-47f2-80f0-d9fae76af9ba", "Administrator role", "admin", "admin" },
                    { new Guid("17267466-3ded-416b-8994-2c3fe1a50c6e"), "ef843368-3fdb-458a-872c-513c4080ec3f", "QA Manager role", "QAManager", "QAManager" },
                    { new Guid("5e074f11-7a78-45df-bdd0-b96efe9339c0"), "c630f6d7-9913-4357-83e2-543bfc19a454", "QA Coordinator role", "QACoordinator", "QACoordinator" },
                    { new Guid("fb4d447c-dac0-4922-9a46-20ea09316417"), "d97d37be-ac2e-46c7-9934-c5dd7cbba325", "Staff role", "staff", "staff" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ab0c85ab-2c37-43b0-a658-0270e1c2d53e"), new Guid("29b8049b-71ef-4737-80c6-2642d82e1047") },
                    { new Guid("17267466-3ded-416b-8994-2c3fe1a50c6e"), new Guid("991ebb22-8c59-424f-abc7-d60156716482") },
                    { new Guid("5e074f11-7a78-45df-bdd0-b96efe9339c0"), new Guid("dbb029af-91a0-4dcf-aa1f-20b36a77266d") },
                    { new Guid("5e074f11-7a78-45df-bdd0-b96efe9339c0"), new Guid("e7819d69-0eb1-44ff-a7f8-7d94f2f49eda") },
                    { new Guid("fb4d447c-dac0-4922-9a46-20ea09316417"), new Guid("dd211483-75a9-4c09-8e8b-19f72cd506e6") },
                    { new Guid("fb4d447c-dac0-4922-9a46-20ea09316417"), new Guid("5fddcf86-4dde-46f6-bb40-e8d4f1645d3a") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("29b8049b-71ef-4737-80c6-2642d82e1047"), 0, "cd8b5128-0118-4f1e-a74b-aaf3c10e14c5", new DateTime(2022, 3, 6, 17, 17, 13, 773, DateTimeKind.Local).AddTicks(9992), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "admin", "AQAAAAEAACcQAAAAECr3NhF0W9ce4gatbdPyN4jvB8tH8NYz+Aa17N3gpgYuDSfAP56qTPNovcLxp6E1eg==", "0123", false, "", false, "admin" },
                    { new Guid("991ebb22-8c59-424f-abc7-d60156716482"), 0, "540677f5-835d-4353-ab68-0cae376045f9", new DateTime(2022, 3, 6, 17, 17, 13, 781, DateTimeKind.Local).AddTicks(263), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "manager", "AQAAAAEAACcQAAAAEKGQ7BqAgk0glUN6e1WrVEn93qZHTDx9IfH75Mi/jNKGqLcrxzePcXIPyjv6SPZJGA==", "0123", false, "", false, "manager" },
                    { new Guid("dbb029af-91a0-4dcf-aa1f-20b36a77266d"), 0, "7908ed8f-8f10-4d83-aa36-7c981139ac57", new DateTime(2022, 3, 6, 17, 17, 13, 787, DateTimeKind.Local).AddTicks(8039), 1, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "QACoordinatorAcademic", "AQAAAAEAACcQAAAAEHO8n/8KqyTcYHkB+VZ74GNg89KEq7yF7l7lRNA7TQsO/TTVCmvi56fswLI8O5k+nA==", "0123", false, "", false, "QACoordinatorAcademic" },
                    { new Guid("e7819d69-0eb1-44ff-a7f8-7d94f2f49eda"), 0, "df1c3d4d-04fa-407d-ae4c-4090b1e6afc4", new DateTime(2022, 3, 6, 17, 17, 13, 794, DateTimeKind.Local).AddTicks(6402), 2, "hungnd342000@gmail.com", true, false, null, "hungnd342000@gmail.com", "QACoordinatorSupport", "AQAAAAEAACcQAAAAEDuGzwHgWyQ29yzE03/YYWnzl0drprUepKi/EdCZCTTffQ3n4dlT22bc+0rLxSB/Zg==", "0123", false, "", false, "QACoordinatorSupport" },
                    { new Guid("dd211483-75a9-4c09-8e8b-19f72cd506e6"), 0, "fae8b10d-cfbf-48e4-8ce7-a5eeb2ca7d83", new DateTime(2022, 3, 6, 17, 17, 13, 801, DateTimeKind.Local).AddTicks(5436), 1, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "StaffAcademic", "AQAAAAEAACcQAAAAEPN0YnHWRVQ7wTw7COyvfTd8/b2Pvyc3xvDHopC06eUTXVo9RPk8uxtVajwcphl2Nw==", "0123", false, "", false, "StaffAcademic" },
                    { new Guid("5fddcf86-4dde-46f6-bb40-e8d4f1645d3a"), 0, "1303030c-0150-48ab-b285-b44830be29cb", new DateTime(2022, 3, 6, 17, 17, 13, 808, DateTimeKind.Local).AddTicks(5506), 2, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "StaffSupport", "AQAAAAEAACcQAAAAEMAUkXLxJApgENisdio4+nIJFALuIo5PXcYICn9Mte7eRpe85o2wNx6naEYfpebyUg==", "0123", false, "", false, "StaffSupport" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailSettings");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("17267466-3ded-416b-8994-2c3fe1a50c6e"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e074f11-7a78-45df-bdd0-b96efe9339c0"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab0c85ab-2c37-43b0-a658-0270e1c2d53e"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb4d447c-dac0-4922-9a46-20ea09316417"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ab0c85ab-2c37-43b0-a658-0270e1c2d53e"), new Guid("29b8049b-71ef-4737-80c6-2642d82e1047") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fb4d447c-dac0-4922-9a46-20ea09316417"), new Guid("5fddcf86-4dde-46f6-bb40-e8d4f1645d3a") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("17267466-3ded-416b-8994-2c3fe1a50c6e"), new Guid("991ebb22-8c59-424f-abc7-d60156716482") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5e074f11-7a78-45df-bdd0-b96efe9339c0"), new Guid("dbb029af-91a0-4dcf-aa1f-20b36a77266d") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fb4d447c-dac0-4922-9a46-20ea09316417"), new Guid("dd211483-75a9-4c09-8e8b-19f72cd506e6") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5e074f11-7a78-45df-bdd0-b96efe9339c0"), new Guid("e7819d69-0eb1-44ff-a7f8-7d94f2f49eda") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("29b8049b-71ef-4737-80c6-2642d82e1047"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5fddcf86-4dde-46f6-bb40-e8d4f1645d3a"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("991ebb22-8c59-424f-abc7-d60156716482"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("dbb029af-91a0-4dcf-aa1f-20b36a77266d"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("dd211483-75a9-4c09-8e8b-19f72cd506e6"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7819d69-0eb1-44ff-a7f8-7d94f2f49eda"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinalDate",
                table: "Ideas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 17, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(9077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 17, 17, 17, 13, 746, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditDate",
                table: "Ideas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 13, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(8667),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 13, 17, 17, 13, 746, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Ideas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 6, 10, 2, 48, 482, DateTimeKind.Local).AddTicks(164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 3, 6, 17, 17, 13, 745, DateTimeKind.Local).AddTicks(4964));

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
                    { new Guid("20f0e1c0-9e73-48cd-b863-9d4d2aa3d6e8"), 0, "d9295411-02bd-444c-aed0-f45b9ce78300", new DateTime(2022, 3, 6, 10, 2, 48, 510, DateTimeKind.Local).AddTicks(4630), null, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "manager", "AQAAAAEAACcQAAAAELVymqeEKFo/S6TLFOHKAwroGzoaIi/dl7XUNWYevl2M5M1GOKMb0vJHJC9SnPLv2A==", "0123", false, "", false, "manager" },
                    { new Guid("f05890a2-fe56-4f77-9470-b893c36db0ff"), 0, "8f725e1d-cbcf-4d4c-957a-6e7d2068a8e7", new DateTime(2022, 3, 6, 10, 2, 48, 517, DateTimeKind.Local).AddTicks(2550), 1, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "QACoordinatorAcademic", "AQAAAAEAACcQAAAAEFnwkUM6YTczF89EikbuuTN9HYDdjnWVbyHc37aN46eFQRd/6WnhxA/EYYWdEQLdZw==", "0123", false, "", false, "QACoordinatorAcademic" },
                    { new Guid("ede32135-4ebf-4455-93fa-fcaaf8e55dfc"), 0, "0e3a00c1-71bc-402d-bbd5-cb43dddfb07f", new DateTime(2022, 3, 6, 10, 2, 48, 524, DateTimeKind.Local).AddTicks(1208), 2, "hungnd342000@gmail.com", true, false, null, "hungnd342000@gmail.com", "QACoordinatorSupport", "AQAAAAEAACcQAAAAEKN33kxPdxfsDitowktA9+PG+rONImLvb2J1wOWJ6G4JzUQJWfapPF08k/gQbpUaTA==", "0123", false, "", false, "QACoordinatorSupport" },
                    { new Guid("a6a5acd3-f702-4c5e-a2b8-332c05ec1e26"), 0, "a5dfc807-ef69-418f-849f-c13cf03436eb", new DateTime(2022, 3, 6, 10, 2, 48, 530, DateTimeKind.Local).AddTicks(8965), 1, "hoangthanh01022000@gmail.com", true, false, null, "hoangthanh01022000@gmail.com", "StaffAcademic", "AQAAAAEAACcQAAAAEC4gU1d1pCgMbdipgzo+1r7Jt4NCpxHhB1IbCt5R6gfCUdUzkKHlJi6kMO+GkuDdGA==", "0123", false, "", false, "StaffAcademic" },
                    { new Guid("fd4d8a74-d342-43a6-9729-7a8e3332a5ce"), 0, "97ff8f3d-6e42-49bc-98a3-54c9bff2ce20", new DateTime(2022, 3, 6, 10, 2, 48, 537, DateTimeKind.Local).AddTicks(6679), 2, "nguyenthtran.dev@gmail.com", true, false, null, "nguyenthtran.dev@gmail.com", "StaffSupport", "AQAAAAEAACcQAAAAECUui9R+8NJQp8wZHBXZUcZbsfNyjb9TI8jieBGvlkBwCnv+1CP9P8a6aA7qp5Y1rw==", "0123", false, "", false, "StaffSupport" }
                });
        }
    }
}
