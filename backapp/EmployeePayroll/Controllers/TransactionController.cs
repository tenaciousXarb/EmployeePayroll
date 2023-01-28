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
    public class TransactionController : ApiController
    {
        [Route("api/transactions")]
        [HttpGet]
        [Logged]
        public IHttpActionResult Get()
        {
            try
            {
                var data = TransactionService.Get();
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
        [Route("api/transactions/{id}")]
        [HttpGet]
        [Logged]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var data = TransactionService.Get(id);
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
        [Route("api/transactions/delete/{id}")]
        [HttpGet]
        [Logged]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var data = TransactionService.Delete(id);
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
        [Route("api/transactions/create")]
        [HttpPost]
        [Logged]
        public IHttpActionResult Add(TransactionDTO emp)
        {
            try
            {
                var data = TransactionService.AddTransaction(emp);
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
        [Route("api/transactions/update")]
        [HttpPost]
        [Logged]
        public IHttpActionResult Update(TransactionDTO emp)
        {
            try
            {
                var data = TransactionService.Edit(emp);
                if (data != null)
                {
                    return Ok(data);
                }
                return BadRequest("Unable to update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
