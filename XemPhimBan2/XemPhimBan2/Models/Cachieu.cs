

namespace XemPhimBan2.Models;

public partial class Cachieu
{
    public int MaCa { get; set; }

    public string? TenCa { get; set; }

    public TimeOnly? GioBatDau { get; set; }

    public TimeOnly? GioKetThuc { get; set; }

    public virtual ICollection<Suatchieu> Suatchieus { get; set; } = new List<Suatchieu>();
}
