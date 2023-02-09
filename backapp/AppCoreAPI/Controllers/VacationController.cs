using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    public class VacationController : BaseApiController
    {
        #region all leaves api
        [HttpGet("api/vacations")]
        
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
        [HttpGet("api/vacations/{id}")]
        
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
        [HttpGet("api/vacations/delete/{id}")]
        
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
        [HttpPost("api/vacations/create")]
        
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


        #region leave status update apiS
        [HttpPost("api/vacations/update/{value}")]
        
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
