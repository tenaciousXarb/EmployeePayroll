using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    public class DepartmentController : BaseApiController
    {
        #region all departments api
        [HttpGet("api/departments")]
        
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
        #endregion


        #region single department api
        [HttpGet("api/departments/{id}")]
        
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
        #endregion


        #region delete department api
        [HttpGet("api/departments/delete/{id}")]
        
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
        #endregion


        #region add department api
        [HttpPost("api/departments/create")]
        
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
        #endregion


        #region update department api
        [HttpPost("api/departments/update")]
        
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
        #endregion
    }
}
