using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    [ApiController]
    [EnableCors]
    public class TokenController : ControllerBase
    {
        [Route("api/tokens")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = TokenService.Get();
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/tokens/{id}")]
        [HttpGet]
        public IActionResult Get(string id)
        {
            try
            {
                var data = TokenService.Get(id);
                if (data != null)
                {
                    return Ok(data);

                }
                return BadRequest("Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/tokens/delete/{id}")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            try
            {
                var data = TokenService.Delete(id);
                if (data)
                {
                    return Ok(data);
                }
                return BadRequest(data.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/tokens/create")]
        [HttpPost]
        public IActionResult Add(TokenDTO emp)
        {
            try
            {
                var data = TokenService.AddToken(emp);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Error in initializing token");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/tokens/update")]
        [HttpPost]
        public IActionResult Update(TokenDTO emp)
        {
            try
            {
                var data = TokenService.Edit(emp);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Error occurred while updating");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
