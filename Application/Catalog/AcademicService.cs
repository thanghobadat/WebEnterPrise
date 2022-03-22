using Data.EF;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace Application.Catalog
{
    public class AcademicService : IAcademicService
    {
        private readonly WebEnterpriseDbcontext _context;
        public AcademicService(WebEnterpriseDbcontext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> CreateAcademicYear(AcademicYearViewModel request)
        {
            var academicYear = await _context.AcademicYears.FirstOrDefaultAsync(x => x.Name.Contains(request.Name));

            if (academicYear != null)
            {
                return new ApiErrorResult<bool>("Academic year is exist");
            }

            var lastAcademicYear = await _context.AcademicYears.LastOrDefaultAsync();
            if (academicYear == null)
            {
                return new ApiErrorResult<bool>("No academic year exists, please create a new academic year");
            }

            if (request.StartDate < academicYear.EndDate)
            {
                return new ApiErrorResult<bool>("The start date of the new academic year cannot be the day before the last day of the previous academic year, please choose again");
            }

            academicYear = new AcademicYear()
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };
            await _context.AcademicYears.AddAsync(academicYear);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("An error occurred, please try again");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<AcademicYearViewModel>> GetAcademicYearById(int id)
        {
            var academicYear = await _context.AcademicYears.FindAsync(id);

            if (academicYear == null)
            {
                return new ApiErrorResult<AcademicYearViewModel>("Academic Year doesn't exits");
            }

            var academicYearViewModel = new AcademicYearViewModel()
            {
                Id = id,
                Name = academicYear.Name,
                StartDate = academicYear.StartDate,
                EndDate = academicYear.EndDate
            };
            return new ApiSuccessResult<AcademicYearViewModel>(academicYearViewModel);
        }

        public async Task<ApiResult<PageResult<AcademicYearViewModel>>> GetAcademicYearPaging(GetPagingRequestPage request)
        {
            var query = await _context.AcademicYears.ToListAsync();
            if (query == null)
            {
                return new ApiErrorResult<PageResult<AcademicYearViewModel>>("No academic year exists, please create a new academic year");
            }
            var ListAcademicYear = query.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                ListAcademicYear = ListAcademicYear.Where(x => x.Name.Contains(request.Keyword));
            }


            int totalRow = ListAcademicYear.Count();

            var data = ListAcademicYear.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new AcademicYearViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                }).ToList();

            var pagedResult = new PageResult<AcademicYearViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PageResult<AcademicYearViewModel>>(pagedResult);
        }
    }
}
