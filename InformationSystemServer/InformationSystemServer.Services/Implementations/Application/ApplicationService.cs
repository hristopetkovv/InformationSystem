using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using InformationSystemServer.Data.Enums;
using InformationSystemServer.Services.ViewModels.Application;
using InformationSystemServer.Services.ExtensionMethods;
using InformationSystemServer.Services.Implementations.Helpers;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace InformationSystemServer.Services.Implementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly AppDbContext dbContext;
        private readonly UserContext userContext;
        private readonly IMapper mapper;

        public ApplicationService(AppDbContext dbContext, UserContext userContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userContext = userContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationResponseDto>> GetAllApplicationsAsync(ApplicationSearchFilterDto filter)
        {
            var applications = await this.dbContext
                .Applications
                .FilterApplications(filter)
                .ProjectTo<ApplicationResponseDto>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.FirstName)
                .ToListAsync();

            return applications;
        }

        public async Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id)
        {
            var application = await this.dbContext
               .Applications
               .Where(app => app.Id == id)
               .ProjectTo<ApplicationDetailsDto>(this.mapper.ConfigurationProvider)
               .SingleOrDefaultAsync();

            if (this.IsAdministrator() || this.IsApplicationAuthor(application.UserId))
            {
                return application;
            }
            else
            {
                throw new InvalidOperationException("You cannot delete this application!");
            }
        }

        public async Task AddApplicationAsync(ApplicationRequestDto dto, int userId)
        {
            var application = this.mapper.Map<Application>(dto);
            application.UserId = userId;
            application.Status = StatusType.Draft;

            this.dbContext.Applications.Add(application);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteApplicationAsync(int id)
        {
            var application = await dbContext
                .Applications
                .SingleOrDefaultAsync(a => a.Id == id);

            if (this.IsAdministrator() || this.IsApplicationAuthor(application.UserId))
            {
                this.dbContext.Applications.Remove(application);
                await this.dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("You cannot delete this application!");
            }
        }

        public async Task UpdateApplicationAsync(int id, ApplicationDetailsDto application)
        {
            if (this.IsAdministrator() && this.IsApplicationAuthor(application.UserId))
            {
                throw new InvalidOperationException("You cannot update this application!");
            }

            var existingApp = await this.dbContext
                .Applications
                .SingleOrDefaultAsync(app => app.Id == id);

            existingApp.FirstName = application.FirstName;
            existingApp.LastName = application.LastName;
            existingApp.Municipality = application.Municipality;
            existingApp.Region = application.Region;
            existingApp.City = application.City;
            existingApp.Street = application.Street;
            existingApp.ApplicationType = application.ApplicationType;

            var existingQualifications = await this.dbContext
                .QualificationsInformation
                .Where(q => q.ApplicationId == application.Id)
                .ToListAsync();

            var forAdd = application.QualificationInformation.Where(q => !existingQualifications.Any(eq => eq.Id == q.QualificationId));

            if (forAdd.Any())
            {
                foreach (var qualification in forAdd)
                {
                    var newQualification = new QualificationInformation
                    {
                        StartDate = qualification.StartDate,
                        EndDate = qualification.EndDate,
                        DurationDays = qualification.DurationDays,
                        Description = qualification.Description,
                        TypeQualification = qualification.TypeQualification,
                        ApplicationId = application.Id
                    };

                    existingApp.QualificationInformation.Add(newQualification);
                }
            }

            var forDelete = existingQualifications.Where(eq => !application.QualificationInformation.Any(qi => qi.QualificationId == eq.Id));

            if (forDelete.Any())
            {
                this.dbContext.QualificationsInformation.RemoveRange(forDelete);
            }

            var forUpdate = existingQualifications.Where(eq => application.QualificationInformation.Any(qi => qi.QualificationId == eq.Id));

            foreach (var qualificationToUpdate in forUpdate)
            {
                var qualification = application.QualificationInformation.Single(q => q.QualificationId == qualificationToUpdate.Id);

                qualificationToUpdate.Description = qualification.Description;
                qualificationToUpdate.StartDate = qualification.StartDate;
                qualificationToUpdate.EndDate = qualification.EndDate;
                qualificationToUpdate.DurationDays = qualification.DurationDays;
                qualificationToUpdate.TypeQualification = qualification.TypeQualification;
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task ChangeStatusAsync(int applicationId, StatusType status)
        {
            var application = await this.dbContext.Applications.SingleOrDefaultAsync(app => app.Id == applicationId);

            if (application.Status == StatusType.InProcess)
            {
                bool isAdmin = this.IsAdministrator();

                if (!isAdmin)
                {
                    throw new InvalidOperationException("You are not an administrator!");
                }
            }
            else if (application.Status == StatusType.Draft)
            {
                bool isCreator = this.IsApplicationAuthor(application.UserId);

                if (!isCreator)
                {
                    throw new InvalidOperationException("You are not a creator of this application!");
                }
            }

            application.Status = status;

            await this.dbContext.SaveChangesAsync();
        }

        private bool IsAdministrator()
        {
            var userRole = this.userContext.Role;

            if (userRole != Role.Admin.ToString())
            {
                return false;
            }

            return true;
        }

        private bool IsApplicationAuthor(int creatorId)
        {
            var userId = this.userContext.UserId.Value;

            if (userId != creatorId)
            {
                return false;
            }

            return true;
        }
    }
}
