using Grpc.Core;
using Grpc.Data;
using Grpc.Models;
using Microsoft.EntityFrameworkCore;
using ToDoGrpc;

namespace ToDoGrpc.Services;

public class ToDoService : ToDoIt.ToDoItBase
{
    private readonly AppDbContext _dbContext;

    public ToDoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<CreateToDoResponse> CreateToDo(CreateToDoRequest request, ServerCallContext context)
    {
        if (request.Description == string.Empty || request.Title == string.Empty)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "You must supply a valid object"));

        var toDoItem = new ToDoItem
        {
            Description = request.Description,
            Title = request.Title,
        };

        await _dbContext.ToDoItems.AddAsync(toDoItem);
        await _dbContext.SaveChangesAsync();

        return await Task.FromResult(new CreateToDoResponse
        {
            Id = toDoItem.Id
        });
    }

    public override async Task<ReadToDoResponse> ReadToDo (ReadToDoRequest request, ServerCallContext context)
    {
        if(request.Id <= 0)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "index must be greater than 0"));
        
        var todoItem = _dbContext.ToDoItems.FirstOrDefault(x => x.Id == request.Id);

        if(todoItem != null)
        {
            return await Task.FromResult(new ReadToDoResponse
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                ToDoStatus = todoItem.ToDoStatus,

            });
        }

        throw new RpcException(new Status(StatusCode.InvalidArgument, "No data found"));

    }

    public override async Task<GetAllResponse> ListToDo(GetAllRequest request, ServerCallContext context)
    {
        var response = new GetAllResponse();
        var toDoItems = await  _dbContext.ToDoItems.ToListAsync();

        foreach(var item in toDoItems)
        {
            response.ToDo.Add(new ReadToDoResponse{
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                ToDoStatus = item.ToDoStatus,
            });
        }

        if(response is not null){
            return await Task.FromResult(response);
        }

        throw new RpcException(new Status(StatusCode.NotFound,"No record found"));
    }

    public override async Task<UpdateToDoResponse> UpdateToDo(UpdateToDoRequest request, ServerCallContext context){
        if(request.Id <= 0)
            throw new RpcException(new Status(StatusCode.NotFound, "Please provide valid item to update"));

        var todoItem = _dbContext.ToDoItems.FirstOrDefault(x => x.Id == request.Id) ?? throw new RpcException(new Status(StatusCode.NotFound, "Please provide valid item to update"));

        todoItem.Description = request.Description;
        todoItem.Title = request.Title;
        todoItem.ToDoStatus = request.ToDoStatus;

        await _dbContext.SaveChangesAsync();

        return await Task.FromResult(new UpdateToDoResponse{
            Id = todoItem.Id
        });    
    }
    public override async Task<DeleteToDoResponse> DeleteToDo(DeleteToDoRequest request, ServerCallContext context)
    {
        if (request.Id <= 0)
            throw new RpcException(new Status(StatusCode.NotFound, "Please provide valid item to delete"));

        var todoItem = _dbContext.ToDoItems.FirstOrDefault(x => x.Id == request.Id) ?? throw new RpcException(new Status(StatusCode.NotFound, "Please provide valid item to update"));

        _dbContext.ToDoItems.Remove(todoItem);

        await _dbContext.SaveChangesAsync();

        return await Task.FromResult(new DeleteToDoResponse
        {
            Id = todoItem.Id
        });
    }


}