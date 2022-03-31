using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public interface IIDeaService
    {
        Task<ApiResult<List<IDeaViewModel>>> GetAllIdea(int number);
        Task<ApiResult<List<IDeaViewModel>>> GetAllIdeaUser(Guid userId, int number);
        Task<ApiResult<List<CommentViewModel>>> GetAllComment(int id);
        Task<ApiResult<IDeaViewModel>> GetIdeaById(int id);
        Task<ApiResult<bool>> CreateIdea(IdeaCreateRequest request);
        Task<ApiResult<bool>> AddCategoryToIdea(int ideaId, List<int> categoryIdeas);
        Task<ApiResult<bool>> LikeOrDislikeIdea(LikeOrDislikeRequest request);
        Task<ApiResult<bool>> CountViewIdea(int id);
        Task<ApiResult<bool>> CommentIdea(CommentCreateRequest request);

    }
}
