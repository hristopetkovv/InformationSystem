using InformationSystemServer.Data.Enums;

namespace InformationSystemServer.Data.Models
{
    public class QualificatonInformation
    {
        public int Id { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int DurationDays { get; set; }

        public string Description { get; set; }

        public TypeQualification TypeQualification { get; set; }

        public int ApplicationId { get; set; }

        public Application Application { get; set; }
    }
}
