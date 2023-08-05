using System.Net.Http;
using System.Text.Json;
using ToDoGrpcHttpClient.Models;

namespace ToDoGrpcHttpClient.Services
{
    public class GetAllToDoService: IGetAllToDoService
    {
        private readonly HttpClient _httpclient;

        public GetAllToDoService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        

        public async Task<ToDoGrpcHttpClient.Dtos.GetAllResponse> GetAllToDo()
        {
            var response = await _httpclient.GetAsync("https://localhost:7098/v1/getAllTodo");

            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
           var result =  await JsonSerializer.DeserializeAsync<ToDoGrpcHttpClient.Dtos.GetAllResponse>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
    }
}
