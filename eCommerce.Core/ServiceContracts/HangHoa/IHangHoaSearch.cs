using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Domain.Entities
{
    public interface IHangHoaSearch
    {
        public List<HangHoa> SearchHangHoaByName(string? query);
    }
}
