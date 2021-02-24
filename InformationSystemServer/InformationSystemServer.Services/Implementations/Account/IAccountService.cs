using InformationSystemServer.Services.ViewModels.Account;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Implementations.Account
{
    public interface IAccountService
    {
        Task<UserResponseDto> Register(RegisterRequestDto dto);

        Task<UserResponseDto> Login(LoginRequestDto dto);
    }
}
