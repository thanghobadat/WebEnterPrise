using Application.Catalog;
using Application.Common;
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
                Id = 10,
                Name = "Name 1",
                StartDate = new DateTime(2022, 04, 01),
                EndDate = new DateTime(2022, 04, 28),
            });
            _context.MailSettings.Add(new MailSetting
            {
                Id = 1,
                Email = "hoangthanh01022000@gmail.com",
                DisplayName = "thanh",
                Password = "thanhngo@123",
                Host = "smtp.gmail.com",
                Port = 587

            });




            var userId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de");
            var hasher = new PasswordHasher<AppUser>();
            _context.AppUsers.Add(new AppUser
            {
                Id = userId,
                UserName = "user",
                NormalizedUserName = "user1",
                Email = "hoangthanh01022000@gmail.com",
                NormalizedEmail = "hoangthanh01022000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                CreatedAt = DateTime.Now,
                PhoneNumber = "0123",
            });


            _context.Ideas.Add(new Idea
            {
                Id = 1,
                Content = "Name 1",
                FilePath = "UrlFile",
                View = 10,
                CreatedAt = new DateTime(2022, 03, 22),
                EditDate = new DateTime(2022, 03, 31),
                FinalDate = new DateTime(2022, 04, 10),
                IsAnonymously = true,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                AcademicYearId = 1

            });

            _context.Ideas.Add(new Idea
            {
                Id = 2,
                Content = "Name 2",
                FilePath = "UrlFile2",
                View = 12,
                CreatedAt = new DateTime(2022, 03, 22),
                EditDate = new DateTime(2022, 03, 31),
                FinalDate = new DateTime(2022, 04, 10),
                IsAnonymously = true,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                AcademicYearId = 1

            });
            _context.Ideas.Add(new Idea
            {
                Id = 3,
                Content = "Name 3",
                FilePath = "UrlFile3",
                View = 1,
                CreatedAt = new DateTime(2022, 03, 22),
                EditDate = new DateTime(2022, 03, 31),
                FinalDate = new DateTime(2022, 04, 10),
                IsAnonymously = true,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                AcademicYearId = 1

            });

            _context.LikeOrDislikes.Add(new LikeOrDislike
            {
                IdeaId = 2,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                IsLike = true,
                IsDislike = false
            });
            _context.LikeOrDislikes.Add(new LikeOrDislike
            {
                IdeaId = 1,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                IsLike = true,
                IsDislike = false
            });

            _context.Categories.Add(new Category
            {
                Id = 11,
                Name = "category 1",
                Description = "category 1 Description"
            });
            _context.Categories.Add(new Category
            {
                Id = 12,
                Name = "category 2",
                Description = "category 2 Description"
            });
            _context.Categories.Add(new Category
            {
                Id = 13,
                Name = "category 3",
                Description = "category 3 Description"
            });

            _context.IdeaCategories.Add(new IdeaCategory
            {
                CategoryId = 11,
                IdeaId = 2,
            });
            _context.IdeaCategories.Add(new IdeaCategory
            {
                CategoryId = 12,
                IdeaId = 2,
            });


            _context.Comments.Add(new Comment
            {
                Id = 1,
                Content = "comment 1",
                IsAnonymously = false,
                IdeaId = 1,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de")
            });
            _context.Comments.Add(new Comment
            {
                Id = 2,
                Content = "comment 2",
                IsAnonymously = false,
                IdeaId = 1,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de")
            });
            _context.SaveChanges();

            _ideaService = new IDeaService(_context, _userManager, _storageService);
        }

        [Test]
        public async Task CanGetAllIdea()
        {
            // Arrange
            var request = new IdeaAdminPagingRequest()
            {
                PageSize = 5,
                PageIndex = 1,
                Number = 0
            };
            // Act
            var result = await _ideaService.GetAllIdea(request);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj.Items);
        }

        [Test]
        public async Task CanGetAllIdeaUser()
        {
            // Arrange
            var request = new IdeaUserPagingRequest()
            {
                PageSize = 5,
                PageIndex = 1,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                Number = 0
            };
            // Act
            var result = await _ideaService.GetAllIdeaUser(request);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj.Items);
        }
        [Test]
        public async Task CanGetAllComment()
        {
            // Arrange
            int id = 1;
            // Act
            var result = await _ideaService.GetAllComment(id);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj);
        }
        [Test]
        public async Task CanGetIdeaById()
        {
            // Arrange
            int id = 1;
            // Act
            var result = await _ideaService.GetIdeaById(id);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj);
        }

        [Test]
        public async Task CanGetIdeaByIdUser()
        {
            // Arrange
            int id = 1;
            Guid userId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de");
            // Act
            var result = await _ideaService.GetIdeaByIdUser(id, userId);
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj);
        }
        [Test]
        public async Task CanAddCategoryToIdea()
        {
            // Arrange
            int id = 1;
            int categoryId = 13;

            // Act
            var result = await _ideaService.AddCategoryToIdea(id, categoryId);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }

        [Test]
        public async Task CanLikeOrDislikeIdea()
        {
            // Arrange
            var request1 = new LikeOrDislikeRequest()
            {
                IdeaId = 3,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                Number = 2
            };
            var request2 = new LikeOrDislikeRequest()
            {
                IdeaId = 2,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                Number = -1
            };

            // Act
            var result1 = await _ideaService.LikeOrDislikeIdea(request1);
            var result2 = await _ideaService.LikeOrDislikeIdea(request2);
            // Assert
            Assert.IsTrue(result1.ResultObj);
            Assert.IsTrue(result2.ResultObj);
        }

        [Test]
        public async Task CanCountViewIdea()
        {
            // Arrange
            int id = 1;

            // Act
            var result = await _ideaService.CountViewIdea(id);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }
        [Test]
        public async Task CanCommentIdea()
        {
            // Arrange
            var request = new CommentCreateRequest()
            {
                IdeaId = 1,
                UserId = new Guid("5e9962d7-8b63-4e1a-943c-24c17d2f25de"),
                IsAnonymous = true,
                Content = "comment"
            };

            // Act
            var result = await _ideaService.CommentIdea(request);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }
        [Test]
        public async Task CanUpdateIdea()
        {
            // Arrange
            var request = new IdeaUpdateRequest()
            {
                Content = "idea updated",
                Id = 1
            };

            // Act
            var result = await _ideaService.UpdateIdea(request);
            // Assert
            Assert.IsTrue(result.ResultObj);
        }

        [Test]
        public async Task CanAnalyzeIdeaByAcademicYear()
        {
            // Arrange

            // Act
            var result = await _ideaService.AnalyzeIdeaByAcademicYear();
            // Assert
            Assert.IsTrue(result.IsSuccessed);
            Assert.IsNotNull(result.ResultObj);
        }



    }
}

