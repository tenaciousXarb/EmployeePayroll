﻿using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IRepo<CLASS, ID, RET>
    {
        RET Add(CLASS obj);
        RET Update(CLASS obj);
        List<CLASS> Get();
        CLASS Get(ID id);
        bool Delete(ID id);
    }
}
