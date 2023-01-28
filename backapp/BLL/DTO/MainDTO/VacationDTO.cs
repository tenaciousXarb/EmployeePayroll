using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.MainDTO
{
    public class VacationDTO
    {
        public int Id { get; set; }

        public int? EmpId { get; set; }

        public DateTime? Date { get; set; }

        public int? Nod { get; set; }

        public string? Status { get; set; }

        public int? AdminId { get; set; }
    }
}
