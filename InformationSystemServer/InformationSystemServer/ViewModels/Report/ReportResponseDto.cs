using InformationSystemServer.Enums;

namespace InformationSystemServer.ViewModels.Application
{
    public class ReportResponseDto
    {
        public int ApplicationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Municipality { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int TotalCourseDays { get; set; }

        public int TotalInternshipDays { get; set; }

        public StatusType Status { get; set; }
    }
}
