using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.LoginDb;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.ActionFilters;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (Db.Users.Any(x => x.Username == user.Username && x.Password == user.Password))
            {
                // if user exists in the list, thought as login successful and set the username to session
                HttpContext.Session.SetString("username", user.Username);
                return Ok("Login Successful");

            }
            else
                return BadRequest("Login Failed");
        }

        [CustomAuthorized]
        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            // works if user logged in 
            // otherwise CustomAuthorized Attr. returns 401

            var username = HttpContext.Session.GetString("username");

            return Ok($"Logged In! username: {username}");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            // if username exists in the session, thought as logged in
            // so remove it from session
            HttpContext.Session.Remove("username");
            return Ok("Logged Out");
        }
    }
}
