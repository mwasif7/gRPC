using ToDoGrpcHttpClient.Models;

namespace ToDoGrpcHttpClient.Models;

public class GetAllResponse
{
    public List<ToDoItem> ToDo { get; set; }
}
