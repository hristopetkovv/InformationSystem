using InformationSystemServer.Data.Enums;
using InformationSystemServer.Data.Models;
using InformationSystemServer.ViewModels.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationResponseDto>> GetAllApplicationsAsync();

        Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id);

        Task<Application> AddApplicationAsync(ApplicationRequestDto dto, int userId);

        Task UpdateApplicationAsync(int applicationId, ApplicationDetailsDto dto);

        Task DeleteApplicationAsync(int id);

        Task ChangeStatusAsync(int applicationId, StatusType status);
    }
}
