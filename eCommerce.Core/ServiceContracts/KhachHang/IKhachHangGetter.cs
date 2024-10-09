using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts.KhachHang
{
    public interface IKhachHangGetter
    {
        public eCommerce.Core.Domain.Entities.KhachHang GetKhachHangById(string id);
    }
}
