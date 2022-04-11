using Application.Common;
using Data.EF;
using Data.Entities;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public class IDeaService : IIDeaService
    {
        private readonly WebEnterpriseDbcontext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStorageService _storageService;


        public IDeaService(WebEnterpriseDbcontext context, UserManager<AppUser> userManager,
            IStorageService storageService)
        {
            _context = context;
            _userManager = userManager;
            _storageService = storageService;
        }

        public async Task<ApiResult<bool>> AddCategoryToIdea(int ideaId, List<int> categoryIdeas)
        {
            var idea = await _context.Ideas.FindAsync(ideaId);
            if (idea == null)
            {
                return new ApiErrorResult<bool>("Idea doesn't exist");
            }

            foreach (var id in categoryIdeas)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return new ApiErrorResult<bool>("category doesn't exist");
                }

                var ideaCategory = new IdeaCategory()
                {
                    IdeaId = ideaId,
                    CategoryId = id
                };
                await _context.IdeaCategories.AddAsync(ideaCategory);
                await _context.SaveChangesAsync();
            }
            return new ApiSuccessResult<bool>(true);
        }

        public async Task<ApiResult<bool>> CommentIdea(CommentCreateRequest request)
        {
            var idea = await _context.Ideas.FindAsync(request.IdeaId);
            if (idea == null)
            {
                return new ApiErrorResult<bool>("Idea doesn't exist");
            }
            var userIdea = await _context.AppUsers.FindAsync(idea.UserId);
            if (userIdea == null)
            {
                return new ApiErrorResult<bool>("User does not exits");
            }

            var user = await _context.AppUsers.FindAsync(request.UserId);
            if (user == null)
            {
                return new ApiErrorResult<bool>("User does not exits");
            }

            var comment = new Comment()
            {
                Content = request.Content,
                IsAnonymously = request.IsAnonymous,
                IdeaId = idea.Id,
                UserId = user.Id
            };
            await _context.Comments.AddAsync(comment);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }

            if (userIdea != user)
            {
                string to = userIdea.Email;
                string subject = "A new idea has just been created";
                string body = user.UserName + " just comment to your idea";

                var mailSetting = await _context.MailSettings.FirstOrDefaultAsync();

                var email = new MimeMessage();

                email.Sender = new MailboxAddress(mailSetting.DisplayName, mailSetting.Email);
                email.From.Add(new MailboxAddress(mailSetting.DisplayName, mailSetting.Email));
                email.To.Add(new MailboxAddress(to, to));
                email.Subject = subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = body;
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                try
                {
                    //kết nối máy chủ
                    await smtp.ConnectAsync(mailSetting.Host, mailSetting.Port, SecureSocketOptions.StartTls);
                    // xác thực
                    await smtp.AuthenticateAsync(mailSetting.Email, mailSetting.Password);
                    //gởi
                    await smtp.SendAsync(email);
                }
                catch (Exception e)
                {
                    return new ApiErrorResult<bool>("there was an error when sending mail but still created the idea. Error: " + e.Message);
                }
                smtp.Disconnect(true);
            }
            return new ApiSuccessResult<bool>(true);
        }

        public async Task<ApiResult<bool>> CountViewIdea(int id)
        {
            var idea = await _context.Ideas.FindAsync(id);
            if (idea == null)
            {
                return new ApiErrorResult<bool>("Idea doesn't exist");
            }
            idea.View += 1;
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }

            return new ApiSuccessResult<bool>(true);

        }

        public async Task<ApiResult<bool>> CreateIdea(IdeaCreateRequest request)
        {
            var academicYear = await _context.AcademicYears.OrderBy(x => x.EndDate).LastOrDefaultAsync(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now);
            if (academicYear == null)
            {
                return new ApiErrorResult<bool>("Current time does not belong to any school year, please create corresponding school year");
            }
            var userCreate = await _userManager.FindByIdAsync(request.UserId.ToString());
            var roles = await _userManager.GetRolesAsync(userCreate);
            var role = roles[0];
            if (role != "staff")
            {
                return new ApiErrorResult<bool>("Only staff can post new ideas");
            }
            var idea = new Idea()
            {
                Content = request.Content,
                UserId = request.UserId,
                IsAnonymously = request.IsAnonymously,
                AcademicYearId = academicYear.Id
            };
            if (request.File != null)
            {
                idea.FilePath = await this.SaveFile(request.File);
            }

            await _context.Ideas.AddAsync(idea);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }


            var users = await _userManager.GetUsersInRoleAsync("QACoordinator");
            var usersQueryalbe = users.AsQueryable();
            usersQueryalbe = usersQueryalbe.Where(x => x.DepartmentId == userCreate.DepartmentId);


            foreach (var QAcor in usersQueryalbe)
            {
                string to = QAcor.Email;
                string subject = "A new idea has just been created";
                string body = userCreate.UserName + "Just created a new idea, please go see it and leave a review";

                var mailSetting = await _context.MailSettings.FirstOrDefaultAsync();

                var email = new MimeMessage();

                email.Sender = new MailboxAddress(mailSetting.DisplayName, mailSetting.Email);
                email.From.Add(new MailboxAddress(mailSetting.DisplayName, mailSetting.Email));
                email.To.Add(new MailboxAddress(to, to));
                email.Subject = subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = body;
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                try
                {
                    //kết nối máy chủ
                    await smtp.ConnectAsync(mailSetting.Host, mailSetting.Port, SecureSocketOptions.StartTls);
                    // xác thực
                    await smtp.AuthenticateAsync(mailSetting.Email, mailSetting.Password);
                    //gởi
                    await smtp.SendAsync(email);
                }
                catch (Exception e)
                {
                    return new ApiErrorResult<bool>("there was an error when sending mail but still created the idea. Error: " + e.Message);
                }
                smtp.Disconnect(true);
            }
            return new ApiSuccessResult<bool>(true);
        }

        public async Task<ApiResult<IDeaViewModel>> GetIdeaById(int id)
        {
            var idea = await _context.Ideas.FindAsync(id);
            if (idea == null)
            {
                return new ApiErrorResult<IDeaViewModel>("Ideas doesn't exists");
            }
            var categoryIdeas = await _context.IdeaCategories.Where(x => x.IdeaId == id).ToListAsync();
            var user = await _context.AppUsers.FindAsync(idea.UserId);

            var ideaVM = new IDeaViewModel()
            {
                Id = idea.Id,
                Content = idea.Content,
                CreatedAt = idea.CreatedAt,
                EditDate = idea.EditDate,
                FilePath = idea.FilePath,
                View = idea.View,
                UserName = user.UserName,
                IsAnonymously = idea.IsAnonymously,
                FinalDate = idea.FinalDate,
                UserId = idea.UserId,
                AcademicYearId = idea.AcademicYearId,
                Categories = new List<string>()
            };

            foreach (var item in categoryIdeas)
            {
                var category = await _context.Categories.FindAsync(item.CategoryId);
                ideaVM.Categories.Add(category.Name);
            }

            var academicYear = await _context.AcademicYears.FindAsync(ideaVM.AcademicYearId);
            ideaVM.AcademicYearName = academicYear.Name;
            var like = await _context.LikeOrDislikes.Where(x => x.IsLike == true && x.IdeaId == ideaVM.Id).ToListAsync();
            ideaVM.LikeAmount = like.Count;
            var dislikes = await _context.LikeOrDislikes.Where(x => x.IsDislike == true && x.IdeaId == ideaVM.Id).ToListAsync();
            ideaVM.DislikeAmount = dislikes.Count;
            ideaVM.UpVote = like.Count - dislikes.Count;

            return new ApiSuccessResult<IDeaViewModel>(ideaVM);
        }
        public async Task<ApiResult<List<CommentViewModel>>> GetAllComment(int id)
        {
            var comments = await _context.Comments.Where(x => x.IdeaId == id).ToListAsync();
            if (comments == null)
            {
                return new ApiErrorResult<List<CommentViewModel>>("No comment exists");
            }

            var commentVM = comments.Select(x => new CommentViewModel()
            {
                Id = x.Id,
                Content = x.Content,
                IsAnonymously = x.IsAnonymously,
                UserId = x.UserId,

            }).ToList();
            foreach (var item in commentVM)
            {
                var user = await _context.AppUsers.FindAsync(item.UserId);
                item.Name = user.UserName;
            }
            return new ApiSuccessResult<List<CommentViewModel>>(commentVM);
        }

        public async Task<ApiResult<PageResult<IDeaViewModel>>> GetAllIdea(IdeaAdminPagingRequest request)
        {
            var query = new List<Idea>();
            if (request.Number == 1)
            {

                query = await _context.Ideas.OrderByDescending(x => x.View).ToListAsync();
            }
            else
            {
                query = await _context.Ideas.ToListAsync();
            }

            if (query == null)
            {
                return new ApiErrorResult<PageResult<IDeaViewModel>>("No Ideas exists");
            }
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new IDeaViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    EditDate = x.EditDate,
                    FilePath = x.FilePath,
                    View = x.View,
                    IsAnonymously = x.IsAnonymously,
                    FinalDate = x.FinalDate,
                    UserId = x.UserId,
                    AcademicYearId = x.AcademicYearId,
                    Categories = new List<string>()
                }).ToList();

            foreach (var item in data)
            {
                var academicYear = await _context.AcademicYears.FindAsync(item.AcademicYearId);
                item.AcademicYearName = academicYear.Name;

                var like = await _context.LikeOrDislikes.Where(x => x.IsLike == true && x.IdeaId == item.Id).ToListAsync();
                item.LikeAmount = like.Count;
                var dislikes = await _context.LikeOrDislikes.Where(x => x.IsDislike == true && x.IdeaId == item.Id).ToListAsync();
                item.DislikeAmount = dislikes.Count;
                item.UpVote = like.Count - dislikes.Count;
                var user = await _context.AppUsers.FindAsync(item.UserId);
                item.UserName = user.UserName;
                var ideaCategories = await _context.IdeaCategories.Where(x => x.IdeaId == item.Id).ToListAsync();
                foreach (var ideacategory in ideaCategories)
                {
                    var category = await _context.Categories.FindAsync(ideacategory.CategoryId);
                    item.Categories.Add(category.Name);
                }

            }
            if (request.Number == 2)
            {
                data = data.OrderByDescending(x => x.UpVote).ToList();
            }

            var pagedResult = new PageResult<IDeaViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PageResult<IDeaViewModel>>(pagedResult);
        }

        public async Task<ApiResult<PageResult<IDeaViewModel>>> GetAllIdeaUser(IdeaUserPagingRequest request)
        {
            var query = new List<Idea>();
            if (request.Number == 1)
            {

                query = await _context.Ideas.OrderByDescending(x => x.View).ToListAsync();
            }
            else
            {
                query = await _context.Ideas.ToListAsync();
            }
            if (query == null)
            {
                return new ApiErrorResult<PageResult<IDeaViewModel>>("No Ideas exists");
            }
            int totalRow = query.Count();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new IDeaViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    EditDate = x.EditDate,
                    FilePath = x.FilePath,
                    View = x.View,
                    IsAnonymously = x.IsAnonymously,
                    FinalDate = x.FinalDate,
                    UserId = x.UserId,
                    Categories = new List<string>(),
                    AcademicYearId = x.AcademicYearId
                }).ToList();

            foreach (var item in data)
            {
                var academicYear = await _context.AcademicYears.FindAsync(item.AcademicYearId);
                item.AcademicYearName = academicYear.Name;
                var likeOrDislike = await _context.LikeOrDislikes.FirstOrDefaultAsync(x => x.IdeaId == item.Id && x.UserId == request.UserId);
                if (likeOrDislike != null)
                {
                    item.Like = likeOrDislike.IsLike;
                    item.Dislike = likeOrDislike.IsDislike;
                }
                var like = await _context.LikeOrDislikes.Where(x => x.IsLike == true && x.IdeaId == item.Id).ToListAsync();
                item.LikeAmount = like.Count;
                var dislikes = await _context.LikeOrDislikes.Where(x => x.IsDislike == true && x.IdeaId == item.Id).ToListAsync();
                item.DislikeAmount = dislikes.Count;
                item.UpVote = like.Count - dislikes.Count;
                var user = await _context.AppUsers.FindAsync(item.UserId);
                item.UserName = user.UserName;
                var ideaCategories = await _context.IdeaCategories.Where(x => x.IdeaId == item.Id).ToListAsync();
                foreach (var ideacategory in ideaCategories)
                {
                    var category = await _context.Categories.FindAsync(ideacategory.CategoryId);
                    item.Categories.Add(category.Name);
                }
            }
            if (request.Number == 2)
            {
                data = data.OrderByDescending(x => x.UpVote).ToList();
            }
            var pagedResult = new PageResult<IDeaViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PageResult<IDeaViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> LikeOrDislikeIdea(LikeOrDislikeRequest request)
        {

            var idea = await _context.Ideas.FindAsync(request.IdeaId);
            if (idea == null)
            {
                return new ApiErrorResult<bool>("Idea doesn't exist");
            }
            switch (request.Number)
            {
                case -2:
                    var dislike = new LikeOrDislike()
                    {
                        IdeaId = request.IdeaId,
                        UserId = request.UserId,
                        IsLike = false,
                        IsDislike = true
                    };
                    await _context.LikeOrDislikes.AddAsync(dislike);
                    await _context.SaveChangesAsync();
                    break;

                case -1:
                    var queryDislike = await _context.LikeOrDislikes
                        .FirstOrDefaultAsync(x => x.IdeaId == request.IdeaId && x.UserId == request.UserId);
                    if (queryDislike == null)
                    {
                        return new ApiErrorResult<bool>("An error occurred, please try again");
                    }
                    queryDislike.IsLike = false;
                    queryDislike.IsDislike = true;
                    await _context.SaveChangesAsync();
                    break;
                case 1:
                    var queryLike = await _context.LikeOrDislikes
                        .FirstOrDefaultAsync(x => x.IdeaId == request.IdeaId && x.UserId == request.UserId);
                    if (queryLike == null)
                    {
                        return new ApiErrorResult<bool>("An error occurred, please try again");
                    }
                    queryLike.IsLike = true;
                    queryLike.IsDislike = false;
                    await _context.SaveChangesAsync();

                    break;
                case 2:
                    var like = new LikeOrDislike()
                    {
                        IdeaId = request.IdeaId,
                        UserId = request.UserId,
                        IsLike = true,
                        IsDislike = false
                    };
                    await _context.LikeOrDislikes.AddAsync(like);
                    await _context.SaveChangesAsync();
                    break;
            }
            return new ApiSuccessResult<bool>(true);


        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public DownloadFileViewModel DownloadZip(string filePath)
        {
            var fileDownload = _storageService.DownloadZip(filePath);
            return fileDownload;
        }

        public async Task<ApiResult<IDeaViewModel>> GetIdeaByIdUser(int id, Guid userId)
        {
            var idea = await _context.Ideas.FindAsync(id);
            if (idea == null)
            {
                return new ApiErrorResult<IDeaViewModel>("Ideas doesn't exists");
            }
            var categoryIdeas = await _context.IdeaCategories.Where(x => x.IdeaId == id).ToListAsync();
            var user = await _context.AppUsers.FindAsync(idea.UserId);

            var ideaVM = new IDeaViewModel()
            {
                Id = idea.Id,
                Content = idea.Content,
                CreatedAt = idea.CreatedAt,
                EditDate = idea.EditDate,
                FilePath = idea.FilePath,
                View = idea.View,
                UserName = user.UserName,
                IsAnonymously = idea.IsAnonymously,
                FinalDate = idea.FinalDate,
                UserId = idea.UserId,
                AcademicYearId = idea.AcademicYearId,
                Categories = new List<string>()
            };

            foreach (var item in categoryIdeas)
            {
                var category = await _context.Categories.FindAsync(item.CategoryId);
                ideaVM.Categories.Add(category.Name);
            }

            var academicYear = await _context.AcademicYears.FindAsync(ideaVM.AcademicYearId);
            ideaVM.AcademicYearName = academicYear.Name;
            var likeOrDislike = await _context.LikeOrDislikes.FirstOrDefaultAsync(x => x.IdeaId == ideaVM.Id && x.UserId == userId);
            if (likeOrDislike != null)
            {
                ideaVM.Like = likeOrDislike.IsLike;
                ideaVM.Dislike = likeOrDislike.IsDislike;
            }
            var like = await _context.LikeOrDislikes.Where(x => x.IsLike == true && x.IdeaId == ideaVM.Id).ToListAsync();
            ideaVM.LikeAmount = like.Count;
            var dislikes = await _context.LikeOrDislikes.Where(x => x.IsDislike == true && x.IdeaId == ideaVM.Id).ToListAsync();
            ideaVM.DislikeAmount = dislikes.Count;
            ideaVM.UpVote = like.Count - dislikes.Count;

            return new ApiSuccessResult<IDeaViewModel>(ideaVM);
        }

        public async Task<ApiResult<List<AnalyzeIdeaByAcademicViewModel>>> AnalyzeIdeaByAcademicYear()
        {
            var analyzes = new List<AnalyzeIdeaByAcademicViewModel>();
            var academicYears = await _context.AcademicYears.ToListAsync();

            foreach (var year in academicYears)
            {
                var ideas = await _context.Ideas.Where(x => x.AcademicYearId == year.Id).ToListAsync();
                var analyze = new AnalyzeIdeaByAcademicViewModel()
                {
                    AcademicYearId = year.Id,
                    Name = year.Name,
                    CountIdea = ideas.Count
                };
                analyzes.Add(analyze);
            }
            return new ApiSuccessResult<List<AnalyzeIdeaByAcademicViewModel>>(analyzes);
        }

        public async Task<ApiResult<bool>> UpdateIdea(IdeaUpdateRequest request)
        {
            var idea = await _context.Ideas.FindAsync(request.Id);
            if (idea == null)
            {
                return new ApiErrorResult<bool>("Don't find idea, please try again ");
            }
            idea.Content = request.Content;
            if (request.File != null)
            {
                if (idea.FilePath != null)
                {
                    await _storageService.DeleteFileAsync(idea.FilePath);

                }
                idea.FilePath = await this.SaveFile(request.File);
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>(true);
        }
    }
}
