using TaskManager.Api.Models;
using TaskManager.Api.Services;
using TaskManager.Api.Tests.Fakes;
using TaskManager.Api.Requests;
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

    [Fact]
    public void GetById_WhenTaskDoesNotExist_ShouldReturnNotFound()
    {
        // Arrange
        var service = CreateServiceWithTasks([]);

        // Act
        var result = service.GetById(999);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.NotFound, result.ErrorType);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Create_WhenTitleIsEmpty_ShouldReturnValidation()
    {
        // Arrange
        var service = CreateServiceWithTasks([]);
        var requestBody = new CreateTaskItemRequest
        {
            Title = ""  
        };
        
        // Act
        var result = service.Create(requestBody);
        ServiceResult<List<TaskItem>> tasksResult = service.GetAll(null);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.Validation, result.ErrorType);
        Assert.Empty(tasksResult.Data!);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Create_WhenTitleHasOnlySpaces_ShouldReturnValidation()
    {
        var service = CreateServiceWithTasks([]);
        var requestBody = new CreateTaskItemRequest
        {
            Title = "      "
        };

        var result = service.Create(requestBody);
        ServiceResult<List<TaskItem>> taskResult = service.GetAll(null);
    
        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.Validation, result.ErrorType);
        Assert.Empty(taskResult.Data!);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Create_WhenTitleIsValid_ShouldCreateTask()
    {
        var service = CreateServiceWithTasks([]);
        CreateTaskItemRequest bodyRequest = new()
        {
            Title = "   TaskName  "  
        };

        var result = service.Create(bodyRequest);
        ServiceResult<List<TaskItem>> savedTasks = service.GetAll(null);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Equal("TaskName", result.Data!.Title);
        Assert.Null(result.ErrorMessage);
        Assert.Single(savedTasks.Data!);
        Assert.Equal(TaskItemStatus.Pending, result.Data!.Status);
    }

    [Fact]
    public void Create_WhenDescriptionIsNull_ShouldCreateTaskWithNullDescription()
    {
        var service = CreateServiceWithTasks([]);
        CreateTaskItemRequest request = new()
        {
            Title = "Valid Title."
        };

        var result = service.Create(request);
        ServiceResult<List<TaskItem>> tasksCreated = service.GetAll(null);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Null(result.Data!.Description);
        Assert.Null(result.ErrorMessage);
        Assert.Single(tasksCreated.Data!);
        Assert.Equal(TaskItemStatus.Pending, result.Data!.Status);
    }

    [Fact]
    public void Create_WhenDescriptionHasSpaces_ShouldTrimDescription()
    {
        var service = CreateServiceWithTasks([]);
        CreateTaskItemRequest request = new()
        {
            Title = "Valid Title.",
            Description = "  Trimed Description.   "
        };

        var result = service.Create(request);
        ServiceResult<List<TaskItem>> repoTasks = service.GetAll(null);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Single(repoTasks.Data!);
        Assert.Equal("Trimed Description.", result.Data!.Description);
        Assert.Equal(TaskItemStatus.Pending, result.Data!.Status);
        Assert.Null(result.ErrorMessage);
    }

    [Fact]
    public void GetById_WhenTaskExists_ShouldReturnTask()
    {
        TaskItem task = new()
        {
            Id = 1,
            Title = "Task #1"
        };
        var service = CreateServiceWithTasks([task]);

        ServiceResult<TaskItem> result = service.GetById(1);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Equal(task.Id, result.Data.Id);
        Assert.Equal(task.Title, result.Data.Title);
        Assert.Equal(TaskItemStatus.Pending, result.Data!.Status);
        Assert.Null(result.ErrorMessage);
    }

    [Fact]
    public void GetAll_WhenStatusFilterIsNull_ShouldReturnAllTasks()
    {
        List<TaskItem> tasks = [
            new() {
                Title = "Task #1"
            },
            new() {
                Title = "Task #2"
            }
        ];
        var service = CreateServiceWithTasks(tasks);

        ServiceResult<List<TaskItem>> result = service.GetAll(null);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.NotEmpty(result.Data);
        Assert.Equal(2, result.Data.Count);
        Assert.Null(result.ErrorMessage);
    }

    [Fact]
    public void GetAll_WhenStatusFilterIsCompleted_ShouldReturnOnlyCompletedTasks()
    {
        List<TaskItem> tasks = [
            new(){
                Title = "Completed Task",
                Status = TaskItemStatus.Completed
            },
            new(){
                Title = "Pending Task",
                Status = TaskItemStatus.Pending
            }
        ];

        var service = CreateServiceWithTasks(tasks);

        ServiceResult<List<TaskItem>> result = service.GetAll(TaskItemStatus.Completed);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        TaskItem task = Assert.Single(result.Data);
        Assert.Equal(TaskItemStatus.Completed, task.Status);
        Assert.Null(result.ErrorMessage);
    }

    [Fact]
    public void Update_WhenTaskDoesNotExist_ShouldReturnNotFound()
    {
        UpdateTaskItemRequest request = new()
        {
            Title = "New title"
        };
        var service = CreateServiceWithTasks([]);

        ServiceResult<TaskItem> result = service.Update(999, request);

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.NotFound, result.ErrorType);
        Assert.NotNull(result.ErrorMessage);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Update_WhenTitleIsEmpty_ShouldReturnValidation()
    {
        TaskItem originalTask = new()
        {
            Id = 1,
            Title = "Task #1",
            Description = "Task description."  
        };
        UpdateTaskItemRequest newTaskTitle = new()
        {
            Title = ""  
        };
        var service = CreateServiceWithTasks([originalTask]);

        ServiceResult<TaskItem> result = service.Update(originalTask.Id, newTaskTitle);

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.Validation, result.ErrorType);
        Assert.NotNull(result.ErrorMessage);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Update_WhenTitleHasOnlySpaces_ShouldReturnValidation()
    {
        TaskItem originalTask = new()
        {
            Id = 1,
            Title = "Task #1",
            Description = "Task description."  
        };
        UpdateTaskItemRequest newTaskData = new()
        {
            Title = "    "  
        };
        var service = CreateServiceWithTasks([originalTask]);

        ServiceResult<TaskItem> result = service.Update(originalTask.Id, newTaskData);

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.Validation, result.ErrorType);
        Assert.NotNull(result.ErrorMessage);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Update_WhenDataIsValid_ShouldUpdateTask()
    {
        DateTime createdAt = DateTime.UtcNow;
        TaskItem originalTask = new()
        {
            Id = 1,
            Title = "Task #1",
            Description = "Task description.",
            Status = TaskItemStatus.Pending,
            CreatedAt = createdAt
        };
        UpdateTaskItemRequest newTaskData = new()
        {
            Title = "Valid Title",
            Description = "Valid Description"
        };
        var service = CreateServiceWithTasks([originalTask]);

        ServiceResult<TaskItem> result = service.Update(originalTask.Id, newTaskData);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Equal(newTaskData.Title, result.Data.Title);
        Assert.Equal(newTaskData.Description, result.Data.Description);
        Assert.Equal(createdAt, result.Data.CreatedAt);
        Assert.Null(result.ErrorMessage);
        Assert.Equal(ServiceErrorType.None, result.ErrorType);
    }

    [Fact]
    public void Complete_WhenTaskDoesNotExist_ShouldReturnNotFound()
    {
        var service = CreateServiceWithTasks([]);

        ServiceResult<TaskItem> result = service.Complete(999);

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.NotFound, result.ErrorType);
        Assert.NotNull(result.ErrorMessage);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Complete_WhenTaskIsPending_ShouldCompleteTask()
    {
        TaskItem task = new()
        {
            Id = 1,
            Title = "Task #1",
            Description = "Task Description.",
            Status = TaskItemStatus.Pending
        };
        var service = CreateServiceWithTasks([task]);

        ServiceResult<TaskItem> result = service.Complete(1);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.NotNull(result.Data!.CompletedAt);
        Assert.Equal(TaskItemStatus.Completed, result.Data.Status);
        Assert.Null(result.ErrorMessage);
        Assert.Equal(ServiceErrorType.None, result.ErrorType);
    }

    [Fact]
    public void Cancel_WhenTaskDoesNotExist_ShouldReturnNotFound()
    {
        var service = CreateServiceWithTasks([]);

        ServiceResult<TaskItem> result = service.Cancel(999);

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.NotFound, result.ErrorType);
        Assert.NotNull(result.ErrorMessage);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Cancel_WhenTaskIsPending_ShouldCancelTask()
    {
        TaskItem task = new()
        {
            Id = 1,
            Title = "Task #1",
            Description = "Task Description.",
            Status = TaskItemStatus.Pending
        };
        var service = CreateServiceWithTasks([task]);

        ServiceResult<TaskItem> result = service.Cancel(1);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Null(result.Data.CompletedAt);
        Assert.Equal(TaskItemStatus.Canceled, result.Data.Status);
        Assert.Null(result.ErrorMessage);
        Assert.Equal(ServiceErrorType.None, result.ErrorType);
    }

    [Fact]
    public void Delete_WhenTaskDoesNotExist_ShouldReturnNotFound()
    {
        var service = CreateServiceWithTasks([]);

        ServiceResult<bool> result = service.Delete(999);

        Assert.False(result.Success);
        Assert.Equal(ServiceErrorType.NotFound, result.ErrorType);
        Assert.NotNull(result.ErrorMessage);
        Assert.False(result.Data);   
    }

    [Fact]
    public void Delete_WhenTaskExists_ShouldRemoveTask()
    {
        TaskItem task = new()
        {
            Id = 1,
            Title = "Task #1",
            Description = "Task Description.",
            Status = TaskItemStatus.Pending
        };
        var service = CreateServiceWithTasks([task]);
        
        ServiceResult<bool> result = service.Delete(1);
        ServiceResult<TaskItem> searchResult = service.GetById(1);

        Assert.True(result.Success);
        Assert.True(result.Data);

        Assert.False(searchResult.Success);
        Assert.Equal(ServiceErrorType.NotFound, searchResult.ErrorType);
        Assert.Null(searchResult.Data);
    }

    [Fact]
    public void Create_WhenDescriptionHasOnlySpaces_ShouldTrimDescriptionToEmptyString()
    {
        var service = CreateServiceWithTasks([]);
        CreateTaskItemRequest request = new()
        {
            Title = "Valid Title.",
            Description = "      "
        };

        var result = service.Create(request);
        ServiceResult<List<TaskItem>> repoTasks = service.GetAll(null);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Single(repoTasks.Data!);
        Assert.Equal("", result.Data!.Description);
        Assert.Equal(TaskItemStatus.Pending, result.Data!.Status);
        Assert.Null(result.ErrorMessage);
    }

    private static TaskItemService CreateServiceWithTasks(List<TaskItem> tasks)
    {
        var repository = new FakeTaskItemRepository(tasks);
        return new TaskItemService(repository);
    }
}