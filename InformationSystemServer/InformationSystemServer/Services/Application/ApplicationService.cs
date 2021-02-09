using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationSystemServer.Data.Enums;
using InformationSystemServer.ViewModels.Application;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemServer.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly AppDbContext context;
        public ApplicationService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ApplicationResponseDto>> GetAllApplicationsAsync()
        {
            var applications = await this.context
                .Applications
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
                    Status = app.Status,
                }).ToListAsync();

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

            return application;
        }

        public async Task<Application> AddApplicationAsync(ApplicationRequestDto dto, int userId)
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

            return application;
        }

        public async Task DeleteApplicationAsync(int id)
        {
            var app = await context
                .Applications
                .SingleOrDefaultAsync(a => a.Id == id);

            this.context.Applications.Remove(app);

            await this.context.SaveChangesAsync();
        }

        public async Task UpdateApplicationAsync(int applicationId, ApplicationDetailsDto dto)
        {
            var existingApp = await context
                .Applications
                .SingleOrDefaultAsync(app => app.Id == applicationId);

            existingApp.FirstName = dto.FirstName;
            existingApp.LastName = dto.LastName;
            existingApp.Municipality = dto.Municipality;
            existingApp.Region = dto.Region;
            existingApp.City = dto.City;
            existingApp.Street = dto.Street;
            existingApp.ApplicationType = dto.ApplicationType;

            var existingQualifications = await this.context
                .QualificationsInformation
                .Where(q => q.ApplicationId == dto.Id)
                .ToListAsync();

            var forAdd = dto.QualificationInformation.Where(q => !existingQualifications.Any(eq => eq.Id == q.QualificationId));

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
                        ApplicationId = dto.Id
                    };

                    existingApp.QualificationInformation.Add(newQualification);
                }
            }

            var forDelete = existingQualifications.Where(eq => !dto.QualificationInformation.Any(qi => qi.QualificationId == eq.Id));

            if (forDelete.Any())
            {
                this.context.QualificationsInformation.RemoveRange(forDelete);
            }

            var forUpdate = existingQualifications.Where(eq => dto.QualificationInformation.Any(qi => qi.QualificationId == eq.Id));

            foreach (var qualificationToUpdate in forUpdate)
            {
                var qualification = dto.QualificationInformation.Single(q => q.QualificationId == qualificationToUpdate.Id);

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

            application.Status = status;

            await this.context.SaveChangesAsync();
        }
    }
}
