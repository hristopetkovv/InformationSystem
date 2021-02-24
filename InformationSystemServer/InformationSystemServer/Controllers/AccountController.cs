using InformationSystemServer.Services.Services.Account;
using InformationSystemServer.Services.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<UserResponseDto> Register([FromBody] RegisterRequestDto dto)
        {
            var user = await this.accountService.Register(dto);

            return user;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<UserResponseDto> Login([FromBody] LoginRequestDto dto)
        {
            var user = await this.accountService.Login(dto);

            return user;
        }
    }
}
