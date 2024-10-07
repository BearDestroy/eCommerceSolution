
using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.RespositoryConstract
{
    public interface IHangHoaRespository
    {
        List<HangHoa> GetHangHoaByMaLoai(int? loai);
        HangHoaCoHinhAnh GetHangHoaById(int id);
        List<HangHoa> GetAllHangHoa();

        public List<HangHoa> SearchHangHoaByName(string query);
    }
}
