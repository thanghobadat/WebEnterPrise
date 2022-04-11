using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public interface IIDeaService
    {
        Task<ApiResult<PageResult<IDeaViewModel>>> GetAllIdea(IdeaAdminPagingRequest request);
        Task<ApiResult<PageResult<IDeaViewModel>>> GetAllIdeaUser(IdeaUserPagingRequest request);
        Task<ApiResult<List<CommentViewModel>>> GetAllComment(int id);
        Task<ApiResult<IDeaViewModel>> GetIdeaById(int id);
        Task<ApiResult<IDeaViewModel>> GetIdeaByIdUser(int id, Guid userId);
        Task<ApiResult<bool>> CreateIdea(IdeaCreateRequest request);
        Task<ApiResult<bool>> AddCategoryToIdea(int ideaId, int categoryId);
        Task<ApiResult<bool>> LikeOrDislikeIdea(LikeOrDislikeRequest request);
        Task<ApiResult<bool>> CountViewIdea(int id);
        Task<ApiResult<bool>> CommentIdea(CommentCreateRequest request);
        Task<ApiResult<bool>> UpdateIdea(IdeaUpdateRequest request);

        Task<ApiResult<List<AnalyzeIdeaByAcademicViewModel>>> AnalyzeIdeaByAcademicYear();
        DownloadFileViewModel DownloadZip(string filePath);


    }
}
