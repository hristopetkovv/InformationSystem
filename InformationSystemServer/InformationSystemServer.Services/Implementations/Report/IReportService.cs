using InformationSystemServer.Services.ViewModels.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Implementations.Report
{
    public interface IReportService
    {
        Task<IEnumerable<ReportResponseDto>> GetReportsAsync(ApplicationSearchFilterDto filter);
    }
}
