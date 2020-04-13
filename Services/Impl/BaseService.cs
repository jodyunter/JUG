using AutoMapper;
using Data;
using Domain;
using Services.Config;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Impl
{
    public abstract class BaseService<TViewModel, TDomainObject, TDAOObject> : IBaseService<TViewModel, TDomainObject, TDAOObject> where TViewModel:IViewModel where TDomainObject : IDomainObject where TDAOObject:IDAOObject
    {
        public IJUGMapper<TViewModel, TDomainObject, TDAOObject> Mapper { get; set; }
        public IDataService<TDAOObject> DataService { get; set; }

        public abstract  void CreateMapper();
        public BaseService()
        {
            CreateMapper();
        }
        

        public TViewModel Create(TViewModel newModel)
        {
            var dao = Mapper.DomainToDAO(Mapper.ViewModelToDomain(newModel));

            var domain = Mapper.DAOToDomain(dao);

            return Mapper.DomainToViewModel(domain);
        }

        public IList<TDomainObject> MapDAOToDomain(IList<TDAOObject> daos)
        {
            var data = new List<TDomainObject>();

            daos.ToList().ForEach(i => { data.Add(Mapper.DAOToDomain(i)); });

            return data;

        }
        public IList<TViewModel> MapDomainToViewModel(IList<TDomainObject> domains)
        {
            var data = new List<TViewModel>();

            domains.ToList().ForEach(i => { data.Add(Mapper.DomainToViewModel(i)); });

            return data;
        }
        

        public void Update(TViewModel model)
        {
            var domain = Mapper.ViewModelToDomain(model);

            var dao = Mapper.DomainToDAO(domain);

            DataService.Save(dao);
        }


        public TViewModel GetById(long id)
        {
            var domain = GetDomainObjectById(id);

            var model = Mapper.DomainToViewModel(domain);

            return model;
        }

        public TDomainObject GetDomainObjectById(long id)
        {
            var dao = DataService.GetById(id);

            return Mapper.DAOToDomain(dao);
        }

        public IList<TViewModel> GetAll()
        {
            var daos = DataService.GetAll();

            var domains = MapDAOToDomain(daos);

            var models = MapDomainToViewModel(domains);

            return models.ToList();

        }

        public void Delete(long? id)
        {
            if (id != null)
            {
                var actualId = (long)id;

                var daoObject = DataService.GetById(actualId);
                DataService.Delete(daoObject);
            }
        }

    }
}
