using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Requests;
using TaskManager.Api.Services;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly TaskItemService _taskItemService;

    public TasksController(TaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        TaskItem? task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task == null)
            return NotFound($"Task with id {id} wasn't found.");

        return Ok(task);
    }

    [HttpPost]
    public IActionResult Post(CreateTaskItemRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return BadRequest("Title is required.");
        }

        _nextId += 1;

        TaskItem newTask = new(){
            Id = _nextId,
            Title =  request.Title.Trim(),
            Description = request.Description,
        };

        _tasks.Add(newTask);
        return CreatedAtAction(nameof(GetById), new { id = newTask.Id }, newTask);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateTaskItemRequest request)
    // Quando existe um objeto complexo no como parâmetro o ASP.NET automáticamente supoe que ele é o body.
    {
        TaskItem? task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task == null)
            return NotFound("Task wasn't found.");

        if (string.IsNullOrWhiteSpace(request.Title))
            return BadRequest("Title is required.");

        task.Title = request.Title.Trim();
        task.Description = request.Description?.Trim();

        return Ok(task);
    }

    [HttpPatch("{id}/complete")]
    public IActionResult Complete(int id)
    {
        TaskItem? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound("Task wasn't found.");

        if (task.Status == TaskItemStatus.Completed)
            return BadRequest("Task is completed already.");

        if (task.Status == TaskItemStatus.Canceled)
            return BadRequest("You can't complete a task already canceled.");

        task.Status = TaskItemStatus.Completed;
        task.CompletedAt = DateTime.UtcNow;

        return Ok(task);
    }

    [HttpPatch("{id}/cancel")]
    public IActionResult Cancel(int id)
    {
        TaskItem? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound("Task wasn't found.");

        if (task.Status == TaskItemStatus.Canceled)
            return BadRequest("Task is canceled already.");

        if (task.Status == TaskItemStatus.Completed)
            return BadRequest("You can't cancel a task already completed.");

        task.Status = TaskItemStatus.Canceled;

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        TaskItem? task = _tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
            return NotFound("Task wasn't found.");

        _tasks.Remove(task);

        return NoContent();
    }
}
