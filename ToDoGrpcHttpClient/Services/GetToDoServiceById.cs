﻿using System.Net.Http;
using System.Text.Json;
using ToDoGrpcHttpClient.Dtos;
using ToDoGrpcHttpClient.Models;

namespace ToDoGrpcHttpClient.Services
{
    public class GetToDoServiceById : IGetToDoServiceById
    {
        private readonly HttpClient _httpclient;

        public GetToDoServiceById(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

       public async Task<ReadToDoResponse> GetToDoById(int id)
        {

            var response = await _httpclient.GetAsync($"https://localhost:7098/v1/getTodo/1");

            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<ToDoGrpcHttpClient.Dtos.ReadToDoResponse>(responseStream, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
    }
}
