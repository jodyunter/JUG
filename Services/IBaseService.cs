using AutoMapper;
using Data;
using Domain;
using Services.Config;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IBaseService<TViewModel, TDomainObject, TDAOObject>
    {        
        public TViewModel Create(TViewModel newModel);
        public void Update(TViewModel model);
        public TViewModel GetById(long id);
        public TDomainObject GetDomainObjectById(long id);
        public IList<TViewModel> GetAll();
        public void Delete(long? id);
    }
}
