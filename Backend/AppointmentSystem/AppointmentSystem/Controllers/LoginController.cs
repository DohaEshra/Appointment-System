using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using AppointmentSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppointmentSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        reservation_SysContext db;
        public LoginController(reservation_SysContext _db)
        {
            this.db = _db;
        }
        //login
        // POST api/<LoginController>
        [HttpPost]//string username, string password
        public IActionResult Login(string username,string password)
        {
            ;
            if (username == "Admin" && password == "Admin123")
            {
                return Ok(new {token= makeToken(username, password, "Admin"), role="Admin"});
            }
            else
            {
                User usr = db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
                if (usr != null)//user exists
                {
                    return Ok(new { token = makeToken(username, password, "User"), role = "User" });

                }
                else
                {
                    return Unauthorized("Username or Password is Incorrect!");
                }
            }
        }


        private string makeToken(string username, string password, string role)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_HRRDMF"));
            var credintials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
            //var token = new JwtSecurityToken(
            //    expires: DateTime.Now.AddMinutes(120),
            //    signingCredentials: credintials);

            var data = new List<Claim>();

            if (role == "Admin")
                data.Add(new Claim("ID", "1"));
            else
            {
                User usr = db.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
                data.Add(new Claim("ID", usr.UserId.ToString()));

            }


            data.Add(new Claim(ClaimTypes.Role, role));
            data.Add(new Claim("username", username));
            data.Add(new Claim("password", password));

            var token = new JwtSecurityToken(
                claims: data,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credintials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
