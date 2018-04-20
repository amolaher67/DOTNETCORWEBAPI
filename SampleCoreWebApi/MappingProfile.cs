using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SampleCoreWebApi.BusinessEntities.EntityModels;
using SampleCoreWebApi.DataModel.Models;

namespace SampleCoreWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<PoliticalLeaders,EntityPoliticalLeaders>();
            CreateMap<Volunteers, EntityVolunteers>();
        }
    }
}
