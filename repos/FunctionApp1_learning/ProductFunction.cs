using FunctionApp1_learning.Models;
using FunctionApp1_learning.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace FunctionApp1_learning;

public class ProductFunction
{
    private readonly ILogger<ProductFunction> _logger;
    private readonly AppdbContext _dbContext;
    private readonly ProductServices _prodservices;

    public ProductFunction(ILogger<ProductFunction> logger, AppdbContext dbContext, ProductServices productServices)
    {
        _logger = logger;
        _dbContext = dbContext;
        _prodservices = productServices;
    }

    [Function("AddProduct")]
    public async Task<HttpResponseData> AddProduct(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "products")] HttpRequestData req)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var product = JsonSerializer.Deserialize<Product>(requestBody);

        await _prodservices.Addproduct(product);

        var response = req.CreateResponse(HttpStatusCode.Created);
        await response.WriteAsJsonAsync(product);

        return response;
    }

    [Function("UpdateProduct")]
    public async Task<HttpResponseData> UpdateProduct([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "products")] HttpRequestData req)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var product = JsonSerializer.Deserialize<Product>(requestBody);

       await _prodservices.Updateproduct(product);

        var response = req.CreateResponse(HttpStatusCode.Created);

        return response;
    }
}