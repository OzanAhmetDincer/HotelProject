using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");// Burada "program.cs" de oluşturduğumuz ilgili tokeni tanımlamamız gerek

            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);// "HmacSha256", jwt de token oluştururken kullanacağımız algoritma. Bunu jwt sayfasından bakıp seçebiliriz. Kendisi default olarak HmacSha256 olanını verir. Bu şifreleme algoritmasıdır.

            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(20), signingCredentials: credentials);// "issure" key bilgisini üreten, "audience" key bilgisini tüketen, "notBefore: DateTime.Now" ile şuandan önce oluşturulmuş olan, "expires: DateTime.Now.AddSeconds(20)" ile oluşturulan tokenin geçerlilik süresini belirledik, en sonunda da oluşturduğumuz token değeri

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);// "WriteToken(token)" ile tokeni oluşturacak
        }
        public string TokenCreateAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),// Role tanımlamalarını yaptık
                new Claim(ClaimTypes.Role,"Visitor")
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(30), signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }
    }
}
