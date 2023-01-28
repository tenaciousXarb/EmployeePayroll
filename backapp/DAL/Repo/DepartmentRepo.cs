using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DepartmentRepo : Repo, IRepo<Department, int, Department>
    {
        public Department Add(Department obj)
        {
            db.Departments.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbpost = Get(id);
            db.Departments.Remove(dbpost);
            return db.SaveChanges() > 0;
        }

        public List<Department> Get()
        {
            return db.Departments.ToList();
        }

        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }

        public Department Update(Department obj)
        {
            var dbpost = Get(obj.Id);
            db.Entry(dbpost).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }
    }
}