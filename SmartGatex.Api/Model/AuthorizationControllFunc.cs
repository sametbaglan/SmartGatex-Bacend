using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace SmartGatex.Api.Model
{
    public class AuthorizationControllFunc
    {
        public static string getuserid(string Authorization)
        {
            if (!string.IsNullOrEmpty(Authorization) && Authorization.StartsWith("Bearer ") == true)
            {
                var handler = new JwtSecurityTokenHandler();
                var decodedValue = handler.ReadJwtToken(Authorization.Replace("Bearer ", ""));

                var token = decodedValue.Payload.Where(x => x.Key == "userId").FirstOrDefault();

                return token.Value.ToString();
            }
            else
            {
                return "";
            }
    

        }
    }
}