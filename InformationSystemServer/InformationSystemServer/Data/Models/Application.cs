using InformationSystemServer.Data.Enums;
using System.Collections.Generic;

namespace InformationSystemServer.Data.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual List<QualificatonInformation> QualificatonInformation { get; set; }
        public StatusType Status { get; set; }
        public User User { get; set; }
    }
}
