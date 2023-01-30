﻿using AppCoreAPI.Authentication;
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
        [Route("api/transactions/{id}")]
        [HttpGet]
        [Logged]
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
        [Route("api/transactions/delete/{id}")]
        [HttpGet]
        [Logged]
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
        [Route("api/transactions/create")]
        [HttpPost]
        [Logged]
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
        [Route("api/transactions/update")]
        [HttpPost]
        [Logged]
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
    }
}