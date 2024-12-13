using EducationAPI.Plugins;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(setUp =>
{
    setUp.AddPolicy("cors", setUp =>
    {
        setUp.AllowAnyHeader();
        setUp.AllowAnyMethod();
        setUp.AllowAnyOrigin();
    });
});
// Add services to the container.
IConfigurationRoot configuration = new ConfigurationBuilder()

.AddJsonFile("appsettings.json")

.AddUserSecrets<Program>()

.Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(sp =>
{
   
    var kernelBuilder = Kernel.CreateBuilder();
    kernelBuilder.AddAzureOpenAIChatCompletion(
        deploymentName: configuration["AzureOpenAI:DeploymentName"],
        endpoint: configuration["AzureOpenAI:Endpoint"],
        apiKey: configuration["AzureOpenAI:ApiKey"]);
    kernelBuilder.Plugins.AddFromType<QuizPlugin>("Quiz");
    return kernelBuilder.Build();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("cors");

app.UseAuthorization();

app.MapControllers();

app.Run();
