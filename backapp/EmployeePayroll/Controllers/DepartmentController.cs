using BLL.Services;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.DTO;
using EmployeePayroll.Authentication;

namespace EmployeePayroll.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DepartmentController : ApiController
    {
        [Route("api/departments")]
        [HttpGet]
        [Logged]
        public IHttpActionResult Get()
        {
            try
            {
                var data = DepartmentService.Get();
                if(data != null)
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
        public IHttpActionResult Get(int id)
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
        public IHttpActionResult Delete(int id)
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
        public IHttpActionResult Add(DepartmentDTO emp)
        {
            try
            {
                var data = DepartmentService.AddDepartment(emp);
                if(data != null)
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
        public IHttpActionResult Update(DepartmentDTO emp)
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
