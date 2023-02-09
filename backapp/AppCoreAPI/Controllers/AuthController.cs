using BLL.DTO.FormDTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    public class AuthController : BaseApiController
    {
        #region admin logout
        [HttpGet("api/logout")]
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
        [HttpGet("api/emp/logout")]
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
        [HttpPost("api/login")]
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
        [HttpPost("api/employee/login")]
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
