using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace AppCoreAPI.Controllers
{
    public class AdminController : BaseApiController
    {
        #region all admin api
        /// <summary>
        /// Get all admins
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/admins")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(List<AdminDTO>))]
        [SwaggerResponse(statusCode: StatusCodes.Status204NoContent)]
        //[Authorize]
        [Authorize(Policy = "beingadmin")]
        public async Task<IActionResult> GetAllAdmins()
        {
            try
            {
                Log.Information("GetAllAdmins");
                var data = await AdminService.Get();
                if (data != null)
                {
                    return Ok(data);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region single admin api
        /// <summary>
        /// Get admin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("api/admins/{id}")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(AdminDTO))]
        [SwaggerResponse(statusCode: StatusCodes.Status204NoContent)]

        public async Task<IActionResult> GetAdminById(int id)
        {
            Log.Information($"GetAdminById | ID: {id}");
            try
            {
                var data = await AdminService.Get(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region delete admin api
        /// <summary>
        /// Delete admin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("api/admins/delete/{id}")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteAdmin(int id)
        {
            Log.Information($"DeleteAdmin | ID: {id}");
            try
            {
                var data = await AdminService.Delete(id);
                if (data)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region add admin api
        /// <summary>
        /// Add Admin
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("api/admins/create")]
        [SwaggerResponse(statusCode: StatusCodes.Status201Created, type: typeof(AdminDTO))]

        public async Task<IActionResult> AddAdmin(AdminDTO obj)
        {
            Log.Information($"AddAdmin | Admin: {JsonConvert.SerializeObject(obj)}");
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await AdminService.Edit(obj);
                    return StatusCode(StatusCodes.Status201Created, data);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        #endregion


        #region update admin api
        /// <summary>
        /// Update an admin
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut("api/admins/update")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, type: typeof(AdminDTO))]

        public async Task<IActionResult> UpdateAdmin(AdminDTO obj)
        {
            Log.Information($"UpdateAdmin | Admin: {obj.Id}");
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
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);
        } 
        #endregion
    }
}
