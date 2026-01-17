using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

// Classes to model the JSON structure
public class CourseData
{
    [JsonPropertyName("topic")]
    public Topic Topic { get; set; }

    [JsonPropertyName("prerequisites")]
    public List<string> Prerequisites { get; set; }

    [JsonPropertyName("exercises")]
    public List<Exercise> Exercises { get; set; }

    [JsonPropertyName("assessmentCriteria")]
    public List<string> AssessmentCriteria { get; set; }
}

public class Topic
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("learningObjectives")]
    public List<string> LearningObjectives { get; set; }
}

public class Exercise
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("difficulty")]
    public string Difficulty { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("hints")]
    public List<string> Hints { get; set; }

    [JsonPropertyName("solution")]
    public object Solution { get; set; }

    [JsonPropertyName("resources")]
    public List<string> Resources { get; set; }

    [JsonPropertyName("timeEstimate")]
    public int TimeEstimate { get; set; }
}

public class QuizQuestion
{
    [JsonPropertyName("question")]
    public string Question { get; set; }

    [JsonPropertyName("options")]
    public List<string> Options { get; set; }

    [JsonPropertyName("answer")]
    public string Answer { get; set; }
}

// Class to model the top-level JSON structure that contains an "output" property with a JSON string
public class RawInput
{
    [JsonPropertyName("output")]
    public string Output { get; set; }
}

public class JavaScriptCourseProcessor
{
    // Method to parse the JSON file and return the course data
    public static CourseData ProcessCourseJson(string filePath)
    {
        try
        {
            // Read the file content with UTF-8 encoding to support Vietnamese
            string jsonContent = File.ReadAllText(filePath, Encoding.UTF8);

            // Deserialize the outer structure that contains the "output" property
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // To handle Vietnamese characters
            };

            var rawItems = JsonSerializer.Deserialize<List<RawInput>>(jsonContent, options);

            if (rawItems == null || rawItems.Count == 0 || string.IsNullOrEmpty(rawItems[0].Output))
            {
                throw new Exception("Invalid JSON structure or empty output");
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

            // Deserialize the inner JSON string to get the CourseData with Vietnamese support
            var courseData = JsonSerializer.Deserialize<CourseData>(courseJson, options);

            return courseData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi xử lý JSON: {ex.Message}");
            return null;
        }
    }

    // Method to display the course information
    public static void DisplayCourseInfo(CourseData courseData)
    {
        if (courseData == null)
        {
            Console.WriteLine("Không có dữ liệu khóa học.");
            return;
        }

        Console.WriteLine($"=== KHÓA HỌC: {courseData.Topic.Name} ===");
        Console.WriteLine($"Mô tả: {courseData.Topic.Description}");

        Console.WriteLine("\nMục tiêu học tập:");
        foreach (var objective in courseData.Topic.LearningObjectives)
        {
            Console.WriteLine($"- {objective}");
        }

        Console.WriteLine("\nĐiều kiện tiên quyết:");
        foreach (var prerequisite in courseData.Prerequisites)
        {
            Console.WriteLine($"- {prerequisite}");
        }

        Console.WriteLine("\nDanh sách bài tập:");
        foreach (var exercise in courseData.Exercises)
        {
            Console.WriteLine($"\n{exercise.Id}: {exercise.Title}");
            Console.WriteLine($"Loại: {exercise.Type}, Độ khó: {exercise.Difficulty}");
            Console.WriteLine($"Mô tả: {exercise.Description}");
            Console.WriteLine($"Thời gian ước tính: {exercise.TimeEstimate} phút");
        }

        Console.WriteLine("\nTiêu chí đánh giá:");
        foreach (var criterion in courseData.AssessmentCriteria)
        {
            Console.WriteLine($"- {criterion}");
        }

        var quizQuestions = ExtractQuizQuestions(courseData);
        Console.WriteLine($"\nĐã trích xuất {quizQuestions.Count} câu hỏi trắc nghiệm.");
    }

