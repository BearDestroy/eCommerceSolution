using Core.DTO;
using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Domain.RespositoryConstract
{
    public interface IKhachHangRespository
    {
        public KhachHang AddKhachHang(KhachHang registerAddRequest);

        public KhachHang GetKhachHangById(string id);
    }
}
