
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Domain.Entities
{
    public interface ILoaiHangHoaGetter
    {
        List<LoaiHangHoa> GetLoaiHangHoa();
    }
}
