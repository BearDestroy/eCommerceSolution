
using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.RespositoryConstract
{
    public interface ILoaiHangHoaRespository
    {
        public List<LoaiHangHoa> GetLoaiHangHoa();
        
    }
}
