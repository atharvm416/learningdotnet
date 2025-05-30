using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using coresimulation.Models;

namespace FunctionAppsimuationhttp;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("start")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        //for content-Type: plain/text
        //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

        //for json
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var requestBody = await JsonSerializer.DeserializeAsync<MyRequest>(req.Body, options);

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        //response.WriteString($"Welcome to Azure Functions, {requestBody}!");

        await response.WriteAsJsonAsync(new[] {
            new { DataReceived = "successful", Name = requestBody?.Name }
        });


        return response;
    }
}