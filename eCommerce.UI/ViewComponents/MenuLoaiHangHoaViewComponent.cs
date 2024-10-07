using Core.Domain.RespositoryConstract;
using Core.DTO;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class MenuLoaiHangHoaViewComponent : ViewComponent
    {
        private readonly ILoaiHangHoaGetter _loaiHangHoaGetter;
        public MenuLoaiHangHoaViewComponent(ILoaiHangHoaGetter loaiHangHoaGetter)
        {
            _loaiHangHoaGetter = loaiHangHoaGetter;
        }
        public IViewComponentResult Invoke(string viewType)
        {
            var data = _loaiHangHoaGetter.GetLoaiHangHoa().Select(p => new LoaiHangHoaResponse
            {
                MaLoai = p.MaLoai,
                TenLoai = p.TenLoai
            });

            return View(viewType,data);
        } 
    }
}
