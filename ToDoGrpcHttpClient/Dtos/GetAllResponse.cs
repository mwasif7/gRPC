namespace ToDoGrpcHttpClient.Dtos;

public class GetAllResponse
{
  public List<ReadToDoResponse>? ToDo { get; set; }
}