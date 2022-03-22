using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public interface IAcademicService
    {
        Task<ApiResult<PageResult<AcademicYearViewModel>>> GetAcademicYearPaging(GetPagingRequestPage request);
        Task<ApiResult<AcademicYearViewModel>> GetAcademicYearById(int id);
        Task<ApiResult<bool>> CreateAcademicYear(AcademicYearViewModel request);


    }
}
