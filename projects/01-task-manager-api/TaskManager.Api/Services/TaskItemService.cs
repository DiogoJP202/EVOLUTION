using TaskManager.Api.Models;
using TaskManager.Api.Requests;
using TaskManager.Api.Repositories;

namespace TaskManager.Api.Services;

public class TaskItemService
{
    private readonly ITaskItemRepository _taskItemRepository;

    public TaskItemService(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }
    public ServiceResult<List<TaskItem>> GetAll()
    {
        List<TaskItem> tasks = _taskItemRepository.GetAll();

        return ServiceResult<List<TaskItem>>.Ok(tasks);
    }
    public ServiceResult<TaskItem> GetById(int id)
    {
        TaskItem? task = _taskItemRepository.GetById(id);

        if (task == null)
            return ServiceResult<TaskItem>.Fail($"Task with id {id} wasn't found.", ServiceErrorType.NotFound);

        return ServiceResult<TaskItem>.Ok(task);
    }
    public ServiceResult<TaskItem> Create(CreateTaskItemRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return ServiceResult<TaskItem>.Fail("Title is required", ServiceErrorType.Validation);
        }

        TaskItem newTask = new()
        {
            Id = _taskItemRepository.GetNextId(),
            Title = request.Title.Trim(),
            Description = request.Description?.Trim(),
        };

        _taskItemRepository.Add(newTask);
        return ServiceResult<TaskItem>.Ok(newTask);
    }
    public ServiceResult<TaskItem> Update(int id, UpdateTaskItemRequest request)
    {
        TaskItem? task = _taskItemRepository.GetById(id);

        if (task == null)
            return ServiceResult<TaskItem>.Fail("Task wasn't found.", ServiceErrorType.NotFound);

        if (string.IsNullOrWhiteSpace(request.Title))
            return ServiceResult<TaskItem>.Fail("Title is required.", ServiceErrorType.Validation);

        task.Title = request.Title.Trim();
        task.Description = request.Description?.Trim();

        return ServiceResult<TaskItem>.Ok(task);
    }
    public ServiceResult<TaskItem> Complete(int id)
    {
        TaskItem? task = _taskItemRepository.GetById(id);

        if (task == null)
            return ServiceResult<TaskItem>.Fail("Task wasn't found.", ServiceErrorType.NotFound);

        if (task.Status == TaskItemStatus.Completed)
            return ServiceResult<TaskItem>.Fail("Task is completed already.", ServiceErrorType.Conflict);

        if (task.Status == TaskItemStatus.Canceled)
            return ServiceResult<TaskItem>.Fail("You can't complete a task already canceled.", ServiceErrorType.Conflict);

        task.Status = TaskItemStatus.Completed;
        task.CompletedAt = DateTime.UtcNow;

        return ServiceResult<TaskItem>.Ok(task);
    }
    public ServiceResult<TaskItem> Cancel(int id)
    {
        TaskItem? task = _taskItemRepository.GetById(id);

        if (task == null)
            return ServiceResult<TaskItem>.Fail("Task wasn't found.", ServiceErrorType.NotFound);

        if (task.Status == TaskItemStatus.Canceled)
            return ServiceResult<TaskItem>.Fail("Task is canceled already.", ServiceErrorType.Conflict);

        if (task.Status == TaskItemStatus.Completed)
            return ServiceResult<TaskItem>.Fail("You can't cancel a task already completed.", ServiceErrorType.Conflict);

        task.Status = TaskItemStatus.Canceled;
        return ServiceResult<TaskItem>.Ok(task);
    }
    public ServiceResult<bool> Delete(int id)
    {
        TaskItem? task = _taskItemRepository.GetById(id);

        if (task == null)
            return ServiceResult<bool>.Fail("Task wasn't found.", ServiceErrorType.NotFound);

        _taskItemRepository.Remove(task);

        return ServiceResult<bool>.Ok(true);
    }
}
