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
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await VacationService.Get();
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
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await VacationService.Get(id);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await VacationService.Delete(id);
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
        public async Task<IActionResult> Add(VacationDTO obj)
        {
            try
            {
                var data = await VacationService.AddVacation(obj);
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
        public async Task<IActionResult> Update(VacationDTO obj, int value)
        {
            try
            {
                var data = await VacationService.Edit(obj, value);
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
