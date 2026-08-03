using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Requests;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private static int _nextId = 3;
    private static readonly List<TaskItem> _tasks =  
    [
        new TaskItem()
        {
            Id = 1,
            Title = "Tarefa #1",
        },
        new TaskItem()
        {
            Id = 2,
            Title = "Tarefa #2",
        },
        new TaskItem()
        {
            Id = 3,
            Title = "Tarefa #3",
        }
    ];

    [HttpGet]
    public IActionResult Get()
    {        
        return Ok(_tasks);
    }

    [HttpPost]
    public IActionResult Post(CreateTaskItemRequest request)
    {

        
        _nextId += 1;

        TaskItem newTask = new(){ 
            Id = _nextId,
            Title =  request.Title, 
            Description = request.Description, 
        };

        _tasks.Add(newTask);
        return Created($"api/tasks/{_nextId}", newTask);
    }
}