using System.Collections.Generic;
using System.Threading.Tasks;
using InformationSystemServer.Data.Models;
using InformationSystemServer.Services;
using InformationSystemServer.Services.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystemServer.Controllers
{
    public class ApplicationController : BaseApiController
    {
        private readonly IApplicationService appService;

        public ApplicationController(IApplicationService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public IEnumerable<Application> GetApplications()
        {
            return appService.GetAllApplications();
        }

        [HttpGet("{id:int}")]
        public Application GetApplication(int id)
        {
            return appService.GetApplicationById(id);
        }

        [HttpPost]
        public async Task<Application> PostApplication(Application app)
        {
            return await appService.AddApplicationAsync(app);
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
