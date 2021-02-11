using InformationSystemServer.ViewModels.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Reference
{
    public interface IReferenceService
    {
        Task<IEnumerable<ReferenceResponseDto>> GetReferencesAsync();
    }
}
