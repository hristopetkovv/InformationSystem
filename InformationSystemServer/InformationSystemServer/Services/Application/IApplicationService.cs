﻿using InformationSystemServer.Infrastructure.Enums;
using InformationSystemServer.ViewModels.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationResponseDto>> GetAllApplicationsAsync(ApplicationSearchFilterDto filter);

        Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id);

        Task AddApplicationAsync(ApplicationRequestDto dto, int userId);

        Task UpdateApplicationAsync(int id, ApplicationDetailsDto application);

        Task DeleteApplicationAsync(int id);

        Task ChangeStatusAsync(int applicationId, StatusType status);
    }
}