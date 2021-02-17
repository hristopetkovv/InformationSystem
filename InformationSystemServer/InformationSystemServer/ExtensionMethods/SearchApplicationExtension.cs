using InformationSystemServer.Data.Models;
using InformationSystemServer.ViewModels.Application;
using System.Linq;

namespace InformationSystemServer.ExtensionMethods
{
    public static class SearchApplicationExtension
    {
        public static IQueryable<Application> FilterApplications(this IQueryable<Application> applications, ApplicationSearchFilterDto filter)
        {
            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                applications = applications.Where(app => app.FirstName.ToLower().Contains(filter.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.LastName))
            {
                applications = applications.Where(app => app.LastName.ToLower().Contains(filter.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.City))
            {
                applications = applications.Where(app => app.City.ToLower().Contains(filter.City.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Municipality))
            {
                applications = applications.Where(app => app.Municipality.ToLower().Contains(filter.Municipality.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Region))
            {
                applications = applications.Where(app => app.Region.ToLower().Contains(filter.Region.ToLower()));
            }

            if (filter.Status.HasValue)
            {
                applications = applications.Where(app => app.Status == filter.Status.Value);
            }

            return applications;
        }
    }
}
