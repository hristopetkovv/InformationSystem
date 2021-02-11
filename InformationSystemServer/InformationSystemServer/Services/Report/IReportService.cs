using InformationSystemServer.ViewModels.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Reference
{
    public interface IReportService
    {
        Task<IEnumerable<ReportResponseDto>> GetReportsAsync(SearchFilterDto filter);
    }
}
