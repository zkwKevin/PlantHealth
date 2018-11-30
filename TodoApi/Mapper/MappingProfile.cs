using AutoMapper;
using TodoApi.Models;
using TodoApi.Resources;

namespace TodoApi.AutoMapper{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TargetItem, TargetItemResource>();
            CreateMap<TargetItemResource, TargetItem>();
        }     
    }
}