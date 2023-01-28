using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IAuth<CLASS>
    {
        CLASS Authenticate(string uname, string pass);
        bool Logout(string token);
    }
}
