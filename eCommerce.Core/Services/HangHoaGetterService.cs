
using Core.Domain.RespositoryConstract;
using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class HangHoaGetterService : IHangHoaGetter
    {
        private readonly IHangHoaRespository _hanghoaRespository;
        public HangHoaGetterService(IHangHoaRespository hangHoaRespository)
        {
            _hanghoaRespository = hangHoaRespository;
        }

        public List<HangHoa> GetAllHangHoa()
        {
            return _hanghoaRespository.GetAllHangHoa();
        }

        public HangHoaCoHinhAnh? GetHangHoaById(int id)
        {
            var hangHoa = _hanghoaRespository.GetHangHoaById(id);

            return hangHoa;
        }

        List<HangHoa> IHangHoaGetter.GetHangHoaByMaLoai(int? loai)
        {
            return _hanghoaRespository.GetHangHoaByMaLoai(loai);
        }
    }
}
