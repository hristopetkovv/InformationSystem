using InformationSystemServer.Data;
using InformationSystemServer.Data.Enums;
using InformationSystemServer.ViewModels.Application;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Reference
{
    public class ReferenceService : IReferenceService
    {
        private readonly AppDbContext dbContext;

        public ReferenceService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<ReferenceResponseDto>> GetReferencesAsync()
        {
            var references = await this.dbContext
                .Applications
                .Select(app => new ReferenceResponseDto
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
                }).ToListAsync();

            return references;
        }
    }
}
