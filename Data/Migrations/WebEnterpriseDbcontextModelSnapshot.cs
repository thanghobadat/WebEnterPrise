﻿// <auto-generated />
using System;
using Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(WebEnterpriseDbcontext))]
    partial class WebEnterpriseDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.AcademicYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AcademicYears");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2022, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sprint 2022",
                            StartDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            EndDate = new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Summer 2022",
                            StartDate = new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("53d78053-d999-4fd3-a14d-50e476960cca"),
                            ConcurrencyStamp = "ddce15fc-e12c-4bbf-98e8-e5f20f42b002",
                            Description = "Administrator role",
                            Name = "admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = new Guid("25c55e6a-d027-4fc9-a4cd-ed7eca4a7067"),
                            ConcurrencyStamp = "2f8175db-f4b1-43c2-bc54-ab7e3a1c5efe",
                            Description = "QA Manager role",
                            Name = "QAManager",
                            NormalizedName = "QAManager"
                        },
                        new
                        {
                            Id = new Guid("1e275fdf-041e-4c60-a750-4d3ec08cf947"),
                            ConcurrencyStamp = "069a4467-7383-4caf-b0a1-e0e9937a44d5",
                            Description = "QA Coordinator role",
                            Name = "QACoordinator",
                            NormalizedName = "QACoordinator"
                        },
                        new
                        {
                            Id = new Guid("1a63efbd-8a4b-4cab-8aa2-23886aeeb5f2"),
                            ConcurrencyStamp = "ba3c0e3c-23ce-4c77-a54b-97348e94b256",
                            Description = "Staff role",
                            Name = "staff",
                            NormalizedName = "staff"
                        });
                });

            modelBuilder.Entity("Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("AppUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("558b81cc-9376-49c4-8f82-467988807134"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "10421817-1b88-44b5-83f1-145184c20b9a",
                            CreatedAt = new DateTime(2022, 3, 22, 12, 52, 4, 194, DateTimeKind.Local).AddTicks(9162),
                            Email = "hoangthanh01022000@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hoangthanh01022000@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEHPeIfPmTAYJqrVo5OaqNqbkGqDP7eyZ261h5ZuO7Pzh7vt4uxZCz7hpsXatrit80w==",
                            PhoneNumber = "0123",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("e208e482-4dfb-4a49-bc41-f8a5abbe5f91"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0f3e4549-b85f-4844-88ce-64ce01a62c95",
                            CreatedAt = new DateTime(2022, 3, 22, 12, 52, 4, 201, DateTimeKind.Local).AddTicks(9387),
                            Email = "hoangthanh01022000@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hoangthanh01022000@gmail.com",
                            NormalizedUserName = "manager",
                            PasswordHash = "AQAAAAEAACcQAAAAEIdw4WHocFRDyC4J7QpvxNagVt9NVTCEiHGOc7Ep6UkorcmdOaZoS60Jf8QZeJTutg==",
                            PhoneNumber = "0123",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "manager"
                        },
                        new
                        {
                            Id = new Guid("0e2066a4-ff28-4f4d-83dc-ea14ce13ea18"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "81db2eaa-3cab-4bb5-8836-313cb742627f",
                            CreatedAt = new DateTime(2022, 3, 22, 12, 52, 4, 208, DateTimeKind.Local).AddTicks(7193),
                            DepartmentId = 1,
                            Email = "nguyenthtran.dev@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "nguyenthtran.dev@gmail.com",
                            NormalizedUserName = "QACoordinatorAcademic",
                            PasswordHash = "AQAAAAEAACcQAAAAEGLftVUgxnOWlhzgQEZdiy01xP1DDJ3qao9UClKWAr9DaD7EUcDkXY87Gfpe1Cu7tQ==",
                            PhoneNumber = "0123",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "QACoordinatorAcademic"
                        },
                        new
                        {
                            Id = new Guid("ddb5db77-b6b3-470a-9af1-ee5af8a99928"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c834d332-2982-429a-a60d-05154e3f68c3",
                            CreatedAt = new DateTime(2022, 3, 22, 12, 52, 4, 215, DateTimeKind.Local).AddTicks(5632),
                            DepartmentId = 2,
                            Email = "hungnd342000@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hungnd342000@gmail.com",
                            NormalizedUserName = "QACoordinatorSupport",
                            PasswordHash = "AQAAAAEAACcQAAAAEBEbwWnYtsPa4lY1xJ7VvZAWuq6+UzfhKSJ9oiNCi/RNC9u/qaIqu4/AnOEgc6xBpg==",
                            PhoneNumber = "0123",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "QACoordinatorSupport"
                        },
                        new
                        {
                            Id = new Guid("efb6f2bb-b30a-49ae-9ab4-fe76ed16885e"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b487deef-8c61-4656-9e30-62fee202c0e8",
                            CreatedAt = new DateTime(2022, 3, 22, 12, 52, 4, 222, DateTimeKind.Local).AddTicks(3745),
                            DepartmentId = 1,
                            Email = "hoangthanh01022000@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hoangthanh01022000@gmail.com",
                            NormalizedUserName = "StaffAcademic",
                            PasswordHash = "AQAAAAEAACcQAAAAEJAX9FlCEjSKETz7I5h+298Ivnhi0jrwJxHEgXi5G7s7qoLrw27WqciJ/TBth9FJWQ==",
                            PhoneNumber = "0123",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "StaffAcademic"
                        },
                        new
                        {
                            Id = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "660b49c3-2270-4906-b057-8d54b5ac8927",
                            CreatedAt = new DateTime(2022, 3, 22, 12, 52, 4, 229, DateTimeKind.Local).AddTicks(1796),
                            DepartmentId = 2,
                            Email = "nguyenthtran.dev@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "nguyenthtran.dev@gmail.com",
                            NormalizedUserName = "StaffSupport",
                            PasswordHash = "AQAAAAEAACcQAAAAEM0PNHk0pOY3v2Z8T7pWFv9c4P+BBnVR3KjYXGpKkxluxpKkZpuWC10icflLKnl9EA==",
                            PhoneNumber = "0123",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "StaffSupport"
                        });
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdeaId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAnonymously")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Academic Department",
                            Name = "Academic"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is Support Department",
                            Name = "Support"
                        });
                });

            modelBuilder.Entity("Data.Entities.Idea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicYearId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 3, 22, 12, 52, 4, 169, DateTimeKind.Local).AddTicks(3253));

                    b.Property<DateTime>("EditDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 3, 29, 12, 52, 4, 170, DateTimeKind.Local).AddTicks(1608));

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinalDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 2, 12, 52, 4, 170, DateTimeKind.Local).AddTicks(2048));

                    b.Property<bool>("IsAnonymously")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("View")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("AcademicYearId");

                    b.HasIndex("UserId");

                    b.ToTable("Ideas");
                });

            modelBuilder.Entity("Data.Entities.IdeaCategory", b =>
                {
                    b.Property<int>("IdeaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("IdeaId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("IdeaCategories");
                });

            modelBuilder.Entity("Data.Entities.LikeOrDislike", b =>
                {
                    b.Property<int>("IdeaId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDislike")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsLike")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("IdeaId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LikeOrDislikes");
                });

            modelBuilder.Entity("Data.Entities.MailSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MailSettings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("558b81cc-9376-49c4-8f82-467988807134"),
                            RoleId = new Guid("53d78053-d999-4fd3-a14d-50e476960cca")
                        },
                        new
                        {
                            UserId = new Guid("e208e482-4dfb-4a49-bc41-f8a5abbe5f91"),
                            RoleId = new Guid("25c55e6a-d027-4fc9-a4cd-ed7eca4a7067")
                        },
                        new
                        {
                            UserId = new Guid("0e2066a4-ff28-4f4d-83dc-ea14ce13ea18"),
                            RoleId = new Guid("1e275fdf-041e-4c60-a750-4d3ec08cf947")
                        },
                        new
                        {
                            UserId = new Guid("ddb5db77-b6b3-470a-9af1-ee5af8a99928"),
                            RoleId = new Guid("1e275fdf-041e-4c60-a750-4d3ec08cf947")
                        },
                        new
                        {
                            UserId = new Guid("efb6f2bb-b30a-49ae-9ab4-fe76ed16885e"),
                            RoleId = new Guid("1a63efbd-8a4b-4cab-8aa2-23886aeeb5f2")
                        },
                        new
                        {
                            UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                            RoleId = new Guid("1a63efbd-8a4b-4cab-8aa2-23886aeeb5f2")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("Data.Entities.AppUser", b =>
                {
                    b.HasOne("Data.Entities.Department", "Department")
                        .WithMany("AppUser")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Data.Entities.Comment", b =>
                {
                    b.HasOne("Data.Entities.Idea", "Idea")
                        .WithMany("Comments")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.AppUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idea");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Idea", b =>
                {
                    b.HasOne("Data.Entities.AcademicYear", "AcademicYear")
                        .WithMany("Ideas")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.AppUser", "User")
                        .WithMany("Ideas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicYear");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.IdeaCategory", b =>
                {
                    b.HasOne("Data.Entities.Category", "Category")
                        .WithMany("IdeaCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Idea", "Idea")
                        .WithMany("IdeaCategories")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Idea");
                });

            modelBuilder.Entity("Data.Entities.LikeOrDislike", b =>
                {
                    b.HasOne("Data.Entities.Idea", "Idea")
                        .WithMany("LikeOrDislikes")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Data.Entities.AppUser", "User")
                        .WithMany("LikeOrDislikes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Idea");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.AcademicYear", b =>
                {
                    b.Navigation("Ideas");
                });

            modelBuilder.Entity("Data.Entities.AppUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ideas");

                    b.Navigation("LikeOrDislikes");
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Navigation("IdeaCategories");
                });

            modelBuilder.Entity("Data.Entities.Department", b =>
                {
                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Data.Entities.Idea", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("IdeaCategories");

                    b.Navigation("LikeOrDislikes");
                });
#pragma warning restore 612, 618
        }
    }
}
