using Microsoft.Extensions.Options;
using SassoInmobiliariaAPI.Services.DTOs;
using SassoInmobiliariaAPI.Services.Interfaces;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using SassoInmobiliariaAPI.Data.Interfaces;
using SassoInmobiliariaAPI.Models.Entities;
namespace SassoInmobiliariaAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly AutenticacionServiceOptions _options;

        public AuthenticationService(IAdminRepository adminRepository, IOptions<AutenticacionServiceOptions> options)
        {
            _adminRepository = adminRepository;
            _options = options.Value;
        }

        private Admin? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var user = _adminRepository.CheckUsername(authenticationRequest.UserName);

            if (user == null) return null;

            if (user.Password == authenticationRequest.Password)
            {
                return user;
            }

            return null;

        }
        public string Authenticate(AuthenticationRequest authenticationRequest)
        {
            var user = ValidateUser(authenticationRequest); 

            if (user == null)
            {
                throw new UnauthorizedAccessException("Fallo en la autenticación del usuario");
            }

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); 
            claimsForToken.Add(new Claim("given_name", user.Username)); 
           

            var jwtSecurityToken = new JwtSecurityToken(
              _options.Issuer,
              _options.Audience,
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }

        public class AutenticacionServiceOptions
        {
            public const string AutenticacionService = "AutenticacionService";

            public string Issuer { get; set; }
            public string Audience { get; set; }
            public string SecretForKey { get; set; }
        }

    }
}
