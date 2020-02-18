using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Impl
{
    public class BaseDataService<TEntity> : IDataService<TEntity> where TEntity :class, IDAOObject
    {
        private JUGContext db;        

        public BaseDataService(JUGContext context)
        {            
            db = context;
        }

        public void Create(TEntity o)
        {                        
            db.Add(o);
            db.SaveChanges();
        }

        public TEntity GetById(long Id)
        {
            return db.Set<TEntity>().Where(t => t.Id == Id).FirstOrDefault();
        }

        public void Save(TEntity o)
        {            
            db.Update(o);
            db.SaveChanges();

        }
    }
}
