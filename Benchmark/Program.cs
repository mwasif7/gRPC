using BenchmarkDotNet.Running;
using Benchmark.Tests;

var summary = BenchmarkRunner.Run<ToDoControllerTests>();
//await new ToDoControllerTests().PerformanceTest();