using System;
using InformationSystemServer.Data;
using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            context.Applications.Add(application);
            await context.SaveChangesAsync();
            return application;
        }

       
    }
}
