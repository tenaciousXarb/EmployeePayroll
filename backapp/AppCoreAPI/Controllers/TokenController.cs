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
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await TokenService.Get();
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
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var data = await TokenService.Get(id);
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
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var data = await TokenService.Delete(id);
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
        public async Task<IActionResult> Add(TokenDTO obj)
        {
            try
            {
                var data = await TokenService.AddToken(obj);
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
        public async Task<IActionResult> Update(TokenDTO obj)
        {
            try
            {
                var data = await TokenService.Edit(obj);
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
