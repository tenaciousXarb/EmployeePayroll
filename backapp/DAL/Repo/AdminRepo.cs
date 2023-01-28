using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>, IAuth<Admin>
    {
        public Admin Add(Admin obj)
        {
            db.Admins.Add(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var dbpost = Get(id);
            db.Admins.Remove(dbpost);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin Update(Admin obj)
        {
            var dbpost = Get(obj.Id);
            db.Entry(dbpost).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public Admin Authenticate(string uname, string pass)
        {
            var obj = db.Admins.FirstOrDefault(x => x.Username.Equals(uname) && x.Password.Equals(pass));
            return obj;
        }

        public bool Logout(string token)
        {
            var tk = db.Tokens.FirstOrDefault(x => x.TKey.Equals(token));
            if(tk != null)
            {
                tk.ExpirationTime = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
