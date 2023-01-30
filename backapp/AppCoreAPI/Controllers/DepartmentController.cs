using AppCoreAPI.Authentication;
using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    [ApiController]
    [EnableCors]
    public class DepartmentController : ControllerBase
    {
        [Route("api/departments")]
        [HttpGet]
        [Logged]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await DepartmentService.Get();
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
        [Route("api/departments/{id}")]
        [HttpGet]
        [Logged]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await DepartmentService.Get(id);
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
        [Route("api/departments/delete/{id}")]
        [HttpGet]
        [Logged]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await DepartmentService.Delete(id);
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
        [Route("api/departments/create")]
        [HttpPost]
        [Logged]
        public async Task<IActionResult> Add(DepartmentDTO obj)
        {
            try
            {
                var data = await DepartmentService.AddDepartment(obj);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Unable to create");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/departments/update")]
        [HttpPost]
        [Logged]
        public async Task<IActionResult> Update(DepartmentDTO obj)
        {
            try
            {
                var data = await DepartmentService.Edit(obj);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest("Unable to update");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
