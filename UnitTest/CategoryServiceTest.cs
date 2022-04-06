using Application.Catalog;
using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace UnitTest
{
    [TestFixture]
    internal class CategoryServiceTest
    {
        private ICategoryService _categoryService;
        private WebEnterpriseDbcontext _context;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<WebEnterpriseDbcontext>()
                .UseInMemoryDatabase(databaseName: "DatabaseName")
                .Options;
            _context = new WebEnterpriseDbcontext(options);

            _context.Categories.Add(new Category
            {
                Id = 1,
                Name = "Name 1",
                Description = "Description 1"
            });
            _context.Categories.Add(new Category
            {
                Id = 2,
                Name = "Name 2",
                Description = "Description 2"
            });
            _context.Categories.Add(new Category
            {
                Id = 3,
                Name = "Name 3",
                Description = "Description 3"
            });

            _context.SaveChanges();

            _categoryService = new CategoryService(_context);
        }
        [Test]
        public async Task CanDeleteCategory()
        {
            // Arrange
            int id = 1;
            // Act
            var result = await _categoryService.DeleteCategory(id);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }
        [Test]
        public async Task CanGetById()
        {
            // Arrange
            int id = 2;
            // Act
            var result = await _categoryService.GetById(id);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj);
        }
        [Test]
        public async Task CanGetCategoryPaging()
        {
            // Arrange
            var request = new GetPagingRequestPage()
            {
                PageSize = 1,
                PageIndex = 1,
                Keyword = null
            };
            // Act
            var result = await _categoryService.GetCategoryPaging(request);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj);
        }
        [Test]
        public async Task CanCreateCategory()
        {
            // Arrange
            var request = new CategoryViewModel()
            {
                Name = "Category Create",
                Description = "Category Description"
            };
            // Act
            var result = await _categoryService.CreateCategory(request);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }
        [Test]
        public async Task CanUpdateCategory()
        {
            // Arrange
            var request = new CategoryViewModel()
            {
                Id = 2,
                Name = "Category Updated",
                Description = "Category Description Updated"
            };
            // Act
            var result = await _categoryService.UpdateCategory(request);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }


    }
}
