using eCommerce.Core.Domain.Entities;
using eCommerce.Core.ServiceContracts.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services.CartService
{
    public class CartAdderService : ICartAdder
    {
        private readonly IHangHoaGetter _hangHoaGetter;
        public CartAdderService(IHangHoaGetter hangHoaGetter)
        {
            _hangHoaGetter = hangHoaGetter;
        }
        public void AddToCart(HangHoa product, int quantity)
        {

            throw new NotImplementedException();
        }
    }
}
