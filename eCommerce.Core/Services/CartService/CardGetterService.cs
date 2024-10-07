using eCommerce.Core.Domain.Entities;
using eCommerce.Core.ServiceContracts.Cart;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Services.CartService
{
    public class CartGetterService : ICartGetter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartGetterService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /*public eCommerce.Core.Domain.Entities.Cart GetCart()
        {

            throw new NotImplementedException();
        }*/
    }
}
