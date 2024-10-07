using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;

using Core.Domain.RespositoryConstract;
using eCommerce.Core.Domain.Entities;
using Entities;

namespace Infrastructure.Respositories
{
    public class LoaiHangHoaRespository : ILoaiHangHoaRespository
    {
        private readonly ShopQuanAoContext _db;
        public LoaiHangHoaRespository(ShopQuanAoContext db)
        {
            _db = db;
        }

        public List<LoaiHangHoa> GetLoaiHangHoa()
        {
            List<LoaiHangHoa> lst = new List<LoaiHangHoa>();
            lst = _db.LoaiHangHoas.ToList();
            return lst;
        }




    }
}
