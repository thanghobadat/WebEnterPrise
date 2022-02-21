using System.Threading.Tasks;
using ViewModel.System.Users;

namespace Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);

    }
}