    // Method to extract quiz questions from exercises
    public static List<QuizQuestion> ExtractQuizQuestions(CourseData courseData)
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
                        var questions = JsonSerializer.Deserialize<List<QuizQuestion>>(jsonElement.GetRawText());
                        if (questions != null)
                        {
                            quizQuestions.AddRange(questions);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error extracting quiz questions: {ex.Message}");
                }
            }
        }

        return quizQuestions;
    }

    // Method to export course data to a file
    public static void ExportCourseData(CourseData courseData, string outputFilePath)
    {
        try
        {
            if (courseData == null)
            {
                Console.WriteLine("Không có dữ liệu khóa học để xuất.");
                return;
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine($"=== KHÓA HỌC: {courseData.Topic.Name} ===");
                writer.WriteLine($"Mô tả: {courseData.Topic.Description}");

                writer.WriteLine("\nMục tiêu học tập:");
                foreach (var objective in courseData.Topic.LearningObjectives)
                {
                    writer.WriteLine($"- {objective}");
                }

                writer.WriteLine("\nĐiều kiện tiên quyết:");
                foreach (var prerequisite in courseData.Prerequisites)
                {
                    writer.WriteLine($"- {prerequisite}");
                }

                writer.WriteLine("\nDanh sách bài tập:");
                foreach (var exercise in courseData.Exercises)
                {
                    writer.WriteLine($"\n{exercise.Id}: {exercise.Title}");
                    writer.WriteLine($"Loại: {exercise.Type}, Độ khó: {exercise.Difficulty}");
                    writer.WriteLine($"Mô tả: {exercise.Description}");
                    writer.WriteLine($"Thời gian ước tính: {exercise.TimeEstimate} phút");

                    if (exercise.Hints != null && exercise.Hints.Count > 0)
                    {
                        writer.WriteLine("\nGợi ý:");
                        foreach (var hint in exercise.Hints)
                        {
                            writer.WriteLine($"- {hint}");
                        }
                    }

                    if (exercise.Resources != null && exercise.Resources.Count > 0)
                    {
                        writer.WriteLine("\nTài nguyên:");
                        foreach (var resource in exercise.Resources)
                        {
                            writer.WriteLine($"- {resource}");
                        }
                    }
                }

                if (courseData.AssessmentCriteria != null && courseData.AssessmentCriteria.Count > 0)
                {
                    writer.WriteLine("\nTiêu chí đánh giá:");
                    foreach (var criterion in courseData.AssessmentCriteria)
                    {
                        writer.WriteLine($"- {criterion}");
                    }
                }

                var quizQuestions = ExtractQuizQuestions(courseData);
                if (quizQuestions.Count > 0)
                {
                    writer.WriteLine("\nCâu hỏi trắc nghiệm:");
                    for (int i = 0; i < quizQuestions.Count; i++)
                    {
                        var question = quizQuestions[i];
                        writer.WriteLine($"\nCâu hỏi {i + 1}: {question.Question}");
                        for (int j = 0; j < question.Options.Count; j++)
                        {
                            writer.WriteLine($"  {(char)('A' + j)}. {question.Options[j]}");
                        }
                        writer.WriteLine($"  Đáp án đúng: {question.Answer}");
                    }
                }
            }

            Console.WriteLine($"Đã xuất dữ liệu khóa học thành công vào file: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi xuất dữ liệu: {ex.Message}");
        }
    }

    // Method to export course data to JSON format
    public static void ExportCourseToJson(CourseData courseData, string outputFilePath)
    {
        try
        {
            if (courseData == null)
            {
                Console.WriteLine("Không có dữ liệu khóa học để xuất.");
                return;
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string jsonString = JsonSerializer.Serialize(courseData, options);
            File.WriteAllText(outputFilePath, jsonString, Encoding.UTF8);

            Console.WriteLine($"Đã xuất dữ liệu khóa học sang định dạng JSON thành công vào file: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi xuất dữ liệu sang JSON: {ex.Message}");
        }
    }

    // Main method example
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // Đặt encoding cho console để hiển thị tiếng Việt

        string inputFilePath = "C:\\Users\\ACER\\source\\repos\\OK\\TextFile1.txt";  // Đường dẫn đến file JSON
        string outputTextFilePath = "C:\\Users\\ACER\\source\\repos\\OK\\TextFile2.txt"; // Đường dẫn đến file text kết quả
        string outputJsonFilePath = "C:\\Users\\ACER\\source\\repos\\OK\\TextFil3Json.json"; // Đường dẫn đến file JSON kết quả

        var courseData = ProcessCourseJson(inputFilePath);
        if (courseData != null)
        {
            // Hiển thị thông tin khóa học trong console
            DisplayCourseInfo(courseData);

            // Xuất dữ liệu khóa học sang file text
            ExportCourseData(courseData, outputTextFilePath);

            // Xuất dữ liệu khóa học sang file JSON
            ExportCourseToJson(courseData, outputJsonFilePath);
        }
    }
}