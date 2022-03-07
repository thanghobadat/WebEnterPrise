using System;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public interface IDepartmentService
    {
        Task<ApiResult<PageResult<DepartmentViewModel>>> GetDepartmentPaging(GetDepartmentPagingRequest request);
        Task<ApiResult<bool>> CreateDepartment(DepartmentViewModel request);
        Task<ApiResult<DepartmentViewModel>> GetDepartmentById(int id);
        Task<ApiResult<bool>> UpdateDepartment(DepartmentViewModel request);
        Task<ApiResult<bool>> DeleteDepartment(int id);
        Task<ApiResult<bool>> AssignDepartment(int id, Guid userId);
    }
}
