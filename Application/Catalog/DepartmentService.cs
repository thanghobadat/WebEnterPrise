using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public class DepartmentService : IDepartmentService
    {
        private readonly WebEnterpriseDbcontext _context;
        public DepartmentService(WebEnterpriseDbcontext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateDepartment(DepartmentViewModel request)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(x => x.Name.Contains(request.Name));

            if (department != null)
            {
                return new ApiErrorResult<bool>("Department is exist");
            }

            department = new Department()
            {
                Name = request.Name,
                Description = request.Description
            };
            await _context.Departments.AddAsync(department);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return new ApiErrorResult<bool>("Department doesn't exist");
            }

            _context.Departments.Remove(department);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<DepartmentViewModel>> GetDepartmentById(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return new ApiErrorResult<DepartmentViewModel>("Department doesn't exits");
            }

            var departmentViewModel = new DepartmentViewModel()
            {
                Id = id,
                Name = department.Name,
                Description = department.Description
            };
            return new ApiSuccessResult<DepartmentViewModel>(departmentViewModel);
        }

        public async Task<ApiResult<PageResult<DepartmentViewModel>>> GetDepartmentPaging(GetDepartmentPagingRequest request)
        {
            var query = await _context.Departments.ToListAsync();
            if (query == null)
            {
                return new ApiErrorResult<PageResult<DepartmentViewModel>>("No department exists, please create a new department");
            }
            var departments = query.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                departments = departments.Where(x => x.Name.Contains(request.Keyword));
            }


            int totalRow = departments.Count();

            var data = departments.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DepartmentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();

            var pagedResult = new PageResult<DepartmentViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PageResult<DepartmentViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> UpdateDepartment(DepartmentViewModel request)
        {
            if (await _context.Departments.AnyAsync(x => x.Name == request.Name && x.Id != request.Id))
            {
                return new ApiErrorResult<bool>("Department is exist");
            }

            var department = await _context.Departments.FindAsync(request.Id);

            department.Name = request.Name;
            department.Description = request.Description;

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }

            return new ApiSuccessResult<bool>();
        }
    }
}

