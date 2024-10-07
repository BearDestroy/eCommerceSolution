using eCommerce.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts.Cart
{
    public interface ICartAdder
    {

        void AddToCart(HangHoa product, int quantity);
    }
}
