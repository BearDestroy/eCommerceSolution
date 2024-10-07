
using Core.Domain.RespositoryConstract;

using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class LoaiHangHoaGetterService : ILoaiHangHoaGetter
    {
        private readonly ILoaiHangHoaRespository _loaiHangHoaRepository;
        public LoaiHangHoaGetterService(ILoaiHangHoaRespository loaiHangHoaRespository)
        {
            _loaiHangHoaRepository = loaiHangHoaRespository;
        }
        public List<LoaiHangHoa> GetLoaiHangHoa()
        {
            return _loaiHangHoaRepository.GetLoaiHangHoa();
        }

    }
}
