using InformationSystemServer.Infrastructure.Enums;
using System.Collections.Generic;

namespace InformationSystemServer.ViewModels.Application
{
    public class ApplicationDetailsDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ApplicationType ApplicationType { get; set; }

        public StatusType Status { get; set; }

        public string Municipality { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int UserId { get; set; }

        public string UserFirstName { get; set; }

        public string UserLastName { get; set; }

        public virtual IEnumerable<QualificationDto> QualificationInformation { get; set; }
    }
}
