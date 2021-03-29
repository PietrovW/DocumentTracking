using DocumentTracking.Data;
using DocumentTracking.Infrastructure.Services;
using DocumentTracking.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentTracking.Infrastructure.QuerieHandler
{
    public class LoginQuerieHandler : IRequestHandler<LoginQuerie, LoginQuerieResponse>
    {
        private readonly UserManager<ApplicationUser> userManager;
        public readonly IJWTTokenHandler tokenService;
        public LoginQuerieHandler(UserManager<ApplicationUser> userManager, IJWTTokenHandler tokenService)
        {
            this.userManager = userManager;
           this.tokenService = tokenService;
        }

        public async Task<LoginQuerieResponse> Handle(LoginQuerie request, CancellationToken cancellationToken)
        {
            LoginQuerieResponse loginQuerieResponse = new LoginQuerieResponse();
            var user = await userManager.FindByNameAsync(request.Email);
            
            if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
            {
                // var token = userManager.GenerateUserTokenAsync(user, "PasswordlessLoginTotpProvider", "passwordless-auth");
                loginQuerieResponse.Token = tokenService.GenerateToken(user).Token;
            }
            return loginQuerieResponse;
        }

        private string GenerateToken(LoginQuerie user)
        {
            var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecureKey"));

            var token = new JwtSecurityToken(
                //issuer: "http://dotnetdetail.net",
                //audience: "http://dotnetdetail.net",
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        


    }
}
