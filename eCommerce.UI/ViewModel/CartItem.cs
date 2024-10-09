using eCommerce.Core.Domain.Entities;

namespace eCommerce.UI.ViewModel
{
    public class CartItem
    {
        public int MaHh { get; set; }
        public List<string> ImagePath { get; set; } = new List<string>();
        public string TenHh { get; set; } = null!;
        public double? DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get
            {
                return SoLuong * DonGia ?? 0;
            }
            set
            {

            }
        }


    }
}
