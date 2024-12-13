using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace EducationAPI.Controllers
{
    [EnableCors("cors")]
    [ApiController]
    [Route("api/quiz")]
    public class QuizController : Controller
    {
        // Add summary to methods and properties
        // Add exception handling using try catch
        // Add Ilogger for logging
        // Create new folder Services

        private readonly Kernel _kernel;
        private readonly ChatHistory _history;
        private readonly IChatCompletionService _chatCompletionService;
        public QuizController(Kernel kernel)
        {
            _kernel = kernel;
            _history = new ChatHistory();
            // Improve the prompt by adding some rules to it
            _history.AddSystemMessage("You are an Educational Content Generator and a helpful assistant that specializes in generating quiz questions. Your goal is to create valid, meaningful, and accurate questions for quizzes and exams, tailored to various Question Types, Subjects, Number of Questions and Difficulty Levels. Strictly remove the escaping characters like \"\\\" included in the response");
            _chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        }

        // Instead of getting parameters from query parameters, get it from request body. Make the call as Post
        [HttpGet("generate-mcq")]
        public async Task<IActionResult> GenerateMCQQuiz([FromQuery] string subject, [FromQuery] string difficulty, [FromQuery] int number)
        {
            // Code is repetitive, instead you can create a helper method GenerateQuizContentAsync to handle the common logic
            _history.AddUserMessage(subject);
            _history.AddUserMessage(difficulty);
            _history.AddUserMessage(number.ToString());
            _history.AddUserMessage("MCQ");
            var openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };

            var result = await _chatCompletionService.GetChatMessageContentAsync(
                _history,
                executionSettings: openAIPromptExecutionSettings,
                kernel: _kernel);

            return Ok(result.Content);
     
        }

        [HttpGet("generate-short-answer")]
        public async Task<IActionResult> GenerateShortAnswerQuiz([FromQuery] string subject, [FromQuery] string difficulty, [FromQuery] int number)
        {
            // Code is repetitive, instead you can create a helper method GenerateQuizContentAsync to handle the common logic
            _history.AddUserMessage(subject);
            _history.AddUserMessage(difficulty);
            _history.AddUserMessage(number.ToString());
            _history.AddUserMessage("Short Answer");
            var openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };

            var result = await _chatCompletionService.GetChatMessageContentAsync(
                _history,
                executionSettings: openAIPromptExecutionSettings,
                kernel: _kernel);

            return Ok(result.Content);
        }


        [HttpGet("generate-long-answer")]
        public async Task<IActionResult> GenerateLongAnswerQuiz([FromQuery] string subject, [FromQuery] string difficulty, [FromQuery] int number)
        {
            // Code is repetitive, instead you can create a helper method GenerateQuizContentAsync to handle the common logic
            _history.AddUserMessage(subject);
            _history.AddUserMessage(difficulty);
            _history.AddUserMessage(number.ToString());
            _history.AddUserMessage("Long Answer");
            var openAIPromptExecutionSettings = new OpenAIPromptExecutionSettings
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };

            var result = await _chatCompletionService.GetChatMessageContentAsync(
                _history,
                executionSettings: openAIPromptExecutionSettings,
                kernel: _kernel);

            return Ok(result.Content);
        }

       
    }
}
