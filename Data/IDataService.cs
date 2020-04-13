using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IDataService<TEntity> where TEntity : IDAOObject
    {
        //eventually we may want CreateNoSave or a SaveNoSave method so we can chain them into transactions
        TEntity GetById(long Id, JUGContext db);
        void Save(TEntity entity, JUGContext db);
        void Create(TEntity entity, JUGContext db);
        IList<TEntity> GetAll(JUGContext db);
        void Delete(TEntity entity, JUGContext db);
        void SaveChanges(JUGContext db);
    }
}
