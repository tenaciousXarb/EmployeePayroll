using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IAuth<CLASS>
    {
        CLASS Authenticate(string uname, string pass);
        bool Logout(string token);
    }
}
