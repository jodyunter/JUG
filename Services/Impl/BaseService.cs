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
        public IMapperConfig Mapper { get; set; }
        public IDataService<TDAOObject> DataService { get; set; }

        public BaseService(IMapperConfig config)
        {
            Mapper = config;
        }

        public override TDomainObject MapDAOToDomain(TDAOObject dao)
        {
            return Mapper.TeamDAOToTeam(dao);
        }

        public override TeamDAO MapDomainToDAO(Team domain)
        {
            return Mapper.TeamToTeamDAO(domain);
        }

        public override TeamViewModel MapDomainToViewModel(Team domain)
        {
            return Mapper.TeamToTeamViewModel(domain);
        }

        public override Team MapViewModelToDomain(TeamViewModel model)
        {
            return Mapper.TeamViewModelToTeam(model);
        }

        public abstract TDAOObject CreateDAO(TViewModel newModel);
        public abstract TDomainObject MapDAOToDomain(TDAOObject dao);        
        public abstract TViewModel MapDomainToViewModel(TDomainObject domain);
        public abstract TDomainObject MapViewModelToDomain(TViewModel model);
        public abstract TDAOObject MapDomainToDAO(TDomainObject domain);
        public TViewModel Create(TViewModel newModel)
        {
            var dao = CreateDAO(newModel);

            var domain = MapDAOToDomain(dao);

            return MapDomainToViewModel(domain);
        }

        public IList<TDomainObject> MapDAOToDomain(IList<TDAOObject> daos)
        {
            var data = new List<TDomainObject>();

            daos.ToList().ForEach(i => { data.Add(MapDAOToDomain(i)); });

            return data;

        }
        public IList<TViewModel> MapDomainToViewModel(IList<TDomainObject> domains)
        {
            var data = new List<TViewModel>();

            domains.ToList().ForEach(i => { data.Add(MapDomainToViewModel(i)); });

            return data;
        }
        

        public void Update(TViewModel model)
        {
            var domain = MapViewModelToDomain(model);

            var dao = MapDomainToDAO(domain);

            DataService.Save(dao);
        }


        public TViewModel GetById(long id)
        {
            var domain = GetDomainObjectById(id);

            var model = MapDomainToViewModel(domain);

            return model;
        }

        public TDomainObject GetDomainObjectById(long id)
        {
            var dao = DataService.GetById(id);

            return MapDAOToDomain(dao);
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
