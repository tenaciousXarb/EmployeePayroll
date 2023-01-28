using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ISelectedList<CLASS, RET>
    {
        List<CLASS> GetSelected(RET id);
    }
}
