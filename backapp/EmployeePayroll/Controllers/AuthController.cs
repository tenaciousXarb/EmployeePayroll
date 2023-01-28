using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeePayroll.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [Route("api/logout")]
        [HttpGet]
        public IHttpActionResult Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            if(token != null)
            {
                var rs = AuthService.Logout(token);
                if(rs)
                {
                    return Ok("Successfully logged out!");
                }
            }
            return BadRequest("Invalid token to logout");
        }
        [Route("api/emp/logout")]
        [HttpGet]
        public IHttpActionResult EmpLogout()
        {
            var token = Request.Headers.Authorization.ToString();
            if (token != null)
            {
                var rs = AuthService.EmpLogout(token);
                if (rs)
                {
                    return Ok("Successfully logged out!");
                }
            }
            return BadRequest("Invalid token to logout");
        }
        [Route("api/login")]
        [HttpPost]
        public IHttpActionResult Login(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var token = AuthService.AuthenticateAdmin(login.Username, login.Password);
                if (token != null)
                {
                    try
                    {
                        return Ok(token);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Invalid username or password");
                }
            }
            /*var errorList = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
            return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);*/
            return BadRequest(ModelState);
        }
        [Route("api/employee/login")]
        [HttpPost]
        public IHttpActionResult EmpLogin(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var token = AuthService.AuthenticateEmployee(login.Username, login.Password);
                if (token != null)
                {
                    try
                    {
                        return Ok(token);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Invalid username or password");
                }
            }
            /*var errorList = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
            return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);*/
            return BadRequest(ModelState);
        }
    }
}
