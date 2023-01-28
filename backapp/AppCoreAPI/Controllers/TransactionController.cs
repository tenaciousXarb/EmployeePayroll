using AppCoreAPI.Authentication;
using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    [ApiController]
    [EnableCors]
    public class TransactionController : ControllerBase
    {
        [Route("api/transactions")]
        [HttpGet]
        [Logged]
        public IActionResult Get()
        {
            try
            {
                var data = TransactionService.Get();
                if (data != null)
                {
                    //return Ok(data);
                    return Content("hello");
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
        public IActionResult Get(int id)
        {
            try
            {
                var data = TransactionService.Get(id);
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
        [Route("api/transactions/delete/{id}")]
        [HttpGet]
        [Logged]
        public IActionResult Delete(int id)
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
        public IActionResult Add(TransactionDTO emp)
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
        public IActionResult Update(TransactionDTO emp)
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
