
using Core.Domain.RespositoryConstract;

using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class HangHoaSearchService : IHangHoaSearch
    {
        private readonly IHangHoaRespository _hangHoaRespository;
        public HangHoaSearchService(IHangHoaRespository hangHoaRespository) {
            _hangHoaRespository = hangHoaRespository;
        }
        public List<HangHoa> SearchHangHoaByName(string? query)
        {
            if (query != null)
            {
                return _hangHoaRespository.SearchHangHoaByName(query);
            }
            return new List<HangHoa>();
        }
    }
}
