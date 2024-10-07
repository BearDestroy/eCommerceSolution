using System;
using System.Collections.Generic;

namespace eCommerce.Core.Domain.Entities;

public partial class LoaiHangHoa
{
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public string? TenLoaiAlias { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<HangHoa> MaHhs { get; set; } = new List<HangHoa>();
}
