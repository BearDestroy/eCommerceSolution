using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.ServiceContracts.Cart
{
    public interface IRemoveFormCart
    {
        void RemoveFromCart(int productId);
    }
}
