﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Application.Common.Mappings.Interfaces
{
    public  interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
        //void Mapping(Profile profile)
        //{
        //    profile.CreateMap(typeof(T), GetType());
        //}
    }
}
