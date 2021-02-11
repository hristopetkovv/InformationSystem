using InformationSystemServer.Services.Reference;
using InformationSystemServer.ViewModels.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class ReferenceController : BaseApiController
    {
        private readonly IReferenceService referenceService;

        public ReferenceController(IReferenceService referenceService)
        {
            this.referenceService = referenceService;
        }

        [HttpGet]
        public async Task<IEnumerable<ReferenceResponseDto>> GetReferences()
        {
            return await this.referenceService.GetReferencesAsync();
        }
    }
}
