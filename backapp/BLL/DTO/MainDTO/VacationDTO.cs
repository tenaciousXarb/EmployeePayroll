using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class VacationDTO
    {
        public int Id { get; set; }
        public Nullable<int> EmpId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Nod { get; set; }
        public string Status { get; set; }
        public Nullable<int> AdminId { get; set; }
    }
}
