using InformationSystemServer.Data.Models;

namespace InformationSystemServer.Services.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
