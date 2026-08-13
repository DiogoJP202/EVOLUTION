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

        List<TaskItem> tasks = [task];
        
        var repository = new FakeTaskItemRepository(tasks);
        var service = new TaskItemService(repository);

        // Act

        var result = service.Complete(1);

        // Assert

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.Conflict, result.ErrorType);
        Assert.Equal(TaskItemStatus.Canceled, task.Status);
        Assert.Null(task.CompletedAt);
    }
}
