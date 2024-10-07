using Core.Domain;
using Core.Services;
using eCommerce.Core.Domain.Entities;
using Ecommerce.Controllers;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UI.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly ShopQuanAoContext _db;
        private readonly ILoaiHangHoaGetter _loaiHangHoaGetterService;
        private readonly IHangHoaGetter _hangHoaGetterService;
        private readonly IHangHoaSearch _hangHoaSearchService;
        public HangHoaController(ShopQuanAoContext db,ILoaiHangHoaGetter loaiHangHoaGetterService, IHangHoaGetter hangHoaGetterService, IHangHoaSearch hangHoaSearchService)
        {
            _db = db;
            _loaiHangHoaGetterService = loaiHangHoaGetterService;
            _hangHoaGetterService = hangHoaGetterService;
            _hangHoaSearchService = hangHoaSearchService;
        }
        public IActionResult Index(int? loai)
        {
            ViewBag.LoaiHangHoa = _loaiHangHoaGetterService.GetLoaiHangHoa();
            List<HangHoa> list = new List<HangHoa>();
            if (loai != null)
            {
                list = _hangHoaGetterService.GetHangHoaByMaLoai(loai);
            }
            else
            {
                list = _hangHoaGetterService.GetAllHangHoa();
            }
            

            return View(list);
        }
        [HttpPost]
        public IActionResult Search(string? searchString)
        {
            
                var lst = _hangHoaSearchService.SearchHangHoaByName(searchString);
            
            return View(lst);
        }

        public IActionResult Detail(int id)
        {
            
            var hanghoa = _hangHoaGetterService.GetHangHoaById(id);
            if(hanghoa == null)
            {
                TempData["Message"] = $"Không thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }
            return View(hanghoa);
        }

    }
}
