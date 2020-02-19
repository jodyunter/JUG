using AutoMapper;
using Domain;
using Services.Config;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Impl
{
    public class BaseService : IBaseService
    {
        public IMapperConfig Mapper { get; set; }

        public BaseService(IMapperConfig config)
        {
            Mapper = config;
        }

    }
}
