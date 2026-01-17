using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CourseProcessorApi.Models;
using Microsoft.AspNetCore.Http;

namespace CourseProcessorApi.Services;

public interface ICourseService
{
    Task<CourseData> ProcessJsonContentAsync(string jsonContent);
    Task<CourseData> ProcessJsonFileAsync(IFormFile file);
    Task<string> ExportCourseToTextAsync(CourseData courseData);
    Task<string> ExportCourseToJsonAsync(CourseData courseData);
    List<QuizQuestion> ExtractQuizQuestions(CourseData courseData);
}

public class CourseService : ICourseService
{
    private readonly JsonSerializerOptions _jsonOptions;

    public CourseService()
    {
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // To handle Vietnamese characters
        };
    }

    public async Task<CourseData> ProcessJsonContentAsync(string jsonContent)
    {
        try
        {
            // Deserialize the outer structure that contains the "output" property
            var rawItems = JsonSerializer.Deserialize<List<RawInput>>(jsonContent, _jsonOptions);

            if (rawItems == null || rawItems.Count == 0 || string.IsNullOrEmpty(rawItems[0].Output))
            {
                throw new Exception("Cấu trúc JSON không hợp lệ hoặc không có dữ liệu");
            }

            // Extract the JSON string from the "output" property
            string courseJson = rawItems[0].Output.Trim();

            // Remove the ```json and ``` markers if they exist
            if (courseJson.StartsWith("```json"))
            {
                courseJson = courseJson.Substring("```json".Length);
            }
            if (courseJson.EndsWith("```"))
            {
                courseJson = courseJson.Substring(0, courseJson.Length - "```".Length);
            }

            // Deserialize the inner JSON string to get the CourseData
            var courseData = JsonSerializer.Deserialize<CourseData>(courseJson, _jsonOptions);

            return courseData;
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi xử lý JSON: {ex.Message}");
        }
    }

    public async Task<CourseData> ProcessJsonFileAsync(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("Không có file hoặc file rỗng");
            }

            using var streamReader = new StreamReader(file.OpenReadStream(), Encoding.UTF8);
            var jsonContent = await streamReader.ReadToEndAsync();

            return await ProcessJsonContentAsync(jsonContent);
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi xử lý file: {ex.Message}");
        }
    }

    public async Task<string> ExportCourseToTextAsync(CourseData courseData)
    {
        if (courseData == null)
        {
            throw new Exception("Không có dữ liệu khóa học để xuất");
        }

        using var memoryStream = new MemoryStream();
        using var writer = new StreamWriter(memoryStream, Encoding.UTF8);

        await writer.WriteLineAsync($"=== KHÓA HỌC: {courseData.Topic.Name} ===");
        await writer.WriteLineAsync($"Mô tả: {courseData.Topic.Description}");

        await writer.WriteLineAsync("\nMục tiêu học tập:");
        foreach (var objective in courseData.Topic.LearningObjectives)
        {
            await writer.WriteLineAsync($"- {objective}");
        }

        await writer.WriteLineAsync("\nĐiều kiện tiên quyết:");
        foreach (var prerequisite in courseData.Prerequisites)
        {
            await writer.WriteLineAsync($"- {prerequisite}");
        }

        await writer.WriteLineAsync("\nDanh sách bài tập:");
        foreach (var exercise in courseData.Exercises)
        {
            await writer.WriteLineAsync($"\n{exercise.Id}: {exercise.Title}");
            await writer.WriteLineAsync($"Loại: {exercise.Type}, Độ khó: {exercise.Difficulty}");
            await writer.WriteLineAsync($"Mô tả: {exercise.Description}");
            await writer.WriteLineAsync($"Thời gian ước tính: {exercise.TimeEstimate} phút");

            if (exercise.Hints != null && exercise.Hints.Count > 0)
            {
                await writer.WriteLineAsync("\nGợi ý:");
                foreach (var hint in exercise.Hints)
                {
                    await writer.WriteLineAsync($"- {hint}");
                }
            }

            if (exercise.Resources != null && exercise.Resources.Count > 0)
            {
                await writer.WriteLineAsync("\nTài nguyên:");
                foreach (var resource in exercise.Resources)
                {
                    await writer.WriteLineAsync($"- {resource}");
                }
            }
        }

        if (courseData.AssessmentCriteria != null && courseData.AssessmentCriteria.Count > 0)
        {
            await writer.WriteLineAsync("\nTiêu chí đánh giá:");
            foreach (var criterion in courseData.AssessmentCriteria)
            {
                await writer.WriteLineAsync($"- {criterion}");
            }
        }

        var quizQuestions = ExtractQuizQuestions(courseData);
        if (quizQuestions.Count > 0)
        {
            await writer.WriteLineAsync("\nCâu hỏi trắc nghiệm:");
            for (int i = 0; i < quizQuestions.Count; i++)
            {
                var question = quizQuestions[i];
                await writer.WriteLineAsync($"\nCâu hỏi {i + 1}: {question.Question}");
                for (int j = 0; j < question.Options.Count; j++)
                {
                    await writer.WriteLineAsync($"  {(char)('A' + j)}. {question.Options[j]}");
                }
                await writer.WriteLineAsync($"  Đáp án đúng: {question.Answer}");
            }
        }

        await writer.FlushAsync();
        memoryStream.Position = 0;
        using var reader = new StreamReader(memoryStream, Encoding.UTF8);
        return await reader.ReadToEndAsync();
    }

    public async Task<string> ExportCourseToJsonAsync(CourseData courseData)
    {
        if (courseData == null)
        {
            throw new Exception("Không có dữ liệu khóa học để xuất");
        }

        return JsonSerializer.Serialize(courseData, _jsonOptions);
    }

    public List<QuizQuestion> ExtractQuizQuestions(CourseData courseData)
    {
        var quizQuestions = new List<QuizQuestion>();

        if (courseData == null || courseData.Exercises == null)
        {
            return quizQuestions;
        }

        foreach (var exercise in courseData.Exercises)
        {
            if (exercise.Type == "quiz" && exercise.Solution is JsonElement jsonElement)
            {
                try
                {
                    if (jsonElement.ValueKind == JsonValueKind.Array)
                    {
                        var questions = JsonSerializer.Deserialize<List<QuizQuestion>>(jsonElement.GetRawText(), _jsonOptions);
                        if (questions != null)
                        {
                            quizQuestions.AddRange(questions);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi trích xuất câu hỏi quiz: {ex.Message}");
                }
            }
        }

        return quizQuestions;
    }
}
