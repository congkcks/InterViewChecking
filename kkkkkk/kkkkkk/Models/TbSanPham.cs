using System;
using System.Collections.Generic;

namespace kkkkkk.Models;

public partial class TbSanPham
{
    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public decimal? GiaBan { get; set; }

    public string MaNhomSp { get; set; } = null!;

    public decimal? Calo { get; set; }

    public decimal? TongChatBeo { get; set; }

    public decimal? ChatBeoBaoHoa { get; set; }

    public decimal? Cholesterol { get; set; }

    public decimal? Natri { get; set; }

    public decimal? TongCarbohydrate { get; set; }

    public decimal? Duong { get; set; }

    public decimal? Protein { get; set; }

    public string? ThanhPhan { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public string? GhiChu { get; set; }

    public virtual TbNhomSanPham MaNhomSpNavigation { get; set; } = null!;

    public virtual ICollection<TbChiTietHdb> TbChiTietHdbs { get; set; } = new List<TbChiTietHdb>();

    public virtual ICollection<TbCuaHang> MaCuaHangs { get; set; } = new List<TbCuaHang>();
}
