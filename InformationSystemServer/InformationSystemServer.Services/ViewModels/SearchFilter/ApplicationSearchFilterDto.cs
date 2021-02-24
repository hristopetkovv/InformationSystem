
using InformationSystemServer.Data.Enums;

namespace InformationSystemServer.Services.ViewModels.Application
{
    public class ApplicationSearchFilterDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Municipality { get; set; }

        public string Region { get; set; }

        public StatusType? Status { get; set; }
    }
}