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
    public class AdminController : ApiController
    {
        [Route("api/admins")]
        [HttpGet]
        [Logged]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/admins/{id}")]
        [HttpGet]
        [Logged]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/admins/delete/{id}")]
        [HttpGet]
        [Logged]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = AdminService.Delete(id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/admins/create")]
        [HttpPost]
        [Logged]
        public HttpResponseMessage Add(AdminDTO emp)
        {
            var msg = "";
            if (emp == null)
            {
                msg = "Please fill all the data";
                return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, msg);
            }
            else if (ModelState.IsValid)
            {
                var data = AdminService.Edit(emp);
                if (data != null)
                {
                    try
                    {
                        
                        if (data != null)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, data);
                        }
                    }
                    catch (Exception ex)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }
                }
                msg = "Invalid data";
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, msg);
            }
            var errorList = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
            return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
        }
        [Route("api/admins/update")]
        [HttpPost]
        [Logged]
        public HttpResponseMessage Update(AdminDTO emp)
        {
            if(emp.Password == null)
            {
                var s = AdminService.Get(emp.Id);
                emp.Password = s.Password;
            }
            var msg = "";
            if (emp == null)
            {
                msg = "Please fill all the data";
                return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, msg);
            }
            else if (ModelState.IsValid)
            {
                var data = AdminService.Edit(emp);
                if (data != null)
                {
                    try
                    {
                        if (data != null)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, data);
                        }
                    }
                    catch (Exception ex)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }
                }
                msg = "Invalid data";
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, msg);
            }
            var errorList = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
            return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
        }
    }
}