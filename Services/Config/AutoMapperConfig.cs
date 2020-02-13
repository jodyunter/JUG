using AutoMapper;
using AutoMapper.Configuration;
using Data.DAO;
using Domain.Teams;
using Services.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Config
{
    public class AutoMapperConfig
    {
        public IMapper Mapper { get; set; }
        public AutoMapperConfig()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Team, TeamViewModel>();
            cfg.CreateMap<TeamViewModel, Team>();
            cfg.CreateMap<Team, TeamDAO>();
            cfg.CreateMap<TeamDAO, Team>();
        }
    }
}
