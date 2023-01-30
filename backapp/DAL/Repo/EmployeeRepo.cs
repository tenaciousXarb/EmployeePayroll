using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Employee?> Add(Employee obj)
        {
            obj.Status = "Active";
            await db.Employees.AddAsync(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            var dbpost = await Get(id);
            if(dbpost != null)
            {
                db.Employees.Remove(dbpost);
            }
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<List<Employee>?> Get()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByUsername(string name)
        {
            return await (from b in db.Employees
                       where b.Username == name
                       select b).SingleOrDefaultAsync();
        }
        public async Task<Employee?> Get(int id)
        {
            return await db.Employees.FindAsync(id);
        }

        public async Task<Employee?> Update(Employee obj)
        {
            var dbpost = await Get(obj.Id);
            if(dbpost != null)
            {
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    var p = prop.GetValue(obj, null);
                    if (p != null)
                    {
                        prop.SetValue(dbpost, p);
                    }
                }
                db.Entry(dbpost).CurrentValues.SetValues(obj);
            }
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<Employee?> Authenticate(string uname, string pass)
        {
            return await db.Employees.FirstOrDefaultAsync(x => x.Username == uname && x.Password == pass);
        }

        public async Task<bool> Logout(string token)
        {
            var tk = await db.Tokens.FirstOrDefaultAsync(x => x.Tkey == token);
            if (tk != null)
            {
                tk.ExpirationTime = DateTime.Now;
            }
            return await db.SaveChangesAsync()>0;
        }
    }
}
