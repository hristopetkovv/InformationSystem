using InformationSystemServer.Data.Enums;
using System.Collections.Generic;

namespace InformationSystemServer.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordSalt { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Application> Applications { get; set; } = new HashSet<Application>();
    }
}
