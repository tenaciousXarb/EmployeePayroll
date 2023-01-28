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
        public IActionResult Get()
        {
            try
            {
                var data = AdminService.Get();
                if(data.Count == 0)
                {
                    return UnprocessableEntity("No data");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/admins/{id}")]
        [HttpGet]
        [Logged]
        public IActionResult Get(int id)
        {
            try
            {
                var data = AdminService.Get(id);
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
        public IActionResult Delete(int id)
        {
            try
            {
                var data = AdminService.Delete(id);
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
        public IActionResult Add(AdminDTO emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = AdminService.Edit(emp);
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
        public IActionResult Update(AdminDTO emp)
        {
            if (emp.Password == null)
            {
                var s = AdminService.Get(emp.Id);
                emp.Password = s.Password;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var data = AdminService.Edit(emp);
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
