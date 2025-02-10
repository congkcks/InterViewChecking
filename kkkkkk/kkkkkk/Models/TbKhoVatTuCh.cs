using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbKhoVatTuCh
{
    public string MaCuaHang { get; set; } = null!;

    public string MaVatTu { get; set; } = null!;

    public int SoLuong { get; set; }

    public virtual TbCuaHang MaCuaHangNavigation { get; set; } = null!;

    public virtual TbVatTu MaVatTuNavigation { get; set; } = null!;
}
