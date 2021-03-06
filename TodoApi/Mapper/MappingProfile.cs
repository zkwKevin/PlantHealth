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

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<User, UserProfileViewModel>();
            CreateMap<UserProfileViewModel, User>();

            CreateMap<TodoItem, TodoItemResources>();
            CreateMap<TodoItemResources, TodoItem>();
        }     
    }
}