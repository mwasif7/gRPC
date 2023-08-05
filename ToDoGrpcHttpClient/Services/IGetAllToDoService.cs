using ToDoGrpcHttpClient.Dtos;

namespace ToDoGrpcHttpClient.Services;

public interface IGetAllToDoService
{
    Task<GetAllResponse> GetAllToDo();
}
