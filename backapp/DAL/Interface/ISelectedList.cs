using System.Collections.Generic;

namespace DAL.Interface
{
    public interface ISelectedList<CLASS, RET>
    {
        List<CLASS> GetSelected(RET id);
    }
}
