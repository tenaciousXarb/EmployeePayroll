using AppCoreAPI.Authentication;
using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    [ApiController]
    [EnableCors]
    public class VacationController : ControllerBase
    {
        [Route("api/vacations")]
        [HttpGet]
        [Logged]
        public IActionResult Get()
        {
            try
            {
                var data = VacationService.Get();
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
        [Route("api/vacations/{id}")]
        [HttpGet]
        [Logged]
        public IActionResult Get(int id)
        {
            try
            {
                var data = VacationService.Get(id);
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
        [Route("api/vacations/delete/{id}")]
        [HttpGet]
        [Logged]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = VacationService.Delete(id);
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
        [Route("api/vacations/create")]
        [HttpPost]
        [Logged]
        public IActionResult Add(VacationDTO emp)
        {
            try
            {
                var data = VacationService.AddVacation(emp);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Unable to add");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/vacations/update/{value}")]
        [HttpPost]
        [Logged]
        public IActionResult Update(VacationDTO emp, int value)
        {
            try
            {
                var data = VacationService.Edit(emp, value);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("No entry found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
