using InformationSystemServer.Services.Implementations.Account;
using InformationSystemServer.Services.Implementations.Helpers;
using InformationSystemServer.Services.ViewModels.Account;
using InformationSystemServer.Services.ViewModels.ReCaptcha;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
	public class AccountController : BaseApiController
	{
		private readonly IAccountService accountService;
		private readonly ReCaptchaConfiguration options;

		public AccountController(IAccountService accountService,IOptions<ReCaptchaConfiguration> options)
		{
			this.accountService = accountService;
			this.options = options.Value;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("register")]
		public async Task<UserResponseDto> Register([FromBody] RegisterRequestDto dto)
		{
			var apiUrl = $"{this.options.ApiUrl}?secret={this.options.Secret}&response={dto.ReCaptchaToken}";

			using var client = new HttpClient();

			var jsonResponse = await client.PostAsync(apiUrl, null);

			var responseAsString = await jsonResponse.Content.ReadAsStringAsync();

			var model = JsonSerializer.Deserialize<GResponseModel>(responseAsString);

			if (model.success == false)
			{
				throw new InvalidOperationException("You are a robot.");
			}

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
