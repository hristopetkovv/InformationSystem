using InformationSystemServer.Services.ViewModels.Account;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Services.Account
{
    public interface IAccountService
    {
        Task<UserResponseDto> Register(RegisterRequestDto dto);

        Task<UserResponseDto> Login(LoginRequestDto dto);
    }
}
