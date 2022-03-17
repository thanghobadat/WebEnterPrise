using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.System.Users;

namespace Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly WebEnterpriseDbcontext _context;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration config, WebEnterpriseDbcontext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }
        public async Task<ApiResult<LoginViewModel>> Authenticate(LoginRequest request)
        {

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiErrorResult<LoginViewModel>("User doesn't exits");
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<LoginViewModel>("Password is not correct");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,string.Join(";",roles)),
                new Claim(ClaimTypes.Name,request.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
            var information = await this.GetAccountById(user.Id);

            var loginVM = new LoginViewModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Id = information.ResultObj.Id,
                UserName = information.ResultObj.UserName,
                Email = information.ResultObj.Email,
                PhoneNumber = information.ResultObj.PhoneNumber,
                Department = information.ResultObj.Department,
                Role = information.ResultObj.Role,

            };

            return new ApiSuccessResult<LoginViewModel>(loginVM);
        }

        public async Task<ApiResult<bool>> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User does not exits");
            }
            await _userManager.RemovePasswordAsync(user);
            var resultUser = await _userManager.AddPasswordAsync(user, request.NewPassword);
            if (!resultUser.Succeeded)
            {
                foreach (var error in resultUser.Errors)
                {
                    return new ApiErrorResult<bool>(error.Description);
                }

            }
            return new ApiSuccessResult<bool>(true);
        }

        public async Task<ApiResult<bool>> DeleteAccount(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User does not exits");
            }
            var reult = await _userManager.DeleteAsync(user);
            if (reult.Succeeded)
                return new ApiSuccessResult<bool>(true);

            return new ApiErrorResult<bool>("Delete failed");
        }

        public async Task<ApiResult<AccountViewModel>> GetAccountById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<AccountViewModel>("User does not exist ");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles[0];
            var accountVm = new AccountViewModel()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                Role = role
            };
            if (user.DepartmentId != null)
            {
                var department = await _context.Departments.FindAsync(user.DepartmentId);
                accountVm.Department = department.Name;
            }

            return new ApiSuccessResult<AccountViewModel>(accountVm);
        }

        public async Task<ApiResult<List<AccountViewModel>>> GetAccountStaffAndQACoor()
        {
            var data = new List<AccountViewModel>();
            var query = _userManager.Users;
            List<AppUser> accounts = query.ToList();
            foreach (var item in accounts)
            {
                var roles = await _userManager.GetRolesAsync(item);
                var role = roles[0];
                if (role == "staff" || role == "QACoordinator")
                {
                    var accountVM = new AccountViewModel()
                    {
                        Email = item.Email,
                        PhoneNumber = item.PhoneNumber,
                        UserName = item.UserName,
                        Id = item.Id,
                        CreatedAt = item.CreatedAt,
                        Role = role
                    };
                    if (item.DepartmentId != null)
                    {
                        var department = await _context.Departments.FindAsync(item.DepartmentId);
                        accountVM.Department = department.Name;
                    }
                    data.Add(accountVM);
                }

            }
            return new ApiSuccessResult<List<AccountViewModel>>(data);
        }

        public async Task<ApiResult<List<AccountViewModel>>> GetAllAccount(string keyword)
        {
            var data = new List<AccountViewModel>();
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.UserName.Contains(keyword));
            }

            List<AppUser> accounts = query.ToList();
            foreach (var item in accounts)
            {
                var roles = await _userManager.GetRolesAsync(item);
                var role = roles[0];
                var accountVM = new AccountViewModel()
                {
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    UserName = item.UserName,
                    Id = item.Id,
                    CreatedAt = item.CreatedAt,
                    Role = role
                };
                if (item.DepartmentId != null)
                {
                    var department = await _context.Departments.FindAsync(item.DepartmentId);
                    accountVM.Department = department.Name;
                }
                data.Add(accountVM);
            }
            return new ApiSuccessResult<List<AccountViewModel>>(data);
        }

        public async Task<ApiResult<bool>> RegisterAccount(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("User name already exists, please choose another User name");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("This email has already been applied to another account, please enter another email");

            }

            user = new AppUser()
            {
                CreatedAt = DateTime.Now,
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                DepartmentId = request.DepartmentId
            };
            var resultUser = await _userManager.CreateAsync(user, request.Password);
            if (!resultUser.Succeeded)
            {
                foreach (var error in resultUser.Errors)
                {
                    return new ApiErrorResult<bool>(error.Description);
                }
            }
            var resultRole = await _userManager.AddToRoleAsync(user, request.Role);
            if (!resultRole.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                foreach (var error in resultRole.Errors)
                {
                    return new ApiErrorResult<bool>(error.Description);
                }
            }

            return new ApiSuccessResult<bool>(true);
        }
    }
}
