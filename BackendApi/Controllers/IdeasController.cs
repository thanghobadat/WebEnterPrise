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
    public class IdeasController : ControllerBase
    {
        private readonly IIDeaService _ideaService;

        public IdeasController(IIDeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [HttpGet("GetAllIdea")]
        public async Task<IActionResult> GetAllIdea()
        {
            var result = await _ideaService.GetAllIdea();
            return Ok(result);
        }
        [HttpGet("GetAllComment")]
        public async Task<IActionResult> GetAllComment(int id)
        {
            var result = await _ideaService.GetAllComment(id);
            return Ok(result);
        }
        [HttpGet("GetAllIdeaUser")]
        public async Task<IActionResult> GetAllIdeaUser(Guid userId)
        {
            var result = await _ideaService.GetAllIdeaUser(userId);
            return Ok(result);
        }
        [HttpGet("GetIdeaById")]
        public async Task<IActionResult> GetIdeaById(int id)
        {
            var result = await _ideaService.GetIdeaById(id);
            return Ok(result);
        }

        [HttpPost("CreateIdea")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateIdea([FromForm] IdeaCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _ideaService.CreateIdea(request);
            return Ok(result);
        }

        [HttpPost("AddNewComment")]
        public async Task<IActionResult> AddNewComment([FromBody] CommentCreateRequest request)
        {

            var result = await _ideaService.CommentIdea(request);
            return Ok(result);
        }

        [HttpPut("AddCategoryToIdea")]
        public async Task<IActionResult> AddCategoryToIdea([FromBody] AddCategoryToIdeaRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _ideaService.AddCategoryToIdea(request.IdeaId, request.CategoryId);
            return Ok(result);
        }

        [HttpPut("LikeOrDislikeIdea")]
        public async Task<IActionResult> LikeOrDislikeIdea(LikeOrDislikeRequest request)
        {

            var result = await _ideaService.LikeOrDislikeIdea(request);
            return Ok(result);
        }

        [HttpPut("CountViewIdea")]
        public async Task<IActionResult> CountViewIdea(int id)
        {

            var result = await _ideaService.CountViewIdea(id);
            return Ok(result);
        }

    }
}
