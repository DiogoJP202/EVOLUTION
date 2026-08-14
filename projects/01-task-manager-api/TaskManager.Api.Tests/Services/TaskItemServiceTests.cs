using System.ComponentModel;
using TaskManager.Api.Models;
using TaskManager.Api.Services;
using TaskManager.Api.Tests.Fakes;

namespace TaskManager.Api.Tests.Services;

public class TaskItemServiceTests
{
    [Fact]
    public void Complete_WhenTaskIsCanceled_ShouldReturnConflict()
    {
        // Arrange
        TaskItem task = new TaskItem
        {
            Id = 1,
            Title = "Tarefa cancelada.",
            Status = TaskItemStatus.Canceled
        };

        var service = CreateServiceWithTasks([task]);

        // Act

        var result = service.Complete(1);

        // Assert

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.Conflict, result.ErrorType);
        Assert.Equal(TaskItemStatus.Canceled, task.Status);
        Assert.Null(task.CompletedAt);
    }

    [Fact]    
    public void Cancel_WhenTaskIsCompleted_ShouldReturnConflict()
    {
        // Arrange
        DateTime completedAt = DateTime.UtcNow;

        TaskItem task = new TaskItem
        {
            Id = 1,
            Title = "Tarefa concluída.",
            Status = TaskItemStatus.Completed,
            CompletedAt = completedAt
        };

        var service = CreateServiceWithTasks([task]);

        // Act

        var result = service.Cancel(1);

        // Assert

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.Conflict, result.ErrorType);
        Assert.Equal(TaskItemStatus.Completed, task.Status);
        Assert.Equal(completedAt, task.CompletedAt);
    }

    private static TaskItemService CreateServiceWithTasks(List<TaskItem> tasks)
    {
        var repository = new FakeTaskItemRepository(tasks);
        return new TaskItemService(repository);
    }
}
