using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IGet<CLASS, ret>
    {
        CLASS GetByUsername(ret name);
    }
}
