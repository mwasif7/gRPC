using ToDoGrpcHttpClient.Dtos;

namespace ToDoGrpcHttpClient.Services;

public interface IGetToDoServiceById
{
    Task<ReadToDoResponse> GetToDoById(int id);
}
