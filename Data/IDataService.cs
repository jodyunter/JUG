using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IDataService<TEntity> where TEntity : IDAOObject
    {
        //eventually we may want CreateNoSave or a SaveNoSave method so we can chain them into transactions
        TEntity GetById(long Id);
        void Save(TEntity entity);
        void Create(TEntity entity);
        IList<TEntity> GetAll();
        void Delete(TEntity entity);
    }
}
