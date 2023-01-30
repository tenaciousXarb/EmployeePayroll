using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGet<CLASS, ret>
    {
        Task<CLASS?> GetByUsername(ret name);
    }
}
