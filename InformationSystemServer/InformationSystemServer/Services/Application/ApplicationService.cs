using System;
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

        public async Task<ApplicationDetailsResponseDto> GetApplicationByIdAsync(int id)
        {
            var application = await this.context
               .Applications
               .Where(app => app.Id == id)
               .Select(app => new ApplicationDetailsResponseDto
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
                   QualificationInformation = app.QualificatonInformation
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

                application.QualificatonInformation.Add(newQualification);
            }

            context.Applications.Add(application);
            await context.SaveChangesAsync();

            return application;
        }

        public async Task DeleteApplicationAsync(int id)
        {
            var app = await context.Applications.Where(a => a.Id == id).SingleOrDefaultAsync();
            context.Applications.Remove(app);
            await context.SaveChangesAsync();
        }

        public async Task UpdateApplicationAsync(int id, Application app)
        {
            var existingApp = await context.Applications.Where(c => c.Id == id).SingleOrDefaultAsync();
            existingApp.FirstName = app.FirstName;
            existingApp.LastName = app.LastName;
            existingApp.QualificatonInformation = app.QualificatonInformation;
            existingApp.Status = app.Status;

            await context.SaveChangesAsync();
        }

        //public void ChangeStatus(int id, string status)
        //{

        //}

    }
}
