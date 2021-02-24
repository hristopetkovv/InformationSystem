using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using InformationSystemServer.Data.Enums;
using InformationSystemServer.Services.Services.Helpers;
using InformationSystemServer.Services.ViewModels.Application;
using InformationSystemServer.Services.ExtensionMethods;

namespace InformationSystemServer.Services.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly AppDbContext context;
        private readonly UserContext userContext;

        public ApplicationService(AppDbContext context, UserContext userContext)
        {
            this.context = context;
            this.userContext = userContext;
        }

        public async Task<IEnumerable<ApplicationResponseDto>> GetAllApplicationsAsync(ApplicationSearchFilterDto filter)
        {
            var applications = await this.context
                .Applications
                .FilterApplications(filter)
                .Select(app => new ApplicationResponseDto
                {
                    Id = app.Id,
                    FirstName = app.FirstName,
                    LastName = app.LastName,
                    City = app.City,
                    Region = app.Region,
                    Street = app.Street,
                    Municipality = app.Municipality,
                    ApplicationType = app.ApplicationType,
                    UserId = app.UserId,
                    Status = app.Status,
                })
                .OrderBy(x => x.FirstName)
                .ToListAsync();

            return applications;
        }

        public async Task<ApplicationDetailsDto> GetApplicationByIdAsync(int id)
        {
            var application = await this.context
               .Applications
               .Where(app => app.Id == id)
               .Select(app => new ApplicationDetailsDto
               {
                   Id = app.Id,
                   FirstName = app.FirstName,
                   LastName = app.LastName,
                   City = app.City,
                   Region = app.Region,
                   Municipality = app.Municipality,
                   Street = app.Street,
                   ApplicationType = app.ApplicationType,
                   Status = app.Status,
                   UserFirstName = app.User.FirstName,
                   UserId = app.UserId,
                   UserLastName = app.User.LastName,
                   QualificationInformation = app.QualificationInformation
                       .Select(q => new QualificationDto
                       {
                           QualificationId = q.Id,
                           StartDate = q.StartDate.Date,
                           EndDate = q.EndDate.Date,
                           Description = q.Description,
                           DurationDays = q.DurationDays,
                           TypeQualification = q.TypeQualification
                       })
               }).SingleOrDefaultAsync();

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
            var application = new Application
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Status = StatusType.Draft,
                ApplicationType = dto.ApplicationType,
                Street = dto.Street,
                City = dto.City,
                Municipality = dto.Municipality,
                Region = dto.Region,
                UserId = userId
            };

            foreach (var qualification in dto.QualificationInformation)
            {
                var newQualification = new QualificationInformation
                {
                    TypeQualification = qualification.TypeQualification,
                    StartDate = qualification.StartDate.Date,
                    EndDate = qualification.EndDate.Date,
                    DurationDays = qualification.DurationDays,
                    Description = qualification.Description,
                    ApplicationId = application.Id
                };

                application.QualificationInformation.Add(newQualification);
            }

            this.context.Applications.Add(application);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteApplicationAsync(int id)
        {
            var application = await context
                .Applications
                .SingleOrDefaultAsync(a => a.Id == id);

            if (this.IsAdministrator() || this.IsApplicationAuthor(application.UserId))
            {
                this.context.Applications.Remove(application);
                await this.context.SaveChangesAsync();
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

            var existingApp = await context
                .Applications
                .SingleOrDefaultAsync(app => app.Id == id);

            existingApp.FirstName = application.FirstName;
            existingApp.LastName = application.LastName;
            existingApp.Municipality = application.Municipality;
            existingApp.Region = application.Region;
            existingApp.City = application.City;
            existingApp.Street = application.Street;
            existingApp.ApplicationType = application.ApplicationType;

            var existingQualifications = await this.context
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
                this.context.QualificationsInformation.RemoveRange(forDelete);
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

            await this.context.SaveChangesAsync();
        }

        public async Task ChangeStatusAsync(int applicationId, StatusType status)
        {
            var application = await this.context.Applications.SingleOrDefaultAsync(app => app.Id == applicationId);

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

            await this.context.SaveChangesAsync();
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
