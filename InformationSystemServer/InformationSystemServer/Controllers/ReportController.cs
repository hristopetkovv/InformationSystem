using InformationSystemServer.Services.Reference;
using InformationSystemServer.ViewModels.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Controllers
{
    public class ReportController : BaseApiController
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet]
        public async Task<IEnumerable<ReportResponseDto>> GetReports([FromQuery] SearchFilterDto filter)
        {
            return await this.reportService.GetReportsAsync(filter);
        }
    }
}
