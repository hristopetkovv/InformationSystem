using System.Collections.Generic;
using System.Threading.Tasks;
using InformationSystemServer.Services;
using InformationSystemServer.Services.Helpers;
using InformationSystemServer.ViewModels.Application;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystemServer.Controllers
{
    public class ApplicationController : BaseApiController
    {
        private readonly IApplicationService appService;
        private readonly UserContext userContext;

        public ApplicationController(IApplicationService appService, UserContext userContext)
        {
            this.appService = appService;
            this.userContext = userContext;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationResponseDto>> GetApplications([FromQuery] SearchApplicationFilterDto filter)
        {
            return await appService.GetAllApplicationsAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<ApplicationDetailsDto> GetApplication(int id)
        {
            return await appService.GetApplicationByIdAsync(id);
        }

        [HttpPost]
        public async Task PostApplication(ApplicationRequestDto app)
        {
            var userId = this.userContext.UserId.Value;

            await appService.AddApplicationAsync(app, userId);
        }

        [HttpPut("{id:int}")]
        public async Task PutApplicationAsync(int id, ApplicationDetailsDto application)
        {
           await appService.UpdateApplicationAsync(id, application);
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteApplicationAsync(int id)
        {
            await appService.DeleteApplicationAsync(id);
        }

        [HttpGet("ByUser/{id:int}")]
        public async Task<List<int>> GetApplicationByUserId(int id)
        {
            return await appService.GetApplicationByUserIdAsync(id);
        }
    }
}
