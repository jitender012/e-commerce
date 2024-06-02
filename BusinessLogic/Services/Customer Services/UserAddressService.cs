using eShop.Business.Interfaces;
using eShop.Domain;
using eShop.Repository;
using eShop.Repository.Infrastructure.Contract;
using eShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Business.Services.Customer_Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserAddressRepository userAddressRepository;
        public UserAddressService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            userAddressRepository = new UserAddressRepository(unitOfWork);
        }

        public int AddUserAddress(UserAddressDomainModel data)
        {
            if (data != null)
            {
                Address address = new Address()
                {
                    Address1 = data.Address1,
                    City = data.City,
                    State = data.State,
                    CreatedDate = DateTime.Now,
                    Name = data.Name,
                    PhoneNumber = data.PhoneNumber,
                    PinCode = data.PinCode,
                    LandMark = data.LandMark,
                    AddressType = data.AddressType,
                    UserId = data.UserId,
                    AlternatePhoneNumber = data.AlternatePhoneNumber,
                };
                var newAddress= userAddressRepository.Insert(address);               
                return newAddress.Id;
            }
            else
            {
                return 0;
            }
        }

        public bool DeleteUserAddress(int id)
        {            
            var address= userAddressRepository.SingleOrDefault(x => x.Id == id);
            if (address != null)
            {
                userAddressRepository.Delete(x=>x.Id==id);
                return true;
            }
            return false;
        }

        public List<UserAddressDomainModel> GetAllUserAddress(string userId)
        {
            var address = userAddressRepository.GetAll(x => x.UserId == userId).Select(data => new UserAddressDomainModel()
            {
                Id = data.Id,
                Address1 = data.Address1,
                City = data.City,
                State = data.State,
                CreatedDate = DateTime.Now,
                Name = data.Name,
                PhoneNumber = data.PhoneNumber,
                PinCode = data.PinCode,
                LandMark = data.LandMark,
                AddressType = data.AddressType,
                AlternatePhoneNumber = data.AlternatePhoneNumber,
            }).ToList();
            return address;
        }

        public List<UserAddressDomainModel> GetUserAddressById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserAddress(UserAddressDomainModel data)
        {
            throw new NotImplementedException();
        }
    }  
}

