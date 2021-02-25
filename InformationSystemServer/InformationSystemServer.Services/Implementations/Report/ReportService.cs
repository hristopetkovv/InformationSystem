using AutoMapper;
using AutoMapper.QueryableExtensions;
using InformationSystemServer.Data;
using InformationSystemServer.Services.ExtensionMethods;
using InformationSystemServer.Services.ViewModels.Application;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Implementations.Report
{
    public class ReportService : IReportService
    { 
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public ReportService(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ReportResponseDto>> GetReportsAsync(ApplicationSearchFilterDto filter)
        {
            var reports = await this.dbContext
                .Applications
                .FilterApplications(filter)
                .ProjectTo<ReportResponseDto>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.FirstName)
                .ToListAsync();

            return reports;
        }
    }
}
