using WebApplication1.Models.DTOS;

namespace WebApplication1.Interfaces
{
    public interface IUserService
    {
        UserDTO Register(UserDTO userDTO);
        UserDTO Login(UserDTO userDTO);
    }
}
