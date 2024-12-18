using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SassoInmobiliariaAPI.Services.DTOs;
using SassoInmobiliariaAPI.Services.Interfaces;
using AuthService = SassoInmobiliariaAPI.Services.Interfaces.IAuthenticationService;


namespace SassoInmobiliariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthService _authenticationService; 
       
        public AuthenticationController(AuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        public ActionResult<string> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            try
            {
                string token = _authenticationService.Authenticate(authenticationRequest);
                return Ok(token);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}
