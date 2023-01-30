using AppCoreAPI.Authentication;
using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    [ApiController]
    [EnableCors]
    public class AdminController : ControllerBase
    {
        [Route("api/admins")]
        [HttpGet]
        [Logged]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await AdminService.Get();
                if(data != null)
                {
                    return Ok(data);
                }
                return UnprocessableEntity("No data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/admins/{id}")]
        [HttpGet]
        [Logged]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await AdminService.Get(id);
                if(data != null)
                {
                    return Ok(data);
                }
                return UnprocessableEntity("No data");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/admins/delete/{id}")]
        [HttpGet]
        [Logged]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await AdminService.Delete(id);
                if (data)
                {
                    return Ok(data);
                }
                return StatusCode(520);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/admins/create")]
        [HttpPost]
        [Logged]
        public async Task<IActionResult> Add(AdminDTO obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await AdminService.Edit(obj);
                    if (data != null)
                    {
                        return Ok(data); 
                    }
                    return BadRequest("Not found");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        [Route("api/admins/update")]
        [HttpPost]
        [Logged]
        public async Task<IActionResult> Update(AdminDTO obj)
        {
            if (obj.Password == null)
            {
                var s = await AdminService.Get(obj.Id);
                if (s != null)
                {
                    obj.Password = s.Password;
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await AdminService.Edit(obj);
                    if (data != null)
                    {
                        return Ok(data);
                    }
                    return UnprocessableEntity("Not found");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
