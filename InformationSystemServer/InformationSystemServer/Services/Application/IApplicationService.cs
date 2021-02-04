using InformationSystemServer.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services
{
    public interface IApplicationService
    {
        public IEnumerable<Application> GetAllApplications();
        public Application GetApplicationById(int id);
        public Task<Application> AddApplicationAsync(Application application);
    }
}
