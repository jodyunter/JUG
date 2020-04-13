using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Impl
{
    public class BaseDataService<TEntity> : IDataService<TEntity> where TEntity :class, IDAOObject
    {
        protected JUGContext db;        

        public BaseDataService()
        {                     
        }

        public void Create(TEntity o)
        {
            using (db = new JUGContext())
            {
                db.Add(o);
                db.SaveChanges();
            }
        }

        public TEntity GetById(long Id)
        {
            using (db = new JUGContext())
            {
                return db.Set<TEntity>().Where(t => t.Id == Id).FirstOrDefault();
            }
        }

        public void Save(TEntity o)
        {
            using (db = new JUGContext())
            {
                db.Update(o);
                db.SaveChanges();
            }
        }

        public IList<TEntity> GetAll()
        {
            using (db = new JUGContext())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public void Delete(TEntity o)
        {
            using (db = new JUGContext())
            {
                db.Set<TEntity>().Remove(o);
                db.SaveChanges();
            }
        }

    }
}
