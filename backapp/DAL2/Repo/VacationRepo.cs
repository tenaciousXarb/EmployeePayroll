using DAL.EF;
using DAL.Interfaces;

namespace DAL.Repo
{
    internal class VacationRepo : Repo, IRepo<Vacation, int, Vacation>
    {
        public Vacation Add(Vacation obj)
        {
            db.Vacations.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbpost = Get(id);
            db.Vacations.Remove(dbpost);
            return db.SaveChanges() > 0;
        }

        public List<Vacation> Get()
        {
            return db.Vacations.ToList();
        }

        public Vacation Get(int id)
        {
            return db.Vacations.Find(id);
        }

        public Vacation Update(Vacation obj)
        {
            var dbpost = Get(obj.Id);
            db.Entry(dbpost).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }
    }
}
