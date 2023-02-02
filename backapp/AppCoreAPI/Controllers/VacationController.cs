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
        #region all leaves api
        [Route("api/vacations")]
        [HttpGet]
        
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
        #endregion


        #region single leave api
        [Route("api/vacations/{id}")]
        [HttpGet]
        
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
        #endregion


        #region delete leave api
        [Route("api/vacations/delete/{id}")]
        [HttpGet]
        
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
        #endregion


        #region add leave api
        [Route("api/vacations/create")]
        [HttpPost]
        
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
        #endregion


        #region leave status update api
        [Route("api/vacations/update/{value}")]
        [HttpPost]
        
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
        #endregion
    }
}
