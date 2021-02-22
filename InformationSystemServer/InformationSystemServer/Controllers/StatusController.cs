using InformationSystemServer.Infrastructure.Enums;
using InformationSystemServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class StatusController : BaseApiController
    {
        private readonly IApplicationService applicationService;
        private readonly IMessageService messageService;

        public StatusController(IApplicationService applicationService, IMessageService messageService)
        {
            this.applicationService = applicationService;
            this.messageService = messageService;
        }

        [HttpPut("application/{id:int}")]
        public async Task ChangeApplicationStatus(int id, [FromBody] StatusType status)
        {
            await this.applicationService.ChangeStatusAsync(id, status);
        }

        [HttpPut("message/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task ChangeMessageStatus(int id, [FromBody] MessageStatus status)
        {
            await this.messageService.ChangeStatusAsync(id, status);
        }
    }
}
