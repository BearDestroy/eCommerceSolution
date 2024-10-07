using System;
using System.Collections.Generic;

namespace eCommerce.Core.Domain.Entities;

public partial class HinhAnhHangHoa
{
    public int ImageId { get; set; }

    public int? MaHh { get; set; }

    public string? ImagePath { get; set; }
}
