using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Domain;
using eShop.Repository;
using eShop.Repository.Infrastructure.Contract;
using eShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace eShop.Business.Services.Seller_Service
{

    public class StockSrvices : IStockService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly StoreRepository storeRepository;
        private readonly StockRepository stockRepository;
        public StockSrvices(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            unitOfWork = _unitOfWork;
            storeRepository = new StoreRepository(unitOfWork);
            stockRepository = new StockRepository(unitOfWork);
        }

        public int AddStock(StockDomainModel data)
        {
            stockRepository.Insert(mapper.Map<Stock>(data));
            return 1;
        }
        public StockDomainModel GetStock(int pId)
        {            
            return mapper.Map<StockDomainModel>(stockRepository.SingleOrDefault(x => x.product_id == pId));
        }

        public List<StockDomainModel> GetStocks(int storeId = 0)
        {
            
            return mapper.Map<List<StockDomainModel>>(stockRepository.GetAll(x => x.store_id == storeId));
        }

        public bool UpdateStock(Stock stock)
        {                
            stockRepository.Update(stock);
            return true;
        }
    }
}