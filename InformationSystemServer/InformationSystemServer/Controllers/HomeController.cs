using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationSystemServer.Data.Models;
using InformationSystemServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IApplicationService appService;

        public HomeController(IApplicationService appService)
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
    }
}
