using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Degree { get; set; }
        public string Designation { get; set; }
        public string Branch { get; set; }
        public Nullable<int> DeptId { get; set; }
        public string Status { get; set; }
        public Nullable<int> Salary { get; set; }
        public string BankAccount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Nullable<int> RemLeave { get; set; }
    }
}
