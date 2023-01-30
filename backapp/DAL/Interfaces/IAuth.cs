using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IAuth<CLASS>
    {
        Task<CLASS?> Authenticate(string uname, string pass);
        Task<bool> Logout(string token);
    }
}
