using SassoInmobiliariaAPI.Services.DTOs;

namespace SassoInmobiliariaAPI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string Authenticate(AuthenticationRequest authenticationRequest);
    }
}
