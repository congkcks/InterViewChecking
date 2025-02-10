using System;
using System.Collections.Generic;

namespace ThucHanhTruyVan.Models;

public partial class TNhaXuatBan
{
    public string MaNxb { get; set; } = null!;

    public string? TenNxb { get; set; }

    public virtual ICollection<TSach> TSaches { get; set; } = new List<TSach>();
}
