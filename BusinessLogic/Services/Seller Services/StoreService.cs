using eShop.Business.Interfaces;
using eShop.Domain;
using eShop.Repository.Repositories;
using eShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Repository.Infrastructure.Contract;
using System.Reflection;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Web.Helpers;
using AutoMapper;

namespace eShop.Business.Services.Seller_Service
{
    public class StoreService : IStoreService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly StoreRepository storeRepository;
   
        public StoreService(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            unitOfWork = _unitOfWork;
            storeRepository = new StoreRepository(unitOfWork);
        }
        public int AddStore(StoreDomainModel data)
        {
            var store = mapper.Map<Store>(data);
            var result = storeRepository.Insert(store);
            return result.store_id;
        }

        public bool DeleteStore(int id)
        {
            var Store = storeRepository.SingleOrDefault(x => x.store_id == id);
            storeRepository.Delete(x => x.store_id == id);
            return true;
        }

        public List<StoreDomainModel> GetAllStores(string sellerId = null)
        {
            var StoreList = (sellerId==null)
                ? storeRepository.GetAll() 
                : storeRepository.GetAll(s=>s.user_id==sellerId);
            var StoreListDM = mapper.Map<List<StoreDomainModel>>(StoreList);
            return StoreListDM;
        }

        public StoreDomainModel GetStoreById(int? id)
        {
            var store = storeRepository.SingleOrDefault(c => c.store_id == id);
            var storeDM = mapper.Map<StoreDomainModel>(store);
            return storeDM;
        }

        public bool UpdateStore(StoreDomainModel data)
        {
            var result = storeRepository.SingleOrDefault(x => x.store_id == data.store_id);
            if (result != null)
            {
                var store = mapper.Map<Store>(data);
                storeRepository.Update(store);
            }
            return true;
        }
    }
}
