using AutoMapper;
using DevGames.Application.ViewModel;
using DevGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OrderViewModel, Order>().ForMember(dest => dest.AddressId, opt => opt.MapFrom(map => map.Address.Id));
        }
    }
}
