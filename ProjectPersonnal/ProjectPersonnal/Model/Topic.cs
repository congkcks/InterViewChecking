using System.Text.Json.Serialization;

namespace ProjectPersonnal.Model;

public class Topic
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("learningObjectives")]
    public List<string> LearningObjectives { get; set; }
}