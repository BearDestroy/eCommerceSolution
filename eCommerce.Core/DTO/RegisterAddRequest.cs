using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Core.DTO
{
    public class RegisterAddRequest
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [MaxLength(20,ErrorMessage = "Tên người dùng không quá 20 kí tự")]
        public string MaKh { get; set; } = null!;

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mậu khẩu không được để trống")]
        [MaxLength(32, ErrorMessage = "Mật khẩu không quá 32 kí tự")]
        [DataType(DataType.Password)]
        public string? MatKhau { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [MaxLength(32, ErrorMessage = "Tên người dùng không quá 32 kí tự")]
        public string HoTen { get; set; } = null!;
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; } = true;
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [Display(Name = "Địa chỉ")]
        [MaxLength(60, ErrorMessage = "Địa chỉ không quá 60 kí tự")]
        public string? DiaChi { get; set; }
        [Required(ErrorMessage = "Điện thoại không được để trống")]
        [RegularExpression("^0\\d{9}$",ErrorMessage = "Điện thoại không hợp lệ")]
        [MaxLength(10, ErrorMessage = "Điện thoại không hợp lệ")]
        [Display(Name = "Điện thoại")]
        public string? DienThoai { get; set; }

        /*[RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"),ErrorMessage]*/
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = null!;


    }
}
