using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public Nullable<int> EmpId { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Month { get; set; }
        public int AdminId { get; set; }
    }
}
