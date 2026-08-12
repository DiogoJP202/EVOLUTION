using TaskManager.Api.Models;

namespace TaskManager.Api.Repositories;

public interface ITaskItemRepository
{
    List<TaskItem> GetAll();
    TaskItem? GetById(int id);
    void Add(TaskItem task);
    void Remove(TaskItem task);
    int GetNextId();
}