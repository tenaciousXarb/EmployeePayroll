using AppCoreAPI.Authentication;
using BLL.DTO.FormDTO;
using BLL.DTO.MainDTO;
using BLL.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayroll.Controllers
{
    [ApiController]
    [EnableCors]
    public class EmployeeController : ControllerBase
    {
        [Route("api/employees")]
        [HttpGet]
        [Logged]
        public IActionResult Get()
        {
            try
            {
                var data = EmployeeService.Get();
                if(data.Count == 0)
                {
                    return BadRequest("No data");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/employees/getbyname/{name}")]
        [HttpGet]
        [Logged]
        public IActionResult GetByName(string name)
        {
            try
            {
                var data = EmployeeService.GetByName(name);
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
        [Route("api/employees/{id}")]
        [HttpGet]
        [Logged]
        public IActionResult Get(int id)
        {
            try
            {
                var data = EmployeeService.Get(id);
                if(data != null)
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
        [Route("api/employees/delete/{id}")]
        [HttpGet]
        [Logged]
        public IActionResult Delete(int id)
        {
            try
            {
                var data = EmployeeService.Delete(id);
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
        [Route("api/employees/create")]
        [HttpPost]
        public IActionResult Add([Bind(nameof(EmployeeRegistrationDTO.Name))] EmployeeRegistrationDTO emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = EmployeeService.AddEmployee(emp);
                    if (data != null)
                    {
                        return Ok(data);
                    }
                    return UnprocessableEntity("Error occurred!");
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                
            }
            return BadRequest(ModelState);
        }
        [Route("api/employees/update")]
        [HttpPost]
        [Logged]
        public IActionResult Update(EmployeeDTO emp)
        {
            if (emp.Password == null)
            {
                var e = EmployeeService.Get(emp.Id);
                emp.Password = e.Password;
                emp.Designation = e.Designation;
                emp.Branch = e.Branch;
                emp.DeptId = e.DeptId;
                emp.Salary = e.Salary;
                emp.RemLeave = e.RemLeave;
                emp.Status = e.Status;
            }
            else
            {
                var e = EmployeeService.Get(emp.Id);
                emp.Designation = e.Designation;
                emp.Name = e.Name;
                emp.Address = e.Address;
                emp.Phone = e.Phone;
                emp.Email = e.Email;
                emp.City = e.City;
                emp.Pincode = e.Pincode;
                emp.Degree = e.Degree;
                emp.Branch = e.Branch;
                emp.DeptId = e.DeptId;
                emp.Status = e.Status;
                emp.Salary = e.Salary;
                emp.BankAccount = e.BankAccount;
                emp.Username = e.Username;
                emp.RemLeave = e.RemLeave;
            }
            if (ModelState.IsValid)
            {
                var data = EmployeeService.Edit(emp);
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
    }        
}
