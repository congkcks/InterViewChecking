using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbKichThuoc
{
    public string MaKichThuoc { get; set; } = null!;

    public int GiaThem { get; set; }

    public virtual ICollection<TbChiTietHdb> TbChiTietHdbs { get; set; } = new List<TbChiTietHdb>();
}
