using System.Collections.Generic;
using System.Threading.Tasks;
using InformationSystemServer.Data.Models;
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
        public async Task<IEnumerable<ApplicationResponseDto>> GetApplications()
        {
            return await appService.GetAllApplicationsAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Application> GetApplication(int id)
        {
            return await appService.GetApplicationById(id);
        }

        [HttpPost]
        public async Task PostApplication(ApplicationRequestDto app)
        {
            var userId = this.userContext.UserId.Value;

            await appService.AddApplicationAsync(app, userId);
        }

        [HttpPut("{id:int}")]
        public async Task PutApplicationAsync(int id, Application app)
        {
           await appService.UpdateApplicationAsync(id, app);
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteApplicationAsync(int id)
        {
            await appService.DeleteApplicationAsync(id);
        }
    }
}
