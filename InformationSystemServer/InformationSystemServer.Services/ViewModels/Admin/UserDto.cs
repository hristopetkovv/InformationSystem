using InformationSystemServer.Data.Enums;

namespace InformationSystemServer.Services.ViewModels.Admin
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }
    }
}
