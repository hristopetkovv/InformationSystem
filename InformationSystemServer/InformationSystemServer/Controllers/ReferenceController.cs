using InformationSystemServer.Services;
using InformationSystemServer.ViewModels.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class ReferenceController : BaseApiController
    {
        private readonly IApplicationService applicationService;

        public ReferenceController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IEnumerable<ReferenceResponseDto>> GetReferences()
        {
            return await this.applicationService.GetReferencesAsync();
        }
    }
}
