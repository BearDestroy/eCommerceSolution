using eCommerce.Core.Domain.Entities;
using eCommerce.UI.Helpers;
using eCommerce.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IHangHoaGetter _hangHoaGetter;
        public CartController(IHangHoaGetter hangHoaGetter)
        {
            _hangHoaGetter = hangHoaGetter;
        }
        public IActionResult Index()
        {
            return View(Cart);
        }
        const string cartId = "MYCART";
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(cartId) ?? new List<CartItem>();
        [HttpPost]
        public IActionResult ThemVaoGioHang(int id, int quantity = 1)
        {
            var gioHang = Cart;
            //Check trong giỏ hàng có hàng hóa đó chưa
            var item = gioHang.SingleOrDefault(p => p.MaHh == id);

            if(item == null)
            {
                var hangHoa = _hangHoaGetter.GetHangHoaById(id);
                if(hangHoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy sản phẩm có mã {id}";
                    return Redirect("/404");
                }
                
                string? img = hangHoa.ImagePath[0].ToString() ?? null;
                item = new CartItem
                {
                    MaHh = hangHoa.HangHoa.MaHh,
                    DonGia = hangHoa.HangHoa.DonGia,
                    TenHh = hangHoa.HangHoa.TenHh,
                    SoLuong = quantity,
                    ThanhTien = quantity * hangHoa.HangHoa.DonGia ?? 0,
                    ImagePath = hangHoa.ImagePath
                };
                gioHang.Add(item);
            }
            else
            {
                item.SoLuong += quantity;
            }
            HttpContext.Session.Set(cartId, gioHang);
            return RedirectToAction("Index");
        }
        public IActionResult RemoveCart(int id)
        {
            var giohang = Cart;
            var item = giohang.SingleOrDefault(p => p.MaHh ==id);
            if(item != null)
            {
                giohang.Remove(item);
                HttpContext.Session.Set(cartId, giohang);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateCart(int id,int quantity)
        {
            var giohang = Cart;
            var item = giohang.SingleOrDefault(p => p.MaHh == id);
            if (item != null)
            {
                item.SoLuong = quantity;
                var ThanhTien = item.ThanhTien;
                // Save the updated cart back into the session
                HttpContext.Session.Set(cartId, giohang);

                // Calculate the subtotal and total for the entire cart
                double subtotal = giohang.Sum(c => c.ThanhTien);
                double total = subtotal; // Modify this if there are additional fees or taxes

                return Json(new
                {
                    itemSubtotal = ThanhTien.ToString(), 
                    cartSubtotal = subtotal.ToString(),
                    cartTotal = total.ToString()
                });
            }
            return RedirectToAction("Index");
        }
    }
}
