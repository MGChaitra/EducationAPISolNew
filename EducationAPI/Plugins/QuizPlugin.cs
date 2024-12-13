using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace EducationAPI.Plugins
{
    public class QuizPlugin
    {
        // Add description to the parameter as provided for kernel function, even provide return descrption
        // Improve the prompt, for example you can add like Follow the below few shots examples and also provide few more examples,
        // for note you can update as Rules
        [KernelFunction("generate_mcq_quiz")]
        [Description("Generate MCQ quiz questions based on the subject, difficulty, and number of questions.")]
        public async Task<string> GenerateMCQQuiz(string subject, string difficulty, int numberOfQuestions)
        {
            return $"""
                ###MCQ Question Generation Prompt
                You are an AI assistant who is an expert in generating quiz questions based on the selected Question Type: "MCQ" Subject: {subject}, Difficulty Level: {difficulty} and Question type: MCQ, and Number of Questions: {numberOfQuestions}. Your goal is to generate valid and meaningful multiple-choice questions for the particular subject and difficulty level.
                
                ###Example:
                What is the basic unit of life ? 
                a) Cell 
                b) Atom 
                c) Molecule 
                d) Organ 
                Answer: a) Cell

                ###Note
                1. Strictly take Consideration of the Constraints such as "Question Type", "Subject", "Difficulty Level" and "Number of Questions".
                2. Strictly Don't print any other Content or Sentence other than Quize contect.
                3. Strictly give Answer for all Questions.
                4. Strictly remove the escaping characters like "\" included in the response.
                """;
        }

        // Add description to the parameter
        // Improve the prompt descri[ption
        [KernelFunction("generate_short_answer_quiz")]
        [Description("Generate short-answer quiz questions based on the subject, difficulty, and number of questions.")]
        public async Task<string> GenerateShortAnswerQuiz(string subject, string difficulty, int numberOfQuestions)
        {
            return $"""
                ###Short Answer Question Generation Prompt
                You are an AI assistant who is an expert in generating quiz questions based on the selected Question Type: "Short Answer" Subject: {subject}, Difficulty Level: {difficulty}, and Number of Questions: {numberOfQuestions}.Your goal is to generate valid and meaningful short answer questions for the particular subject and difficulty level.
                
                ###Example:
                What are the four states of matter? 
                Answer: Solid, liquid, gas, and plasma

                ###Note
                1. Strictly take Consideration of the Constraints such as "Question Type", "Subject", "Difficulty Level" and "Number of Questions".
                2. Strictly Don't print any other Content or Sentence other than Quize contect.
                3. Strictly give Answer for all Questions.
                4. Strictly remove the escaping characters like "\" included in the response.
                """;
        }

        // Add description to the parameter
        // Improve the prompt descri[ption
        [KernelFunction("generate_long_answer_quiz")]
        [Description("Generate long-answer quiz questions based on the subject, difficulty, and number of questions.")]
        public async Task<string> GenerateLongAnswerQuiz(string subject, string difficulty, int numberOfQuestions)
        {
            return $"""
                ###Long Answer Question Generation Prompt
                You are an AI assistant who is an expert in generating quiz questions based on the selected Question Type: "Long Answer" Subject: {subject}, Difficulty Level: {difficulty}, and Number of Questions: {numberOfQuestions}. Your goal is to generate valid and meaningful long answer questions for the particular subject and difficulty level.
                
                ###Example:
                Explain the Photosynthesis Process. 
                Answer: Photosynthesis is a process by which phototrophs convert light energy into chemical energy, which is later used to fuel cellular activities. The chemical energy is stored in the form of sugars, which are created from water and carbon dioxide.


                ###Note
                1. Strictly take Consideration of the Constraints such as "Question Type", "Subject", "Difficulty Level" and "Number of Questions".
                2. Strictly Don't print any other Content or Sentence other than Quize contect.
                3. Strictly give Answer for all Questions.
                4. Strictly remove the escaping characters like "\" included in the response.
                """;
        }
    }
}
