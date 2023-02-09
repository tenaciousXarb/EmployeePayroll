using BLL.DTO.FormDTO;
using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppCoreAPI.Controllers
{
    public class EmployeeController : BaseApiController
    {
        #region all employees api
        [HttpGet("api/employees")]

        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await EmployeeService.Get();
                if (data != null)
                {
                    if (data.Count == 0)
                    {
                        return BadRequest("No data");
                    }
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region employee by name api
        [HttpGet("api/employees/getbyname/{name}")]

        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var data = await EmployeeService.GetByName(name);
                if (data != null)
                {
                    return Ok(data);
                }
                return UnprocessableEntity("Not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region single employee api
        [HttpGet("api/employees/{id}")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await EmployeeService.Get(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return UnprocessableEntity("Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region delete employee api
        [HttpGet("api/employees/delete/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await EmployeeService.Delete(id);
                if (data)
                {
                    return Ok(data);
                }
                return UnprocessableEntity(data.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region add employee api
        [HttpPost("api/employees/create")]
        public async Task<IActionResult> Add(EmployeeRegistrationDTO obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await EmployeeService.AddEmployee(obj);
                    if (data != null)
                    {
                        return Ok(data);
                    }
                    return UnprocessableEntity("Error occurred!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return BadRequest(ModelState);
        }
        #endregion


        #region update employee api
        [HttpPost("api/employees/update")]
        public async Task<IActionResult> Update(EmployeeDTO obj)
        {
            /*var e = await EmployeeService.Get(obj.Id);
            if (e != null)
            {
                if (obj.Password == null)
                {
                    obj.Password = e.Password;
                    obj.Designation = e.Designation;
                    obj.Branch = e.Branch;
                    obj.DeptId = e.DeptId;
                    obj.Salary = e.Salary;
                    obj.RemLeave = e.RemLeave;
                    obj.Status = e.Status;
                }
                else
                {
                    obj.Designation = e.Designation;
                    obj.Name = e.Name;
                    obj.Address = e.Address;
                    obj.Phone = e.Phone;
                    obj.Email = e.Email;
                    obj.City = e.City;
                    obj.Pincode = e.Pincode;
                    obj.Degree = e.Degree;
                    obj.Branch = e.Branch;
                    obj.DeptId = e.DeptId;
                    obj.Status = e.Status;
                    obj.Salary = e.Salary;
                    obj.BankAccount = e.BankAccount;
                    obj.Username = e.Username;
                    obj.RemLeave = e.RemLeave;
                }
            }*/
            if (ModelState.IsValid)
            {
                var data = await EmployeeService.Edit(obj);
                if (data != null)
                {
                    try
                    {
                        if (data != null)
                        {
                            return Ok(data);
                        }
                        throw new NullReferenceException();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            return BadRequest(ModelState);
        }
        #endregion
    }
}
