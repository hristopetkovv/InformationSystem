using InformationSystemServer.Enums;
using System.Collections.Generic;

namespace InformationSystemServer.Data.Models
{
    public class Application
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Municipality { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public StatusType Status { get; set; }

        public ApplicationType ApplicationType { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<QualificationInformation> QualificationInformation { get; set; } = new HashSet<QualificationInformation>();
    }
}
