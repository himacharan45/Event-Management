using WebApplication1.Models.DTOS;

namespace WebApplication1.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
