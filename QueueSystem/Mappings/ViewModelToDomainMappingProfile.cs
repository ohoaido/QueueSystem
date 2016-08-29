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

            Mapper.CreateMap<PortInfomaitonElectricViewModels, PortInfomaitonElectric>()
                .ForMember(vm => vm.ID, map => map.MapFrom(m => m.ID))
                .ForMember(vm => vm.User, opt => opt.Ignore())
                .ForMember(vm => vm.IsPublic, map => map.MapFrom(m => m.IsPublic))
                .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
                .ForMember(vm => vm.Phone, map => map.MapFrom(m => m.Phone))
                .ForMember(vm => vm.Url, map => map.MapFrom(m => m.Url));
        }
    }
}