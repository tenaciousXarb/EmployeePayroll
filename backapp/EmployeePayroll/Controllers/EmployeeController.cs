using BLL;
using BLL.DTO.FormDTO;
using BLL.Services;
using EmployeePayroll.Authentication;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeePayroll.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        [Route("api/employees")]
        [HttpGet]
        [Logged]
        public IHttpActionResult Get()
        {
            try
            {
                var data = EmployeeService.Get();
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
        public IHttpActionResult GetByName(string name)
        {
            try
            {
                var data = EmployeeService.GetByName(name);
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
        [Route("api/employees/{id}")]
        [HttpGet]
        [Logged]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var data = EmployeeService.Get(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/employees/delete/{id}")]
        [HttpGet]
        [Logged]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var data = EmployeeService.Delete(id);
                if(data)
                {
                    return Ok(data);
                }
                //throw new SystemException();
                return BadRequest(data.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/employees/create")]
        [HttpPost]
        public IHttpActionResult Add(EmployeeRegistrationDTO emp)
        {
            if (ModelState.IsValid)
            {
                var data = EmployeeService.AddEmployee(emp);
                if (data != null)
                {
                    try
                    {
                        return Ok(data);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("Error occurred!");
                }
            }
            return BadRequest(ModelState);
        }
        [Route("api/employees/update")]
        [HttpPost]
        [Logged]
        public IHttpActionResult Update(EmployeeDTO emp)
        {
            if(emp.Password == null)
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
            /*var errorList = ModelState.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );
            return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);*/
            return BadRequest(ModelState);
        }
    }
}
