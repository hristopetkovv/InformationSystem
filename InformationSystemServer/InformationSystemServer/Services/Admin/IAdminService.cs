using InformationSystemServer.ViewModels.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InformationSystemServer.Services.Admin
{
    public interface IAdminService
    {
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
