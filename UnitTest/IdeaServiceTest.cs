using Application.Catalog;
using Application.Common;
using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace UnitTest
{
    [TestFixture]
    internal class IdeaServiceTest
    {
        private IIDeaService _ideaService;
        private WebEnterpriseDbcontext _context;
        private IStorageService _storageService;
        private UserManager<AppUser> _userManager;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WebEnterpriseDbcontext>()
                .UseInMemoryDatabase(databaseName: "DatabaseName")
                .Options;
            _context = new WebEnterpriseDbcontext(options);

            _context.AcademicYears.Add(new AcademicYear
            {
                Id = 1,
                Name = "Name 1",
                StartDate = new DateTime(2022, 04, 01),
                EndDate = new DateTime(2022, 04, 05),
            });

            //_context.Ideas.Add(new Idea
            //{
            //    Id = 1,
            //    Content = "Name 1",
            //    FilePath = "UrlFile"
            //});
            //_context.Departments.Add(new Department
            //{
            //    Id = 2,
            //    Name = "Name 2",
            //    Description = "Description 2"
            //});
            //_context.Departments.Add(new Department
            //{
            //    Id = 3,
            //    Name = "Name 3",
            //    Description = "Description 3"
            //});

            //var adminId = new Guid("efb6f2bb-b30a-49ae-9ab4-fe76ed16885e");
            //var hasher = new PasswordHasher<AppUser>();
            //_context.AppUsers.Add(new AppUser
            //{
            //    Id = adminId,
            //    UserName = "admin",
            //    NormalizedUserName = "admin",
            //    Email = "hoangthanh01022000@gmail.com",
            //    NormalizedEmail = "hoangthanh01022000@gmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "Admin@123"),
            //    SecurityStamp = string.Empty,
            //    CreatedAt = DateTime.Now,
            //    PhoneNumber = "0123",
            //});
            _context.SaveChanges();

            _ideaService = new IDeaService(_context, _userManager, _storageService);
        }
    }
}
