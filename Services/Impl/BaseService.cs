using AutoMapper;
using Domain;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Impl
{
    public class BaseService : IBaseService
    {
        public IMapper Mapper { get; set; }

        public BaseService(MapperConfiguration config)
        {
            Mapper = new Mapper(config);
        }

    }
}
