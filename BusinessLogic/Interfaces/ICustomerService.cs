using eShop.Domain;
using eShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Business.Interfaces
{
    public interface ICartService
    {
        List<UserCartDomainModel> GetUserCart(string uId);
        int AddToCart(UserCartDomainModel cart);
        bool RemoveFromCart(UserCartDomainModel cart);
        
    }
    public interface IUserAddressService
    {
        List<UserAddressDomainModel> GetAllUserAddress(string userId);        
        List<UserAddressDomainModel> GetUserAddressById(int? id);
        int AddUserAddress(UserAddressDomainModel data);
        bool UpdateUserAddress(UserAddressDomainModel data);
        bool DeleteUserAddress(int id);
    }
}
