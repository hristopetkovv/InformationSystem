using InformationSystemServer.Data.Models;

namespace InformationSystemServer.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
