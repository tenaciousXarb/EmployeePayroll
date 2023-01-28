using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.MainDTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        public int? EmpId { get; set; }

        public int? Amount { get; set; }

        public DateTime? Date { get; set; }

        public string? Month { get; set; }

        public int AdminId { get; set; }
    }
}
