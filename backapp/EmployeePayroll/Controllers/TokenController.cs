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

namespace EmployeePayroll.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TokenController : ApiController
    {
        [Route("api/tokens")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var data = TokenService.Get();
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
        [Route("api/tokens/{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var data = TokenService.Get(id);
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
        [Route("api/tokens/delete/{id}")]
        [HttpGet]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                var data = TokenService.Delete(id);
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
        [Route("api/tokens/create")]
        [HttpPost]
        public IHttpActionResult Add(TokenDTO emp)
        {
            try
            {
                var data = TokenService.AddToken(emp);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Error in initializing token");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/tokens/update")]
        [HttpPost]
        public IHttpActionResult Update(TokenDTO emp)
        {
            try
            {
                var data = TokenService.Edit(emp);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Error occurred while updating");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
