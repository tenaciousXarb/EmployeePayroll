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
    internal class TransactionRepo : Repo, IRepo<Transaction, int, Transaction>, ISelectedList<Transaction, int>
    {
        public async Task<Transaction?> Add(Transaction obj)
        {
            await db.Transactions.AddAsync(obj);
            await db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            var dbpost = await Get(id);
            if (dbpost != null)
            {
                db.Transactions.Remove(dbpost);
            }
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<List<Transaction>?> Get()
        {
            return await db.Transactions.ToListAsync();
        }

        public async Task<Transaction?> Get(int id)
        {
            return await db.Transactions.FindAsync(id);
        }

        public async Task<List<Transaction>?> GetSelected(int id)
        {
            return await (from b in db.Transactions
                       where b.EmpId == id
                       select b).ToListAsync();
        }

        public async Task<Transaction?> Update(Transaction obj)
        {
            var dbpost = await Get(obj.Id);
            if(dbpost != null)
            {
                db.Entry(dbpost).CurrentValues.SetValues(obj);
            }
            await db.SaveChangesAsync();
            return obj;
        }
    }
}
