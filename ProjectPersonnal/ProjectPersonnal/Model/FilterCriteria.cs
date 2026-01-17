namespace ProjectPersonnal.Model;

// Lớp tiêu chí lọc
public class FilterCriteria
{
    public string JsonContent { get; set; }
    public string Difficulty { get; set; }
    public string Type { get; set; }
    public int? MaxTime { get; set; }
    public string SearchTerm { get; set; }
}
