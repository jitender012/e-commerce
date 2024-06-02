using eShop.Business.Interfaces;
using eShop.Domain;
using eShop.Repository;
using eShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace eShop.Business.Services.Customer
{
    public class CartService : ICartService
    {
        private readonly CartRepository _cartRepository;
        public CartService(CartRepository cartRepository)
        {
            _cartRepository =  cartRepository;
        }
        public int AddToCart(UserCartDomainModel data)
        {
            if (data != null)
            {
                UserCart cart = new UserCart()
                {
                    user_id = data.user_id,
                    product_id=data.product_id
                };
                var newCart = _cartRepository.Insert(cart);
                return cart.cart_id;
            }
            else
            {
                return 0;
            }
        }

      

        public List<UserCartDomainModel> GetUserCart(string uId)
        {
            var cart = _cartRepository.GetAll(x => x.user_id == uId).Select(data => new UserCartDomainModel()
            {
                cart_id = data.cart_id,
                user_id = data.user_id,
                product_id = data.product_id
            }).ToList();
            return cart;
        }
       

        public bool RemoveFromCart(UserCartDomainModel cart)
        {
            var result = _cartRepository.SingleOrDefault(x => x.cart_id == cart.cart_id);
            if (result != null)
            {
                _cartRepository.Delete(x => x.cart_id == cart.cart_id);
                return true;
            }
            return false;
        }

    }
}
