using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ToDoGrpcHttpClient.Controllers;
using ToDoGrpcHttpClient.Models;
using ToDoGrpcHttpClient.Services;

namespace Benchmark.Tests
{
    public class ToDoControllerTests
    {
        // ... other test methods ...

        [Benchmark]
        public async Task PerformanceTest()
        {
            // Initialize the HttpClient (make sure to reuse it for better performance)
            var httpClient = new HttpClient();

            // Arrange
            var getAllService = new GetAllToDoService(httpClient);
            var controller = new ToDoController(getAllService, null);

            // Act
            var iterations = 100; // The number of iterations you want to perform

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < iterations; i++)
            {
                var response = await controller.GetAll();
            }

            stopwatch.Stop();

            Console.WriteLine($"Average execution time per iteration: {stopwatch.Elapsed.TotalMilliseconds / iterations} ms");
        }
    }
}
