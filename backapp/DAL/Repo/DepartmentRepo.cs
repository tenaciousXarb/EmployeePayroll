using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DepartmentRepo : Repo, IRepo<Department, int, Department>
    {
        public async Task<Department?> Add(Department obj)
        {
            await db.Departments.AddAsync(obj);
            if (await db.SaveChangesAsync() > 0)
            {
                return obj;
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await Get(id);
            if (obj != null)
            {
                db.Departments.Remove(obj);
            }
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<List<Department>?> Get()
        {
            return await db.Departments.ToListAsync();
        }

        public async Task<Department?> Get(int id)
        {
            return await db.Departments.FindAsync(id);
        }

        public async Task<Department?> Update(Department obj)
        {
            var dbpost = Get(obj.Id);
            db.Entry(dbpost).CurrentValues.SetValues(obj);
            await db.SaveChangesAsync();
            return obj;
        }
    }
}
