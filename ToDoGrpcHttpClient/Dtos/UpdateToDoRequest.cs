namespace ToDoGrpcHttpClient.Dtos;

public class UpdateToDoRequest
{
  public int Int { get; set; }

  public string? Title { get; set; }

  public string? Description { get; set; }

  public string? ToDoStatus { get; set; }
}