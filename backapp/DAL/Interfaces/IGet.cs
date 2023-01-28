using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGet<CLASS, ret>
    {
        CLASS GetByUsername(ret name);
    }
}
