using InformationSystemServer.Data.Models;
using InformationSystemServer.ViewModels.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services
{
    public interface IApplicationService
    {
        public Task<IEnumerable<ApplicationResponseDto>> GetAllApplicationsAsync();

        public Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id);

        public Task<Application> AddApplicationAsync(ApplicationRequestDto dto, int userId);

        public Task UpdateApplicationAsync(int id, ApplicationDetailsDto app);

        public Task DeleteApplicationAsync(int id);
    }
}
