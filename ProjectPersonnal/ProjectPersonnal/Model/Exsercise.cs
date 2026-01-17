using System.Text.Json.Serialization;
namespace ProjectPersonnal.Model;
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
    public string Solution { get; set; }

    [JsonPropertyName("resources")]
    public List<string> Resources { get; set; }

    [JsonPropertyName("timeEstimate")]
    public int TimeEstimate { get; set; }
}

