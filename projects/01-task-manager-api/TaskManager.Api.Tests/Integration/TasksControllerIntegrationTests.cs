using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TaskManager.Api.Tests.Integration;

public class TaskControllerIntegrationTests
{
    [Fact]
    public async Task Get_WhenCalled_ShouldReturnOk()
    {
        // Arrange
        await using var factory = new WebApplicationFactory<Program>();
        HttpClient client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/tasks");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    private static async Task<HttpClient> CreateClient()
    {
        await using var factory = new WebApplicationFactory<Program>();
        return factory.CreateClient();
    }
}