using System;
using System.Collections.Generic;

namespace eCommerce.Core.Domain.Entities;

public partial class DanhMuc
{
    public int MaDanhMuc { get; set; }

    public string TenDanhMuc { get; set; } = null!;

    public virtual ICollection<HangHoa> MaHhs { get; set; } = new List<HangHoa>();
}
