using TaskManager.Api.Models;

namespace TaskManager.Api.Services;

public class TaskItemService
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

    public List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public ServiceResult<TaskItem> GetById(int id)
    {
        TaskItem? task = _tasks.FirstOrDefault(task => task.Id == id);

        if (task == null)
            return ServiceResult<TaskItem>.Fail($"Task with id {id} wasn't found.", ServiceErrorType.NotFound);

        return ServiceResult<TaskItem>.Ok(task);
    }
}