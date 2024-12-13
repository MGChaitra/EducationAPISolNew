using System.Net.Http.Json;
using ModelDll;
namespace EducationWebApp.Services
{
    // Add code summary for each methods and properties
    // Add Ilogger for logging
    public class OpenAIService
    {
        private readonly HttpClient _httpClient;

        public OpenAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Add null validation for subject,difficulty and number
        // You can create the private method to perform the validations and avoid the code repetation
        // Add exception handling using try catch
        public async Task<string> GetMCQQuizContentAsync(string subject, string difficulty, int number)
        {
            // Make it post call
            // call the request in this way response = await _httpClient.PostAsJsonAsync("api/quiz/generate", request);
            return await _httpClient.GetStringAsync($"generate-mcq?subject={subject}&difficulty={difficulty}&number={number}");
        }

        public async Task<string> GetShortAnswerQuizContentAsync(string subject, string difficulty, int number)
        {
            // Make it post call
            return await _httpClient.GetStringAsync($"generate-short-answer?subject={subject}&difficulty={difficulty}&number={number}");
        }

        public async Task<string> GetLongAnswerQuizContentAsync(string subject, string difficulty, int number)
        {
            // Make it post call
            return await _httpClient.GetStringAsync($"generate-long-answer?subject={subject}&difficulty={difficulty}&number={number}");
        }
    }
}