using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ISelectedList<CLASS, RET>
    {
        Task<List<CLASS>?> GetSelected(RET id);
    }
}
