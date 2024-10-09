using Core.DTO;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTO;
using eCommerce.Core.Helpers;
using eCommerce.Core.ServiceContracts.KhachHang;
using eCommerce.UI.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eCommerce.UI.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly IKhachHangAdder _khachHangAdder;
        private readonly IKhachHangGetter _khachHangGetter;
        public KhachHangController(IKhachHangAdder khachHangAdder,IKhachHangGetter khachHangGetter)
        {
            _khachHangGetter = khachHangGetter;
            _khachHangAdder = khachHangAdder;
           /* try
            {
                _khachHangAdder = khachHangAdder ?? throw new ArgumentNullException(nameof(khachHangAdder));
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in KhachHangController constructor: {ex}");
                throw;
            }*/
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(RegisterAddRequest model)
        {
            if (ModelState.IsValid) 
            {
                _khachHangAdder.AddKhachHang(model);
                return RedirectToAction("Index","HangHoa");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DangNhap(string? returnUrl)
        {
            ViewBag.CurrentUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginRequest model,string? returnUrl)
        {
            ViewBag.CurrentUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var khachHang = _khachHangGetter.GetKhachHangById(model.Username);
                if(khachHang  == null)
                {
                    ModelState.AddModelError("Loi","Tài khoản hoặc mật khẩu không tồn tại");
                }
                else
                {
                    if (!khachHang.HieuLuc)
                    {
                        ModelState.AddModelError("Loi", "Tài khoản đã bị khóa, vui lòng liên hệ qua Hotline 8384");
                    }
                    else
                    {
                        if(khachHang.MatKhau != model.Password.ToMd5Hash(khachHang.RandomKey))
                        {
                            ModelState.AddModelError("Loi", "Mật khẩu sai vui lòng thử lại");
                        }
                        else
                        {
                            var Claims = new List<Claim>()
                            {
                               new Claim(ClaimTypes.Email,khachHang.Email),
                               new Claim(ClaimTypes.Name,khachHang.HoTen),
                               new Claim("CustomerID",khachHang.MaKh),

                               //Claim role động
                               new Claim(ClaimTypes.Role,"Customer")
                            };

                            var claimsIndentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIndentity);

                            await HttpContext.SignInAsync(claimsPrincipal);

                            if (Url.IsLocalUrl(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return Redirect("/");
                            }
                        }
                    }
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult Profile(string? returnUrl)
        {
            ViewBag.CurrentUrl = returnUrl;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> SignOut(string? returnUrl)
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
