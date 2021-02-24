using InformationSystemServer.Services.ViewModels.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Services.Report
{
    public interface IReportService
    {
        Task<IEnumerable<ReportResponseDto>> GetReportsAsync(ApplicationSearchFilterDto filter);
    }
}
