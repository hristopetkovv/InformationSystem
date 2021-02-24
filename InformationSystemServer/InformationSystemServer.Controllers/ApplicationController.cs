using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ClosedXML.Excel;
using InformationSystemServer.Services.Implementations;
using InformationSystemServer.Services.Implementations.Helpers;
using InformationSystemServer.Services.ViewModels.Application;
using Microsoft.AspNetCore.Mvc;

namespace InformationSystemServer.Controllers
{
    public class ApplicationController : BaseApiController
    {
        private readonly IApplicationService appService;
        private readonly UserContext userContext;

        public ApplicationController(IApplicationService appService, UserContext userContext)
        {
            this.appService = appService;
            this.userContext = userContext;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationResponseDto>> GetApplications([FromQuery] ApplicationSearchFilterDto filter)
        {
            return await this.appService.GetAllApplicationsAsync(filter);
        }

        [HttpGet("{id:int}")]
        public async Task<ApplicationDetailsDto> GetApplication(int id)
        {
            return await this.appService.GetApplicationByIdAsync(id);
        }

        [HttpPost]
        public async Task PostApplication(ApplicationRequestDto app)
        {
            var userId = this.userContext.UserId.Value;

            await this.appService.AddApplicationAsync(app, userId);
        }

        [HttpPut("{id:int}")]
        public async Task PutApplicationAsync(int id, ApplicationDetailsDto application)
        {
           await this.appService.UpdateApplicationAsync(id, application);
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteApplicationAsync(int id)
        {
            await this.appService.DeleteApplicationAsync(id);
        }

        [HttpGet("excel")]
        public async Task<IActionResult> ExportExcel([FromQuery] ApplicationSearchFilterDto filter)
        {
            var applications = await this.appService.GetAllApplicationsAsync(filter);

            return this.ConvertToExcel(applications);
        }

        private IActionResult ConvertToExcel(IEnumerable<ApplicationResponseDto> applications)
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
                worksheet.Cell(currentRow, 7).Value = "Status";

                foreach (var application in applications)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = application.FirstName;
                    worksheet.Cell(currentRow, 2).Value = application.LastName;
                    worksheet.Cell(currentRow, 3).Value = application.Municipality;
                    worksheet.Cell(currentRow, 4).Value = application.Region;
                    worksheet.Cell(currentRow, 5).Value = application.City;
                    worksheet.Cell(currentRow, 6).Value = application.Street;
                    worksheet.Cell(currentRow, 7).Value = application.Status.ToString();
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
