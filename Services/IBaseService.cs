﻿using AutoMapper;
using Domain;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IBaseService
    {
        IMapper Mapper { get; set; }
    }
}
