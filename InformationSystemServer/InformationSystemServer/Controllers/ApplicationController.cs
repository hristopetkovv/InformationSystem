using System.Collections.Generic;
using System.Threading.Tasks;
using InformationSystemServer.Data.Models;
using InformationSystemServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService appService;

        public ApplicationController(IApplicationService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        [AllowAnonymous]
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
        public async Task PutCarAsync(int id, Application app)
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
