using Application.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AcademicController : ControllerBase
    {
        private readonly IAcademicService _academicService;
        public AcademicController(IAcademicService academicService)
        {
            _academicService = academicService;
        }

        [HttpGet("GetAcademicYearPaging")]
        public async Task<IActionResult> GetAcademicYearPaging([FromQuery] GetPagingRequestPage request)
        {
            var categories = await _academicService.GetAcademicYearPaging(request);
            return Ok(categories);
        }
        [HttpGet("GetAcademicYearById")]
        public async Task<IActionResult> GetAcademicYearById(int id)
        {
            if (id <= 0)
                return BadRequest("Academic iear id not must be less than 0");
            var category = await _academicService.GetAcademicYearById(id);
            return Ok(category);
        }
        [HttpPost("CreateAcademicYear")]
        public async Task<IActionResult> CreateAcademicYear([FromBody] AcademicYearViewModel request)
        {

            var category = await _academicService.CreateAcademicYear(request);
            return Ok(category);
        }
    }
}
