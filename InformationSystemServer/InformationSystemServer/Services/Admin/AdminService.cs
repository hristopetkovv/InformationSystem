using InformationSystemServer.Data;
using InformationSystemServer.Services.Helpers;
using InformationSystemServer.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Admin
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
                .ToListAsync();
        }
    }
}
