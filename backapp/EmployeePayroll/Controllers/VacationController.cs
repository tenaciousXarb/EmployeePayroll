using BLL.Services;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.DTO;
using EmployeePayroll.Authentication;

namespace EmployeePayroll.Controllers
{
    [EnableCors("*", "*", "*")]
    public class VacationController : ApiController
    {
        [Route("api/vacations")]
        [HttpGet]
        [Logged]
        public IHttpActionResult Get()
        {
            try
            {
                var data = VacationService.Get();
                if(data != null)
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
        public IHttpActionResult Get(int id)
        {
            try
            {
                var data = VacationService.Get(id);
                if(data != null)
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
        public IHttpActionResult Delete(int id)
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
        public IHttpActionResult Add(VacationDTO emp)
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
        public IHttpActionResult Update(VacationDTO emp, int value)
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
        
        /*[Route("api/vacations/update/reject")]
        [HttpPost]
        [Logged]
        public IHttpActionResult UpdateReject(VacationDTO emp)
        {            
            emp.Status = "Rejected";
            emp.AdminId = 1;
            try
            {
                var data = VacationService.Edit(emp);
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
        }*/
    }
}
