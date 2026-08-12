using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories;

public class TaskItemRepository : ITaskItemRepository
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

    public TaskItem? GetById(int id)
    {
        TaskItem? task = _tasks.FirstOrDefault(task => task.Id == id);
        return task;
    }

    public void Add(TaskItem task)
    {
        _tasks.Add(task);
    }

    public void Remove(TaskItem task)
    {
        _tasks.Remove(task);
    }

    public int GetNextId()
    {
        _nextId += 1;
        return _nextId;
    }
}
