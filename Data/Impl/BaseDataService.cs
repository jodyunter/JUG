using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Impl
{
    public class BaseDataService<TEntity> : IDataService<TEntity> where TEntity :class, IDAOObject
    {
       

        public BaseDataService()
        {                     
        }


        public TEntity GetById(long Id, JUGContext db)
        {
            return db.Set<TEntity>().Where(t => t.Id == Id).FirstOrDefault();
        }

        public void Save(TEntity o, JUGContext db)
        {
            db.Update(o);                            
        }

        public IList<TEntity> GetAll(JUGContext db)
        {
            return db.Set<TEntity>().ToList();            
        }

        public void Delete(TEntity o, JUGContext db)
        {
            db.Set<TEntity>().Remove(o);                            
        }

        public void DeleteAll(JUGContext db)
        {
                db.Games.RemoveRange(db.Games);
                db.Teams.RemoveRange(db.Teams);            
        }

        public void SaveChanges(JUGContext db)
        {
            db.SaveChanges();
        }

        public void Create(TEntity entity, JUGContext db)
        {
            db.Add(entity);            
        }
    }
}
