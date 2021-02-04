using System;
using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationSystemServer.Data.Enums;

namespace InformationSystemServer.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly AppDbContext context;
        public ApplicationService(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Application> GetAllApplications()
        {
            return context.Applications.ToList();
        }

        public Application GetApplicationById(int id)
        {
            return context.Applications.Where(a => a.Id == id).SingleOrDefault();
        }

        public async Task<Application> AddApplicationAsync(Application application)
        {
            application.Status = StatusType.Draft;
            context.Applications.Add(application);
            await context.SaveChangesAsync();
            return application;
        }

        public async Task DeleteApplicationAsync(int id)
        {
            var app = context.Applications.Where(a => a.Id == id).SingleOrDefault();
            context.Applications.Remove(app);
            await context.SaveChangesAsync();
        }

        public async Task UpdateApplicationAsync(int id, Application app)
        {
            var existingApp = context.Applications.Where(c => c.Id == id).SingleOrDefault();
            existingApp.FirstName = app.FirstName;
            existingApp.LastName = app.LastName;
            existingApp.AddressId = app.AddressId;
            existingApp.QualificatonInformation = app.QualificatonInformation;
            existingApp.Status = app.Status;
            existingApp.Address = app.Address;

            await context.SaveChangesAsync();
        }

        //public void ChangeStatus(int id, string status)
        //{

        //}

    }
}
