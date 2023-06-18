using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using Microsoft.AspNetCore.Mvc;

namespace disability_map.Controllers
{
    public class AccessController : Controller
    {
        [ApiController]
        [Route("[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IAuthRepository _authRepo;

            public AuthController(IAuthRepository authRepo)
            {
                _authRepo = authRepo;
            }

            [HttpPost("Register")]
            public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterUserDto request)
            {
                var response = await _authRepo.Register(
                    new User { Email = request.Email }, request.Password
                );
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }

            [HttpPost("Login")]
            public async Task<ActionResult<ServiceResponse<int>>> Login(GetUserDto request)
            {
                var response = await _authRepo.Login(request.Email, request.Password);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
        }
    }
}
