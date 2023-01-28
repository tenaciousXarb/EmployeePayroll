using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : Repo, IRepo<Token, string, Token>
    {
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var dbpost = Get(id);
            db.Tokens.Remove(dbpost);
            return db.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string id)
        {
            var book = (from b in db.Tokens
                        where b.TKey == id
                        select b).SingleOrDefault();
            return book;
        }

        public Token Update(Token obj)
        {
            var dbpost = Get(obj.TKey);
            db.Entry(dbpost).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return obj;
            return null;
        }
    }
}
