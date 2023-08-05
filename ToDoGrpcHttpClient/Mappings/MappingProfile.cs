using AutoMapper;
using ToDoGrpcHttpClient.Dtos;
using ToDoGrpcHttpClient.Models;

namespace ToDoGrpcHttpClient.Mappings;

public class MappingProfile : Profile{
  public MappingProfile(){
     CreateMap<ToDoItem, CreateToDoResponse>();
    CreateMap<ToDoItem, CreateToDoRequestDto>();
    CreateMap<ToDoItem, DeleteToDoRequest>();
    CreateMap<ToDoItem, DeleteToDoResponse>();
    CreateMap<Models.GetAllResponse, Dtos.GetAllResponse>();
    CreateMap<ToDoItem, ReadToDoRequest>();
    CreateMap<ToDoItem, ReadToDoResponse>();
    CreateMap<ToDoItem, UpdateToDoRequest>();
    CreateMap<ToDoItem, UpdateToDoResponse>();


  }


}