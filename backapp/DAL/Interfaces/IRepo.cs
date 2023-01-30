using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS, ID, RET>
    {
        Task<RET?> Add(CLASS obj);
        Task<RET?> Update(CLASS obj);
        Task<List<CLASS>?> Get();
        Task<CLASS?> Get(ID id);
        Task<bool> Delete(ID id);
    }
}
