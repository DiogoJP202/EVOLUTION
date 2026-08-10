namespace TaskManager.Api.Requests;

public class UpdateTaskItemRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set;}
}