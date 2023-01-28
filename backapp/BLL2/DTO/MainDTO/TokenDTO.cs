using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.MainDTO
{
    public class TokenDTO
    {
        public int Id { get; set; }

        public string? Tkey { get; set; }

        public DateTime? CreationTime { get; set; }

        public DateTime? ExpirationTime { get; set; }

        public string? Username { get; set; }

        public string? Post { get; set; }
    }
}
