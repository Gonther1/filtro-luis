using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFiltro.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Querys;

namespace ApiFiltro.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            /* CreateMap<GamaProducto, GamasProductosSimplify>()
            .ReverseMap();  */ 
        }
    }
}