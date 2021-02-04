using InformationSystemServer.Services;
using InformationSystemServer.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<UserResponseDto> Register([FromBody]RegisterRequestDto dto)
        {
            var user = await this.accountService.Register(dto);

            return user;
        }
    }
}
