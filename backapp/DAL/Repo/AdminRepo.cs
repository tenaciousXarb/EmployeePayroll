using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace DAL.Repo
{
    internal class AdminRepo : Repo, IRepo<Admin, int, Admin>, IAuth<Admin>
    {
        public async Task<Admin?> Add(Admin obj)
        {
            //db.Admins.Add(obj);
            await db.Admins.AddAsync(obj);
            if (await db.SaveChangesAsync() > 0)
            {
                return obj;
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await Get(id);
            if(obj != null)
            {
                db.Admins.Remove(obj);
            }
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<List<Admin>?> Get()
        {
            return await db.Admins.ToListAsync(); 
        }

        public async Task<Admin?> Get(int id)
        {
            //return await db.Admins.FirstOrDefaultAsync(i => i.Id == id);
            return await db.Admins.FindAsync(id);
        }

        public async Task<Admin?> Update(Admin obj)
        {
            var dbpost = Get(obj.Id);
            db.Entry(dbpost).CurrentValues.SetValues(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<Admin?> Authenticate(string uname, string pass)
        {
            return await db.Admins.FirstOrDefaultAsync(x => x.Username == uname && x.Password == pass);
        }

        public async Task<bool> Logout(string token)
        {
            var tk =  await db.Tokens.FirstOrDefaultAsync(x => x.Tkey == token);
            if (tk != null)
            {
                tk.ExpirationTime = DateTime.Now;
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
