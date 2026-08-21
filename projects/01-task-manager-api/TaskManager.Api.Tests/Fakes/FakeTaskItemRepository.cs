using TaskManager.Api.Repositories;
using TaskManager.Api.Models;

namespace TaskManager.Api.Tests.Fakes;

public class FakeTaskItemRepository : ITaskItemRepository
{

    private readonly List<TaskItem> _tasks;
    private int _nextId;

    public FakeTaskItemRepository(List<TaskItem> tasks)
    {
        _tasks = tasks.ToList();
        _nextId = _tasks.Count == 0 
            ? 0 
            : _tasks.Max(t => t.Id);
    }
    
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