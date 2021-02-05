using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using InformationSystemServer.Services.Token;
using InformationSystemServer.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext dbContext;
        private readonly ITokenService tokenService;

        public AccountService(AppDbContext dbContext, ITokenService tokenService)
        {
            this.dbContext = dbContext;
            this.tokenService = tokenService;
        }

        public async Task<UserResponseDto> Login(LoginRequestDto dto)
        {
            var user = await this.dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid username");
            }

            var passwordHash = PasswordEncrypt.ComputeHash(dto.Password, user.PasswordSalt);

            if (user.Password != passwordHash)
            {
                throw new InvalidOperationException("Invalid password");
            }

            return new UserResponseDto
            {
                Username = user.Username,
                Token = tokenService.CreateToken(user),
                Role = user.Role
            };
        }

        public async Task<UserResponseDto> Register(RegisterRequestDto dto)
        {
            await this.UserExists(dto.Username);

            var passwordResult = PasswordEncrypt.ComputeHash(dto.Password);

            var user = new User
            {
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = Roles.User,
                Password = passwordResult.Hash,
                PasswordSalt = passwordResult.Salt
            };

            this.dbContext.Users.Add(user);

            await this.dbContext.SaveChangesAsync();

            return new UserResponseDto
            {
                Username = user.Username,
                Token = this.tokenService.CreateToken(user),
                Role = user.Role
            };
        }

        private async Task<string> UserExists(string username)
        {
            var exists = await this.dbContext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());

            if (exists)
            {
                throw new InvalidOperationException("Username is taken");
            }

            return string.Empty;
        }
    }
}
