using eCommerce.Core.Domain.Entities;
using eCommerce.Core.ServiceContracts.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services
{
    public class KhachHangGetterService : IKhachHangGetter
    {
        private readonly IKhachHangGetter _khachHangGetter;
        public KhachHangGetterService(IKhachHangGetter khachHangGetter)
        {
            _khachHangGetter = khachHangGetter;
        }

        public KhachHang GetKhachHangById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }
            return _khachHangGetter.GetKhachHangById(id);
        }
    }
}
