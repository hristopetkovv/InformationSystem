using InformationSystemServer.Enums;
using InformationSystemServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class StatusController : BaseApiController
    {
        private readonly IApplicationService applicationService;

        public StatusController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPut("{id:int}")]
        public async Task ChangeStatus(int id, [FromBody] StatusType status)
        {
            await this.applicationService.ChangeStatusAsync(id, status);
        }
    }
}
