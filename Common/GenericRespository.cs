using Farasis.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Farasis
{
    public class GenericRespository<T>:IGenericRepository<T> where T:class
    {
        private BattEntities db = null;
        private DbSet<T> table = null;

        public GenericRespository()
        {
            this.db = new BattEntities();
            table = db.Set<T>();
        }
        public   GenericRespository(BattEntities db)
        {
            this.db = db;
        }
    
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T Get(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            Save();            
        }
        public void Delete(object id)
        {
            var existing = table.Find(id);
            table.Remove(existing);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}