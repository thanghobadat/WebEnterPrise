using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public interface IIDeaService
    {
        Task<ApiResult<PageResult<IDeaViewModel>>> GetIdeaPaging(GetPagingRequestPage request);

        Task<ApiResult<bool>> CreateIdea(IdeaCreateRequest request);
        Task<ApiResult<bool>> AddCategoryToIdea(int ideaId, List<int> categoryIdeas);
        Task<ApiResult<bool>> LikeOrDislikeIdea(int id, int number);
        Task<ApiResult<bool>> CountViewIdea(int id);
        Task<ApiResult<bool>> CommentIdea(CommentCreateRequest request);
    }
}
