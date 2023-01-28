using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int, Employee>, IGet<Employee, string>, IAuth<Employee>
    {
        public Employee Add(Employee obj)
        {
            obj.Status = "Active";
            db.SaveChanges();
            db.Employees.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbpost = Get(id);
            db.Employees.Remove(dbpost);
            return db.SaveChanges() > 0;
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee GetByUsername(string name)
        {
            var ext = (from b in db.Employees
                       where b.Username == name
                       select b).SingleOrDefault();
            return ext;
        }
        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public Employee Update(Employee obj)
        {
            var dbpost = Get(obj.Id);
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                var p = prop.GetValue(obj, null);
                if (p != null)
                {
                    prop.SetValue(dbpost, p);
                }
            }
            db.Entry(dbpost).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }

        public Employee Authenticate(string uname, string pass)
        {
            var obj = db.Employees.FirstOrDefault(x => x.Username.Equals(uname) && x.Password.Equals(pass) && x.Status.Equals("Active"));
            return obj;
        }

        public bool Logout(string token)
        {
            var tk = db.Tokens.FirstOrDefault(x => x.Tkey.Equals(token));
            if (tk != null)
            {
                tk.ExpirationTime = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
