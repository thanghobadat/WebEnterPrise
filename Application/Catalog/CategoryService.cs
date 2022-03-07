using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public class CategoryService : ICategoryService
    {
        private readonly WebEnterpriseDbcontext _context;
        public CategoryService(WebEnterpriseDbcontext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateCategory(CategoryViewModel request)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Name.Contains(request.Name));

            if (category != null)
            {
                return new ApiErrorResult<bool>("Category is exist");
            }

            category = new Category()
            {
                Name = request.Name,
                Description = request.Description
            };
            await _context.Categories.AddAsync(category);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return new ApiErrorResult<bool>("Department doesn't exist");
            }

            var categoriesInIdea = await _context.IdeaCategories.Where(x => x.CategoryId == id).ToListAsync();
            if (categoriesInIdea.Count > 0)
            {
                return new ApiErrorResult<bool>("You cannot delete this category because it is assigned to at least 1 idea");
            }
            _context.Categories.Remove(category);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<CategoryViewModel>> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return new ApiErrorResult<CategoryViewModel>("Category doesn't exits");
            }

            var categoryViewModel = new CategoryViewModel()
            {
                Id = id,
                Name = category.Name,
                Description = category.Description
            };
            return new ApiSuccessResult<CategoryViewModel>(categoryViewModel);
        }

        public async Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPaging(GetCategoryPagingRequest request)
        {
            var query = await _context.Categories.ToListAsync();
            if (query == null)
            {
                return new ApiErrorResult<PageResult<CategoryViewModel>>("No category exists, please create a new category");
            }
            var ListCategories = query.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                ListCategories = ListCategories.Where(x => x.Name.Contains(request.Keyword));
            }


            int totalRow = ListCategories.Count();

            var data = ListCategories.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();

            var pagedResult = new PageResult<CategoryViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PageResult<CategoryViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> UpdateCategory(CategoryViewModel request)
        {
            if (await _context.Categories.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
            {
                return new ApiErrorResult<bool>("Category is exist");
            }

            var category = await _context.Categories.FindAsync(request.Id);

            category.Name = request.Name;
            category.Description = request.Description;

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }

            return new ApiSuccessResult<bool>();
        }
    }
}
