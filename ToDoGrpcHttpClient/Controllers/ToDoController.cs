using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ToDoGrpcHttpClient.Dtos;
using ToDoGrpcHttpClient.Services;

namespace ToDoGrpcHttpClient.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{

    private readonly IGetAllToDoService _getAllService;
    private readonly IGetToDoServiceById _getAllServiceById;

    public ToDoController(
        IGetAllToDoService getAllservice,
        IGetToDoServiceById getAllServiceById
        )
    {
        _getAllService = getAllservice;
        _getAllServiceById = getAllServiceById;

    }

    [HttpGet]
    public async Task<GetAllResponse> GetAll()
    {
        var result = await _getAllService.GetAllToDo();
        return result;
    }

    [HttpGet("{id}")]

    public async Task<ReadToDoResponse> GetById(int id)
    {
        var result = await _getAllServiceById.GetToDoById(id);
        return result;
    }
}