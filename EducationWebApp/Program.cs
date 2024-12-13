using EducationWebApp.Services;
using EducationWebApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//register IOpenAIService and IGenerateQuizPDFContentService
builder.Services.AddScoped<OpenAIService>();
builder.Services.AddScoped<GenerateQuizPDFContentService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7291/api/quiz/") });


await builder.Build().RunAsync();
