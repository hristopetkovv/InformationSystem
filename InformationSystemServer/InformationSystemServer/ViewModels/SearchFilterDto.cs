using InformationSystemServer.Data.Enums;

namespace InformationSystemServer.ViewModels.Application
{
    public class SearchFilterDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Municipality { get; set; }

        public string Region { get; set; }

        public StatusType? Status { get; set; }
    }
}
