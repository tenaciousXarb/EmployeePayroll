using BLL.DTO.FormDTO;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    [ApiController]
    [EnableCors]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region admin logout
        [Route("api/logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            if (token != null)
            {
                var rs = await AuthService.Logout(token);
                if (rs)
                {
                    return Ok("Successfully logged out!");
                }
            }
            return BadRequest("Invalid token to logout");
        } 
        #endregion


        #region employee logout
        [Route("api/emp/logout")]
        [HttpGet]
        public async Task<IActionResult> EmpLogout()
        {
            var token = Request.Headers.Authorization.ToString();
            if (token != null)
            {
                var rs = await AuthService.EmpLogout(token);
                if (rs)
                {
                    return Ok("Successfully logged out!");
                }
            }
            return BadRequest("Invalid token to logout");
        } 
        #endregion


        #region authenticate admin
        [Route("api/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                if (login.Username != null && login.Password != null)
                {
                    var token = await new AuthService().AuthenticateAdmin(login.Username, login.Password);

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
            }
            return BadRequest(ModelState);
        } 
        #endregion


        #region authenticate employee
        [Route("api/employee/login")]
        [HttpPost]
        public async Task<IActionResult> EmpLogin(LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                if (login.Username != null && login.Password != null)
                {
                    var token = await new AuthService().AuthenticateEmployee(login.Username, login.Password);
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
            }
            return BadRequest(ModelState);
        } 
        #endregion
    }
}
