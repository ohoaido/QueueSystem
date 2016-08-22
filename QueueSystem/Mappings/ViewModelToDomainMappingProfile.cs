using AutoMapper;
using QueueSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueSystem.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<HeThongSoViewModels, HeThongSo>()
                .ForMember(vm => vm.ID, map => map.MapFrom(m => m.ID))
                .ForMember(vm => vm.ManHinhID, map => map.MapFrom(m => m.ManHinhID))
                .ForMember(vm => vm.ManHinh, opt => opt.Ignore())
                .ForMember(vm => vm.Goi, map => map.MapFrom(m => m.Goi))
                .ForMember(vm => vm.STT, map => map.MapFrom(m => m.STT));
        }
    }
}