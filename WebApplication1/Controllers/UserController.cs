using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;
using WebApplication1.Models.DTOS;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
        {
            private readonly IUserService _userService;
            /// <summary>
            /// Initializes a new instance of the <see cref="UserController"/> class.
            /// </summary>
            /// <param name="userService">The service for managing user-related operations.</param>

            public UserController(IUserService userService)
            {
                _userService = userService;
            }
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="viewModel">The data for user registration.</param>
        /// <returns>The result of the registration operation.</returns>

        [HttpPost]
        [Route("Register")]
            public ActionResult Register(UserDTO viewModel)
            {
                string message = "";
                try
                {
                    var user = _userService.Register(viewModel);
                    if (user != null)
                    {
                        return Ok(user);
                    }
                }
                catch (DbUpdateException exp)
                {
                    message = "Duplicate username";
                }
                catch (Exception)
                {

                }

                return BadRequest(message);
            }
            /// <summary>
            /// Logs in a user.
            /// </summary>
            /// <param name="userDTO">The data for user login.</param>
            /// <returns>The result of the login operation.</returns>

            [HttpPost]
            [Route("Login")]//attribute based routing
            public ActionResult Login(UserDTO userDTO)
            {
                var result = _userService.Login(userDTO);
                if (result != null)
                {
                    return Ok(result);
                }
                return Unauthorized("Invalid username or password");
            }

        }
    }
