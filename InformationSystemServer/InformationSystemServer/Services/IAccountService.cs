using InformationSystemServer.ViewModels.Account;
using System.Threading.Tasks;

namespace InformationSystemServer.Services
{
    public interface IAccountService
    {
        Task<UserResponseDto> Register(RegisterRequestDto dto);
    }
}
