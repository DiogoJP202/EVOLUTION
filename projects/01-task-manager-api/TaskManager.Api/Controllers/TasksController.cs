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
    public IActionResult Get([FromQuery] TaskItemStatus? status)
    {
        ServiceResult<List<TaskItem>> result = _taskItemService.GetAll(status);

        if (result.Success)
            return Ok(result.Data);

        return HandleServiceError(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        ServiceResult<TaskItem> result = _taskItemService.GetById(id);

        if (result.Success)
            return Ok(result.Data);

        return HandleServiceError(result);
    }

    [HttpPost]
    public IActionResult Post(CreateTaskItemRequest request)
    {
        ServiceResult<TaskItem> result = _taskItemService.Create(request);

        if (result.Success)
            return CreatedAtAction(nameof(GetById), new { id = result.Data!.Id }, result.Data);

        return HandleServiceError(result);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateTaskItemRequest request)
    {
        ServiceResult<TaskItem> result = _taskItemService.Update(id, request);

        if (result.Success)
            return Ok(result.Data);
        
        return HandleServiceError(result);
    }

    [HttpPatch("{id}/complete")]
    public IActionResult Complete(int id)
    {
        ServiceResult<TaskItem> result = _taskItemService.Complete(id);

        if (result.Success)
            return Ok(result.Data);
        
        return HandleServiceError(result);
    }

    [HttpPatch("{id}/cancel")]
    public IActionResult Cancel(int id)
    {
        ServiceResult<TaskItem> result = _taskItemService.Cancel(id);

        if (result.Success)
            return Ok(result.Data);
        
        return HandleServiceError(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        ServiceResult<bool> result = _taskItemService.Delete(id);

        if (result.Success)
            return NoContent();
        
        return HandleServiceError(result);
    }

    private IActionResult HandleServiceError<T>(ServiceResult<T> result)
    {
        if (result.ErrorType == ServiceErrorType.NotFound)
            return NotFound(result.ErrorMessage);

        if (result.ErrorType == ServiceErrorType.Validation)
            return BadRequest(result.ErrorMessage);

        if (result.ErrorType == ServiceErrorType.Conflict)
            return Conflict(result.ErrorMessage);
            
        return StatusCode(500, new { error = result.ErrorMessage });
    }
}