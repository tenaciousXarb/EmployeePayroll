using DAL.EF;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public async Task<Token?> Add(Token obj)
        {
            await db.Tokens.AddAsync(obj);
            if (await db.SaveChangesAsync() > 0)
            {
                return obj;
            }
            return null;
        }

        public async Task<bool> Delete(string id)
        {
            var dbpost = await Get(id);
            if (dbpost != null)
            {
                db.Tokens.Remove(dbpost);
            }
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<List<Token>?> Get()
        {
            return await db.Tokens.ToListAsync();
        }

        public async Task<Token?> Get(string id)
        {
            return await db.Tokens.FirstOrDefaultAsync(x => x.Tkey == id);
        }

        public async Task<Token?> Update(Token obj)
        {
            var dbpost = await Get(obj.Tkey?? throw new ArgumentNullException(nameof(obj.Tkey)));
            if(dbpost != null)
            {
                db.Entry(dbpost).CurrentValues.SetValues(obj);
            }
            if (db.SaveChanges() > 0)
            {
                return obj;
            }
            return null;
        }
    }
}
