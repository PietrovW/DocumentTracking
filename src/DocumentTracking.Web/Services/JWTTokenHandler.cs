using DocumentTracking.Data;
using DocumentTracking.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DocumentTracking.Infrastructure.Services
{
    public class JWTTokenHandler : IJWTTokenHandler
    {
        private readonly IOptions<TokenManagement> tokenManagement;
        public JWTTokenHandler(IOptions<TokenManagement> tokenManagement)
        {
            this.tokenManagement = tokenManagement;
        }

        public AccessTokenModel GenerateToken(ApplicationUser applicationUser)
        {
            AccessTokenModel accessTokenModel = new AccessTokenModel();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Value.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();

            SigningCredentials creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, $"{applicationUser.Id}"),
                    new Claim(ClaimTypes.Email, applicationUser.Email),
                    new Claim(ClaimTypes.GivenName, applicationUser.NormalizedUserName)
                }),
                Expires = DateTime.UtcNow.AddDays(tokenManagement.Value.AccessExpiration),
                SigningCredentials = credentials,
                Issuer = tokenManagement.Value.Issuer,
                Audience = tokenManagement.Value.Audience
                
            };
            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            accessTokenModel.Token = tokenHandler.WriteToken(stoken);
            accessTokenModel.ExpireOnDate = tokenDescriptor.Expires.Value;
            return accessTokenModel;
        }
        
        public  bool VerifyToken(string token)
        {
            var validationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(tokenManagement.Value.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken = null;
            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (SecurityTokenException)
            {
                return false;
            }
            catch (Exception e)
            {
                throw;
            }
            return validatedToken != null;
        }
    }
}


//var tokenHandler = new JWTSecurityTokenHandler();

//var symmetricKey = GetRandomBytes(256 / 8);



//var now = DateTime.UtcNow;

//var tokenDescriptor = new SecurityTokenDescriptor

//{

//    Subject = new ClaimsIdentity(new Claim[]

//            {

//                            new Claim(ClaimTypes.Name, "Pedro"),

//                            new Claim(ClaimTypes.Role, "Author"),

//            }),

//    TokenIssuerName = "self",

//    AppliesToAddress = "http://www.example.com",

//    Lifetime = new Lifetime(now, now.AddMinutes(2)),

//    SigningCredentials = new SigningCredentials(

//            new InMemorySymmetricSecurityKey(symmetricKey),

//            "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",

//            "http://www.w3.org/2001/04/xmlenc#sha256"),





//};

//var token = tokenHandler.CreateToken(tokenDescriptor);



//var tokenString = tokenHandler.WriteToken(token);

//Console.WriteLine(tokenString);

            

            

//Assert.True(principal.Identities.First().Claims

//    .Any(c => c.Type == ClaimTypes.Name && c.Value == "Pedro"));

//            Assert.True(principal.Identities.First().Claims

//                .Any(c => c.Type == ClaimTypes.Role && c.Value == "Author"));