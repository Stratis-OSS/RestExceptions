using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

// ReSharper disable once CheckNamespace
namespace RestExceptions.IntegrationTests.Services;

public abstract class ApiTests(ApiFactory factory)
{
    protected readonly HttpClient Client = factory.CreateHttpsClient();

    protected async Task<ProblemDetails?> GetProblemDetailsAsync(string path, int statusCode)
    {
        var resp = await Client.GetAsync(Path.Join(path, statusCode.ToString()));

        var result = await resp.Content.ReadFromJsonAsync<ProblemDetails>();
        return result;
    }
}
