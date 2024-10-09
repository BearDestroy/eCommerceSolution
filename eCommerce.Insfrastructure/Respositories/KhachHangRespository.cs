using Core.DTO;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RespositoryConstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Insfrastructure.Respositories
{
    public class KhachHangRespository : IKhachHangRespository
    {
        private readonly ShopQuanAoContext _shopQuanAoContext;
        public KhachHangRespository(ShopQuanAoContext shopQuanAoContext)
        {
            _shopQuanAoContext  = shopQuanAoContext;
        }
        public KhachHang AddKhachHang(KhachHang KhachHang)
        {
            _shopQuanAoContext.KhachHangs.Add(KhachHang);
            _shopQuanAoContext.SaveChanges();
            return KhachHang;
        }

        public KhachHang GetKhachHangById(string id)
        {
            return _shopQuanAoContext.KhachHangs.SingleOrDefault(p => p.MaKh == id);
        }
    }
}
