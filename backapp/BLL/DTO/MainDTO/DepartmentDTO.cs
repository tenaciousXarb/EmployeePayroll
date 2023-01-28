using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Tallowance { get; set; }
        public Nullable<int> Mallowance { get; set; }
        public Nullable<int> Leave { get; set; }
    }
}
