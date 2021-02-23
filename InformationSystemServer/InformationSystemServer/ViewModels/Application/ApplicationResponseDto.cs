using InformationSystemServer.Data.Enums;

namespace InformationSystemServer.ViewModels.Application
{
    public class ApplicationResponseDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ApplicationType ApplicationType { get; set; }

        public StatusType Status { get; set; }

        public string Municipality { get; set; }

        public string Region { get; set; }

        public int UserId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
