using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.MainDTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Tallowance { get; set; }

        public int? Mallowance { get; set; }

        public int? Leave { get; set; }
    }
}
