using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbTinTuc
{
    public string MaTinTuc { get; set; } = null!;

    public string TieuDe { get; set; } = null!;

    public DateOnly NgayDang { get; set; }

    public string NoiDung { get; set; } = null!;

    public virtual ICollection<TbCuaHang> MaCuaHangs { get; set; } = new List<TbCuaHang>();
}
