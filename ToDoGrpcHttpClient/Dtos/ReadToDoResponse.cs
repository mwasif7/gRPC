namespace ToDoGrpcHttpClient.Dtos;

public class ReadToDoResponse
{
  public int Id { get; set; }

  public string? Title { get; set; }

  public string? Description { get; set; }

  public string? ToDoStatus { get; set; }
}
