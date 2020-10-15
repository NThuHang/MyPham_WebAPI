using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MyPham_WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        //Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetTaiKhoan1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello: " + identity.Name);
        }

        //[Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetTaiKhoan2()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims
                      .FirstOrDefault(c => c.Type == "Email").Value;

            var UserName = identity.Name;

            return Ok( UserName);
        }

        //This resource is only For SuperAdmin role
        // [Authorize(Roles = "SuperAdmin")]
        [AllowAnonymous]
        [HttpGet]
        [Route("api/testtoken/resource3")]
        public IHttpActionResult GetResource3()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + "Your Role(s) are: " + string.Join(",", roles.ToList()));
        }
    }
}
