using AutoMapper;
using DutchTreat.Data.Entities;
using ps_DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 08/26/2020 09:21 am - SSN - [20200826-0856] - [002] - M08-06 - Using AutoMapper 

namespace ps_DutchTreat.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

        }
    }
}
