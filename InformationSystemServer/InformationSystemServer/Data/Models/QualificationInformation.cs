using InformationSystemServer.Infrastructure.Enums;
using System;

namespace InformationSystemServer.Data.Models
{
    public class QualificationInformation
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DurationDays { get; set; }

        public string Description { get; set; }

        public TypeQualification TypeQualification { get; set; }

        public int ApplicationId { get; set; }

        public Application Application { get; set; }
    }
}
