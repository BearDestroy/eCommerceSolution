using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Core.Domain.Entities;

namespace eCommerce.Core.Domain.Entities
{
    public interface IHangHoaGetter
    {
        public List<HangHoa> GetHangHoaByMaLoai(int? loai);
        List<HangHoa> GetAllHangHoa();

        HangHoaCoHinhAnh GetHangHoaById(int id);
    }
}
