using InformationSystemServer.Data;
using InformationSystemServer.Data.Enums;
using InformationSystemServer.Services.Services.Helpers;
using InformationSystemServer.Services.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext dbContext;
        private readonly UserContext userContext;

        public AdminService(AppDbContext dbContext, UserContext userContext)
        {
            this.dbContext = dbContext;
            this.userContext = userContext;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var adminId = this.userContext.UserId.Value;

            return await this.dbContext
                .Users
                .Where(u => u.Id != adminId)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    Role = u.Role
                })
                .OrderBy(x=>x.FirstName)
                .ToListAsync();
        }

        public async Task MakeAdmin(int userId)
        {
            var user = await this.dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new InvalidOperationException("Invalid user");
            }

            user.Role = Role.Admin;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
