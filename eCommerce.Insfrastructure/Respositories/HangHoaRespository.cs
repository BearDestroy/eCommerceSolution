using Core.Domain;
using Core.Domain.RespositoryConstract;
using eCommerce.Core.Domain.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respositories
{
    public class HangHoaRespository : IHangHoaRespository
    {
        private readonly ShopQuanAoContext _db;
        public HangHoaRespository(ShopQuanAoContext db) {
            _db = db;
        }

        public List<HangHoa> GetAllHangHoa()
        {
            List<HangHoa> lst = new List<HangHoa>();
            lst = _db.HangHoas.ToList();
            return lst;
        }

        public HangHoaCoHinhAnh? GetHangHoaById(int id)
        {
            var hangHoa = _db.HangHoas
                          .Include(h => h.MaTags) // Nếu cần thêm các liên kết khác
                          .Include(h => h.MaDanhMucs)
                          .SingleOrDefault(h => h.MaHh == id);

            if (hangHoa == null)
            {
                return null; // Nếu không tìm thấy HangHoa, trả về null
            }

            // Lấy danh sách các đường dẫn ảnh liên quan đến HangHoa này
            var images = _db.HinhAnhHangHoas
                .Where(p => p.MaHh == id)
                .Select(p => p.ImagePath)
                .ToList();

            // Gán danh sách ảnh vào thuộc tính ImagePaths của HangHoa (nếu có)
            var hangHoaCoHinhAnh = new HangHoaCoHinhAnh
            {
                HangHoa = hangHoa,      // Gán đối tượng HangHoa
                ImagePath = images      // Gán danh sách các đường dẫn hình ảnh
            };



            return hangHoaCoHinhAnh;
        }

        public List<HangHoa> SearchHangHoaByName(string? query)
        {
            return  _db.HangHoas.Where(p => p.TenHh.Contains(query)).ToList(); ;
        }

        List<HangHoa> IHangHoaRespository.GetHangHoaByMaLoai(int? loai)
        {
            List<HangHoa> lst = new List<HangHoa>();
            if(loai.HasValue)
            {
                lst = _db.HangHoas.Where(p => p.MaLoai == loai).ToList();
            }
            return lst;
        }
    }
}
