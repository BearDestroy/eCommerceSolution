using System;
using System.Collections.Generic;

namespace eCommerce.Core.Domain.Entities;

public partial class Tag
{
    public int MaTag { get; set; }

    public string TenTag { get; set; } = null!;

    public virtual ICollection<HangHoa> MaHhs { get; set; } = new List<HangHoa>();
}
