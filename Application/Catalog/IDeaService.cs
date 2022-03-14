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
            var userIdea = await _userManager.FindByIdAsync(idea.UserId.ToString());
            if (userIdea == null)
            {
                return new ApiErrorResult<bool>("User does not exits");
            }

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
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
                string body = user.UserName + "Just comment to your idea";

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
            return new ApiSuccessResult<bool>();
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

            return new ApiSuccessResult<bool>();

        }

        public async Task<ApiResult<bool>> CreateIdea(IdeaCreateRequest request)
        {
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
                IsAnonymously = request.IsAnonymously
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
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<IDeaViewModel>> GetIdeaById(int id)
        {
            var idea = await _context.Ideas.FindAsync(id);
            if (idea == null)
            {
                return new ApiErrorResult<IDeaViewModel>("Ideas doesn't exists");
            }
            var categoryIdeas = await _context.IdeaCategories.Where(x => x.IdeaId == id).ToListAsync();
            if (idea == null)
            {
                return new ApiErrorResult<IDeaViewModel>("Ideas doesn't exists");
            }

            var ideaVM = new IDeaViewModel()
            {
                Id = idea.Id,
                Content = idea.Content,
                CreatedAt = idea.CreatedAt,
                EditDate = idea.EditDate,
                FilePath = idea.FilePath,
                View = idea.View,
                Like = idea.Like,
                Dislike = idea.Dislike,
                IsAnonymously = idea.IsAnonymously,
                FinalDate = idea.FinalDate,
                UserId = idea.UserId,
                Categories = new List<string>()
            };

            foreach (var item in categoryIdeas)
            {
                var category = await _context.Categories.FindAsync(item.CategoryId);
                ideaVM.Categories.Add(category.Name);
            }
            return new ApiSuccessResult<IDeaViewModel>(ideaVM);
        }

        public async Task<ApiResult<PageResult<IDeaViewModel>>> GetIdeaPaging(GetPagingRequestPage request)
        {
            var query = await _context.Ideas.ToListAsync();
            if (query == null)
            {
                return new ApiErrorResult<PageResult<IDeaViewModel>>("No Ideas exists");
            }
            var ideas = query.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                ideas = ideas.Where(x => x.Content.Contains(request.Keyword));
            }


            int totalRow = ideas.Count();

            var data = ideas.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new IDeaViewModel()
                {
                    Id = x.Id,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                    EditDate = x.EditDate,
                    FilePath = x.FilePath,
                    View = x.View,
                    Like = x.Like,
                    Dislike = x.Dislike,
                    IsAnonymously = x.IsAnonymously,
                    FinalDate = x.FinalDate,
                    UserId = x.UserId,
                    Categories = new List<string>()
                }).ToList();

            foreach (var item in data)
            {
                var ideaCategories = await _context.IdeaCategories.Where(x => x.IdeaId == item.Id).ToListAsync();
                foreach (var ideacategory in ideaCategories)
                {
                    var category = await _context.Categories.FindAsync(ideacategory.CategoryId);
                    item.Categories.Add(category.Name);
                }
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

        public async Task<ApiResult<bool>> LikeOrDislikeIdea(int id, int number)
        {

            var idea = await _context.Ideas.FindAsync(id);
            if (idea == null)
            {
                return new ApiErrorResult<bool>("Idea doesn't exist");
            }
            switch (number)
            {
                case -2:
                    idea.Like -= 1;
                    idea.Dislike += 1;
                    break;
                case -1:
                    idea.Dislike += 1;
                    break;
                case 1:
                    idea.Like += 1;
                    break;
                case 2:
                    idea.Dislike -= 1;
                    idea.Like += 1;
                    break;
            }
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }

            return new ApiSuccessResult<bool>();


        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
