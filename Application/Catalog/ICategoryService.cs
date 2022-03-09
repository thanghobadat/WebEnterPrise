using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public interface ICategoryService
    {
        Task<ApiResult<PageResult<CategoryViewModel>>> GetCategoryPaging(GetCategoryPagingRequest request);
        Task<ApiResult<bool>> CreateCategory(CategoryViewModel request);
        Task<ApiResult<CategoryViewModel>> GetById(int id);
        Task<ApiResult<bool>> UpdateCategory(CategoryViewModel request);
        Task<ApiResult<bool>> DeleteCategory(int id);
    }
}
