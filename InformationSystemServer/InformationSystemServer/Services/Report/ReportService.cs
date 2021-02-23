using InformationSystemServer.Data;
using InformationSystemServer.Infrastructure.Enums;
using InformationSystemServer.ExtensionMethods;
using InformationSystemServer.ViewModels.Application;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Reference
{
    public class ReportService : IReportService
    { 
        private readonly AppDbContext dbContext;

        public ReportService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<ReportResponseDto>> GetReportsAsync(ApplicationSearchFilterDto filter)
        {
            var reports = await this.dbContext
                .Applications
                .FilterApplications(filter)
                .Select(app => new ReportResponseDto
                {
                    ApplicationId = app.Id,
                    FirstName = app.FirstName,
                    LastName = app.LastName,
                    Street = app.Street,
                    Municipality = app.Municipality,
                    Region = app.Region,
                    City = app.City,
                    Status = app.Status,
                    TotalCourseDays = app.QualificationInformation.Where(q => q.TypeQualification == TypeQualification.Course).Sum(app => app.DurationDays),
                    TotalInternshipDays = app.QualificationInformation.Where(q => q.TypeQualification == TypeQualification.Intership).Sum(app => app.DurationDays),
                })
                .OrderBy(x=>x.FirstName)
                .ToListAsync();

            return reports;
        }
    }
}
