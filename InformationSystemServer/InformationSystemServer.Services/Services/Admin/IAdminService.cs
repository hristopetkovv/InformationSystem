using InformationSystemServer.Services.ViewModels.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Services.Admin
{
    public interface IAdminService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task MakeAdmin(int userId);
    }
}
