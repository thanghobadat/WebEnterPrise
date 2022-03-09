using Application.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ViewModel.System.Users;

namespace BackendApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
      _userService = userService;
    }
    [HttpPost("Authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var resultToken = await _userService.Authenticate(request);


      if (string.IsNullOrEmpty(resultToken))
      {
        return BadRequest(resultToken);
      }
      return Ok(resultToken);
    }
    [HttpPost("Register")]
    // [AllowAnonymous]

    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      var result = await _userService.RegisterAccount(request);
      if (!result.ResultObj)
      {
        return BadRequest(result);
      }
      return Ok(result);
    }

    [HttpGet("GetAllAccount")]
    public async Task<IActionResult> GetAllAccount([FromQuery] string keyword)
    {
      var result = await _userService.GetAllAccount(keyword);
      return Ok(result);
    }

    [HttpGet("GetAccountById")]
    public async Task<IActionResult> GetAccountById(Guid id)
    {
      var user = await _userService.GetAccountById(id);
      return Ok(user);
    }
    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      var result = await _userService.ChangePassword(request);
      if (!result.IsSuccessed)
      {
        return BadRequest(result.Message);
      }
      return Ok(result);
    }

    [HttpDelete("DeleteAccount")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
      var result = await _userService.DeleteAccount(id);
      return Ok(result);
    }
  }
}
