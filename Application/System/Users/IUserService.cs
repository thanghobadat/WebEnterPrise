using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.System.Users;

namespace Application.System.Users
{
  public interface IUserService
  {
    Task<ApiResult<LoginViewModel>> Authenticate(LoginRequest request);
    Task<ApiResult<bool>> RegisterAccount(RegisterRequest request);
    Task<ApiResult<List<AccountViewModel>>> GetAllAccount(string keyword);
    Task<ApiResult<List<AccountViewModel>>> GetAccountStaffAndQACoor();
    Task<ApiResult<AccountViewModel>> GetAccountById(Guid id);
    Task<ApiResult<bool>> DeleteAccount(Guid id);
    Task<ApiResult<bool>> ChangePassword(ChangePasswordRequest request);
  }
}
