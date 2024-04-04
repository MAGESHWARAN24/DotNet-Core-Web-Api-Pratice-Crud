using AutoMapper;
using MongodbWebApi.Dto;
using MongodbWebApi.Models;

namespace MongodbWebApi.Mapper
{
    public class TodoMapperProfile : Profile
    {
        public TodoMapperProfile() { 
            //Source(TodoCreateDTO) --> Destination(Todo)
            //Create Todo
            CreateMap<TodoCreateDTO,Todo>().ReverseMap();
            CreateMap<TodoUpdateDTO,Todo>().ReverseMap();
        }
    }
}
