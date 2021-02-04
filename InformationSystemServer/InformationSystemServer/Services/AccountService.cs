using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using InformationSystemServer.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystemServer.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext dbContext;

        public AccountService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
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

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    throw new InvalidOperationException("Invalid password");
                }
            }

            return new UserResponseDto
            {
                Username = user.Username,
                Role = user.Role
            };
        }

        public async Task<UserResponseDto> Register(RegisterRequestDto dto)
        {
            await this.UserExists(dto.Username);

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = dto.Username,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = Roles.User,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };

            this.dbContext.Users.Add(user);

            await this.dbContext.SaveChangesAsync();

            return new UserResponseDto
            { 
                Username = user.Username,
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
