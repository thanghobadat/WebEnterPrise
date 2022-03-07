using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public interface IIDeaService
    {
        Task<ApiResult<bool>> CreateIdea(IdeaCreateRequest request);
        Task<ApiResult<bool>> AddCategoryToIdea(int ideaId, List<int> categoryIdeas);
        Task<ApiResult<bool>> LikeOrDislikeIdea(int id, int number);
        Task<ApiResult<bool>> CountViewIdea(int id);
        //thông báo email
    }
}
