using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    public class TransactionController : BaseApiController
    {
        #region all transactions api
        [HttpGet("api/transactions")]
        
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await TransactionService.Get();
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


        #region single transaction api
        [HttpGet("api/transactions/{id}")]
        
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await TransactionService.Get(id);
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


        #region delete transaction api
        [HttpGet("api/transactions/delete/{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await TransactionService.Delete(id);
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


        #region add transaction api
        [HttpPost("api/transactions/create")]
        
        public async Task<IActionResult> Add(TransactionDTO obj)
        {
            try
            {
                var data = await TransactionService.AddTransaction(obj);
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


        #region update transaction api
        [HttpPost("api/transactions/update")]
        
        public async Task<IActionResult> Update(TransactionDTO obj)
        {
            try
            {
                var data = await TransactionService.Edit(obj);
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
        #endregion
    }
}
