using InformationSystemServer.Enums;
using System.Collections.Generic;

namespace InformationSystemServer.ViewModels.Application
{
    public class ApplicationRequestDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ApplicationType ApplicationType { get; set; }

        public string Municipality { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public virtual ICollection<QualificationDto> QualificationInformation { get; set; }
    }
}
