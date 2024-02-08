using System.Security.Cryptography;
using System.Text;
using WebApplication1.Interfaces;
using WebApplication1.Models.DTOS;
using WebApplication1.Models;

namespace WebApplication1.Services
{
        public class UserService : IUserService
        {
            private readonly IRepository<string, Users> _repository;
            private readonly ITokenService _tokenService;
            public UserService(IRepository<string, Users> repository, ITokenService tokenService)
            {
                _repository = repository;
                _tokenService = tokenService;
            }

            public UserDTO Login(UserDTO userDTO)
            {
                var user = _repository.GetById(userDTO.Username);
                if (user != null)
                {
                    HMACSHA512 hmac = new HMACSHA512(user.Key);
                    var userpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                    for (int i = 0; i < userpass.Length; i++)
                    {
                        if (user.Password[i] != userpass[i])
                            return null;
                    }
                    userDTO.Role = user.Role;
                    userDTO.Token = _tokenService.GetToken(userDTO);
                    userDTO.Password = "";



                    return userDTO;
                }
                return null;
            }

            public UserDTO Register(UserDTO userDTO)
            {
                HMACSHA512 hmac = new HMACSHA512();
                Users user = new Users()
                {
                    Username = userDTO.Username,
                    Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password)),
                    Key = hmac.Key,
                    Role = userDTO.Role
                };

                var result = _repository.Add(user);
                if (result != null)
                {
                    userDTO.Password = "";
                    return userDTO;
                }
                return null;
            }
        }
    }
