using Application.Catalog;
using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace UnitTest
{
    [TestFixture]
    internal class AcademicYearServiceTest
    {
        private IAcademicService _academicService;
        private WebEnterpriseDbcontext _context;
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
            _context.AcademicYears.Add(new AcademicYear
            {
                Id = 2,
                Name = "Name 2",
                StartDate = new DateTime(2022, 04, 06),
                EndDate = new DateTime(2022, 04, 10),
            });
            _context.AcademicYears.Add(new AcademicYear
            {
                Id = 3,
                Name = "Name 3",
                StartDate = new DateTime(2022, 04, 11),
                EndDate = new DateTime(2022, 04, 15),
            });


            _context.SaveChanges();

            _academicService = new AcademicService(_context);
        }
        [Test]
        public async Task CanGetAcademicYearById()
        {
            // Arrange
            int id = 2;
            // Act
            var result = await _academicService.GetAcademicYearById(id);
            // Assert
            Assert.IsNotNull(result.ResultObj);
        }
        [Test]
        public async Task CanGetAcademicYearPaging()
        {
            // Arrange
            var request = new GetPagingRequestPage()
            {
                PageSize = 1,
                PageIndex = 1,
                Keyword = null
            };
            // Act
            var result = await _academicService.GetAcademicYearPaging(request);
            // Assert
            Assert.IsNotNull(result.ResultObj);
        }
        [Test]
        public async Task CanCreateAcademicYear()
        {
            // Arrange
            var request = new AcademicYearViewModel()
            {
                Name = "Academic Year Create",
                StartDate = new DateTime(2022, 05, 17),
                EndDate = new DateTime(2022, 05, 21)
            };
            // Act
            var result = await _academicService.CreateAcademicYear(request);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }
    }
}
