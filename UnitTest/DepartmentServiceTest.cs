using Application.Catalog;
using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace UnitTest
{
    [TestFixture]
    internal class DepartmentServiceTest
    {
        private IDepartmentService _departmentService;
        private WebEnterpriseDbcontext _context;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WebEnterpriseDbcontext>()
                .UseInMemoryDatabase(databaseName: "DatabaseName")
                .Options;
            _context = new WebEnterpriseDbcontext(options);

            _context.Departments.Add(new Department
            {
                Id = 1,
                Name = "Name 1",
                Description = "Description 1"
            });
            _context.Departments.Add(new Department
            {
                Id = 2,
                Name = "Name 2",
                Description = "Description 2"
            });
            _context.Departments.Add(new Department
            {
                Id = 3,
                Name = "Name 3",
                Description = "Description 3"
            });

            var adminId = new Guid("efb6f2bb-b30a-49ae-9ab4-fe76ed16885e");
            var hasher = new PasswordHasher<AppUser>();
            _context.AppUsers.Add(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "hoangthanh01022000@gmail.com",
                NormalizedEmail = "hoangthanh01022000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now,
                PhoneNumber = "0123",
            });
            _context.SaveChanges();

            _departmentService = new DepartmentService(_context);
        }

        [Test]
        public async Task CanGetDepartmentById()
        {
            // Arrange
            int id = 2;
            // Act
            var result = await _departmentService.GetDepartmentById(id);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj);
        }
        [Test]
        public async Task CanGetDepartmentPaging()
        {
            // Arrange
            var request = new GetPagingRequestPage()
            {
                PageSize = 1,
                PageIndex = 1,
                Keyword = null
            };
            // Act
            var result = await _departmentService.GetDepartmentPaging(request);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj);
        }
        [Test]
        public async Task CanCreateDepartment()
        {
            // Arrange
            var request = new DepartmentViewModel()
            {
                Name = "Department Create",
                Description = "Department Description"
            };
            // Act
            var result = await _departmentService.CreateDepartment(request);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }

        [Test]
        public async Task CanUpdateDepartment()
        {
            // Arrange
            var request = new DepartmentViewModel()
            {
                Id = 2,
                Name = "Department Updated",
                Description = "Department Description Updated"
            };
            // Act
            var result = await _departmentService.UpdateDepartment(request);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }

        [Test]
        public async Task CanDeleteDepartment()
        {
            // Arrange
            int id = 1;
            // Act
            var result = await _departmentService.DeleteDepartment(id);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }
        [Test]
        public async Task CanAssignDepartmentToUser()
        {
            // Arrange
            var adminId = new Guid("efb6f2bb-b30a-49ae-9ab4-fe76ed16885e");
            int id = 2;
            // Act
            var result = await _departmentService.AssignDepartment(id, adminId);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }
    }
}
