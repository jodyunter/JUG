using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IDataService<TEntity> where TEntity : IDAOObject
    {
        TEntity GetById(long Id);
        void Save(TEntity entity);
        void Create(TEntity entity);
    }
}
