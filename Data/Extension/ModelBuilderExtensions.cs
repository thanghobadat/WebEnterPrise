using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Extension
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Department
            modelBuilder.Entity<Department>().HasData(
               new Department
               {
                   Id = 1,
                   Name = "Academic",
                   Description = "Academic Department"
               },
           new Department
           {
               Id = 2,
               Name = "Support",
               Description = "This is Support Department"
           });
            modelBuilder.Entity<AcademicYear>().HasData(
               new AcademicYear
               {
                   Id = 1,
                   Name = "Sprint 2022",
                   StartDate = new DateTime(2022, 01, 01),
                   EndDate = new DateTime(2022, 03, 21)
               },
           new AcademicYear
           {
               Id = 2,
               Name = "Summer 2022",
               StartDate = new DateTime(2022, 03, 22),
               EndDate = new DateTime(2022, 03, 31)
           });


            // 1: admin
            var roleIdAdmin = Guid.NewGuid();
            var adminId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleIdAdmin,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasherAdmin = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "hoangthanh01022000@gmail.com",
                NormalizedEmail = "hoangthanh01022000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasherAdmin.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now,
                PhoneNumber = "0123"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleIdAdmin,
                UserId = adminId
            });

            //2: manager
            var roleIdManager = Guid.NewGuid();
            var managerId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleIdManager,
                Name = "QAManager",
                NormalizedName = "QAManager",
                Description = "QA Manager role"
            });

            var hasherManager = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = managerId,
                UserName = "manager",
                NormalizedUserName = "manager",
                Email = "hoangthanh01022000@gmail.com",
                NormalizedEmail = "hoangthanh01022000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasherManager.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now,
                PhoneNumber = "0123"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleIdManager,
                UserId = managerId
            });

            //3: staff Academic
            var roleIdQACoordinator = Guid.NewGuid();
            var QACoordinatorAcademicId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleIdQACoordinator,
                Name = "QACoordinator",
                NormalizedName = "QACoordinator",
                Description = "QA Coordinator role"
            });

            var hasherQACoordinatorAcademic = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = QACoordinatorAcademicId,
                UserName = "QACoordinatorAcademic",
                NormalizedUserName = "QACoordinatorAcademic",
                Email = "nguyenthtran.dev@gmail.com",
                NormalizedEmail = "nguyenthtran.dev@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasherQACoordinatorAcademic.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now,
                PhoneNumber = "0123",
                DepartmentId = 1
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleIdQACoordinator,
                UserId = QACoordinatorAcademicId
            });


            //4: staff Support
            var QACoordinatorSupportId = Guid.NewGuid();
            var hasherQACoordinatorSupport = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = QACoordinatorSupportId,
                UserName = "QACoordinatorSupport",
                NormalizedUserName = "QACoordinatorSupport",
                Email = "hungnd342000@gmail.com",
                NormalizedEmail = "hungnd342000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasherQACoordinatorSupport.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now,
                PhoneNumber = "0123",
                DepartmentId = 2
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleIdQACoordinator,
                UserId = QACoordinatorSupportId
            });


            //4: staff 
            var roleIdStaff = Guid.NewGuid();
            var StaffAcademicId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleIdStaff,
                Name = "staff",
                NormalizedName = "staff",
                Description = "Staff role"
            });

            var hasherStaffAcademic = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = StaffAcademicId,
                UserName = "StaffAcademic",
                NormalizedUserName = "StaffAcademic",
                Email = "hoangthanh01022000@gmail.com",
                NormalizedEmail = "hoangthanh01022000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasherStaffAcademic.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now,
                PhoneNumber = "0123",
                DepartmentId = 1
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleIdStaff,
                UserId = StaffAcademicId
            });


            var StaffSupportId = Guid.NewGuid();
            var hasherStaffSupport = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = StaffSupportId,
                UserName = "StaffSupport",
                NormalizedUserName = "StaffSupport",
                Email = "nguyenthtran.dev@gmail.com",
                NormalizedEmail = "nguyenthtran.dev@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasherStaffSupport.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now,
                PhoneNumber = "0123",
                DepartmentId = 2
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleIdStaff,
                UserId = StaffSupportId
            });



        }
    }
}
