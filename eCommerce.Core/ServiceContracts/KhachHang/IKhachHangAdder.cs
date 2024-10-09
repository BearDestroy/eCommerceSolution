

using Core.DTO;
using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Domain.Entities
{
    public interface IKhachHangAdder
    {
        public KhachHang AddKhachHang(RegisterAddRequest registerAddRequest);
    }
}
