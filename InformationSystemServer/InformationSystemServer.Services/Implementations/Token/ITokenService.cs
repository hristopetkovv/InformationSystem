using InformationSystemServer.Data.Models;

namespace InformationSystemServer.Services.Implementations.Token
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
