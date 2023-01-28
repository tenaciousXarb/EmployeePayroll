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
        public IActionResult Get()
        {
            try
            {
                var data = DepartmentService.Get();
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
        public IActionResult Get(int id)
        {
            try
            {
                var data = DepartmentService.Get(id);
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
        public IActionResult Delete(int id)
        {
            try
            {
                var data = DepartmentService.Delete(id);
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
        public IActionResult Add(DepartmentDTO emp)
        {
            try
            {
                var data = DepartmentService.AddDepartment(emp);
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
        public IActionResult Update(DepartmentDTO emp)
        {
            try
            {
                var data = DepartmentService.Edit(emp);
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
