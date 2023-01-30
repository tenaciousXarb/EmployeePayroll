using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repo
{
    internal class VacationRepo : Repo, IRepo<Vacation, int, Vacation>
    {
        public async Task<Vacation?> Add(Vacation obj)
        {
            await db.Vacations.AddAsync(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            var dbpost = await Get(id);
            if(dbpost != null)
            {
                db.Vacations.Remove(dbpost);
            }
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<List<Vacation>?> Get()
        {
            return await db.Vacations.ToListAsync();
        }

        public async Task<Vacation?> Get(int id)
        {
            return await db.Vacations.FindAsync(id);
        }

        public async Task<Vacation?> Update(Vacation obj)
        {
            var dbpost = Get(obj.Id);
            if(dbpost != null)
            {
                db.Entry(dbpost).CurrentValues.SetValues(obj);
            }
            await db.SaveChangesAsync();
            return obj;
        }
    }
}
