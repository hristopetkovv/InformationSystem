using InformationSystemServer.Services.Services.Admin;
using InformationSystemServer.Services.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseApiController
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await this.adminService.GetUsers();
        }

        [HttpPut]
        public async Task<IActionResult> MakeAdmin([FromBody] int userId)
        {
            await this.adminService.MakeAdmin(userId);

            return Ok();
        }
    }
}
