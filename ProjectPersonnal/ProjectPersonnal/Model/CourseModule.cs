using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CourseProcessorApi.Models;

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

// Request & Response Models
public class ProcessJsonRequest
{
    public string JsonContent { get; set; }
}

public class FileUploadResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string FileName { get; set; }
}