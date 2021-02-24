using ClosedXML.Excel;
using InformationSystemServer.Services.Implementations.Report;
using InformationSystemServer.Services.ViewModels.Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IEnumerable<ReportResponseDto>> GetReports([FromQuery] ApplicationSearchFilterDto filter)
        {
            return await this.reportService.GetReportsAsync(filter);
        }

        [HttpGet("excel")]
        public async Task<IActionResult> ExportExcel([FromQuery] ApplicationSearchFilterDto filter)
        {
            var reports = await this.reportService.GetReportsAsync(filter);

            return this.ConvertToExcel(reports);
        }

        private IActionResult ConvertToExcel(IEnumerable<ReportResponseDto> reports)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Applications");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "First Name";
                worksheet.Cell(currentRow, 2).Value = "Last Name";
                worksheet.Cell(currentRow, 3).Value = "Municipality";
                worksheet.Cell(currentRow, 4).Value = "Region";
                worksheet.Cell(currentRow, 5).Value = "City";
                worksheet.Cell(currentRow, 6).Value = "Street";
                worksheet.Cell(currentRow, 7).Value = "Total Course Days";
                worksheet.Cell(currentRow, 8).Value = "Total Internship Days";
                worksheet.Cell(currentRow, 9).Value = "Status";

                foreach (var report in reports)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = report.FirstName;
                    worksheet.Cell(currentRow, 2).Value = report.LastName;
                    worksheet.Cell(currentRow, 3).Value = report.Municipality;
                    worksheet.Cell(currentRow, 4).Value = report.Region;
                    worksheet.Cell(currentRow, 5).Value = report.City;
                    worksheet.Cell(currentRow, 6).Value = report.Street;
                    worksheet.Cell(currentRow, 7).Value = report.TotalCourseDays;
                    worksheet.Cell(currentRow, 8).Value = report.TotalInternshipDays;
                    worksheet.Cell(currentRow, 9).Value = report.Status.ToString();
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Response.ContentType = contentType;
                    HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

                    return File(
                        content,
                        contentType,
                        "reports.xlsx");
                }
            }
        }
    }
}
