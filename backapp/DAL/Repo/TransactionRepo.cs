using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TransactionRepo : Repo, IRepo<Transaction, int, Transaction>, ISelectedList<Transaction, int>
    {
        public Transaction Add(Transaction obj)
        {
            db.Transactions.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var dbpost = Get(id);
            db.Transactions.Remove(dbpost);
            return db.SaveChanges() > 0;
        }

        public List<Transaction> Get()
        {
            return db.Transactions.ToList();
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Find(id);
        }

        public List<Transaction> GetSelected(int id)
        {
            var ext = (from b in db.Transactions
                       where b.EmpId == id
                       select b).ToList();
            return ext;
        }

        public Transaction Update(Transaction obj)
        {
            var dbpost = Get(obj.Id);
            db.Entry(dbpost).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }
    }
}
