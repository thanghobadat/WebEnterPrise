using Application.Catalog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetDepartmentPaging")]
        public async Task<IActionResult> GetDepartmentPaging([FromQuery] GetDepartmentPagingRequest request)
        {
            var departments = await _departmentService.GetDepartmentPaging(request);
            return Ok(departments);
        }
        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            if (id <= 0)
                return BadRequest("Category Id not must be less than 0");
            var department = await _departmentService.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var department = await _departmentService.CreateDepartment(request);
            return Ok(department);
        }

        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentViewModel request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var department = await _departmentService.UpdateDepartment(request);
            return Ok(department);
        }

        [HttpPut("AssignDepartment")]
        public async Task<IActionResult> AssignDepartment(int id, Guid userId)
        {


            var department = await _departmentService.AssignDepartment(id, userId);
            return Ok(department);
        }

        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {

            var department = await _departmentService.DeleteDepartment(id);
            return Ok(department);
        }
    }
}
