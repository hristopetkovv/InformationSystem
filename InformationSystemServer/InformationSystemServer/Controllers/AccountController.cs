using InformationSystemServer.Services.Account;
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

        [HttpPost]
        [Route("register")]
        public async Task<UserResponseDto> Register([FromBody] RegisterRequestDto dto)
        {
            var user = await this.accountService.Register(dto);

            return user;
        }

        [HttpPost]
        [Route("login")]
        public async Task<UserResponseDto> Login([FromBody] LoginRequestDto dto)
        {
            var user = await this.accountService.Login(dto);

            return user;
        }
    }
}
