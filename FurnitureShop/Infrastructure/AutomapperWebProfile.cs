using AutoMapper;
using eShop.Domain;
using eShop.Repository;
using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Areas.Customer.Data;
using FurnitureShop.Areas.Seller.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Infrastructure
{

    public class AutomapperWebProfile : Profile
    {
       
        public AutomapperWebProfile()
        {         
            CreateMap<CategoryDomainModel, CategoryViewModel>();
            CreateMap<CategoryViewModel, CategoryDomainModel>();

            CreateMap<MainCategoryDomainModel, MainCategoryViewModel>();
            CreateMap<MainCategoryViewModel, MainCategoryDomainModel>();
            
            CreateMap<BrandDomainModel, BrandsViewModel>();
            CreateMap<BrandsViewModel, BrandDomainModel>();

            CreateMap<BannerDomainModel, BannerViewModel>();
            CreateMap<BannerViewModel, BannerDomainModel>();

            CreateMap<ProductDomainModel, ProductViewModel>();
            CreateMap<ProductViewModel, ProductDomainModel>();

            CreateMap<StoreDomainModel, StoreViewModel>();
            CreateMap<StoreViewModel, StoreDomainModel>();

            CreateMap<UserAddressDomainModel, UserAddressViewModel>();
            CreateMap<UserAddressViewModel, UserAddressDomainModel>();

            CreateMap<UserDomainModel, UsersViewModel>();
            CreateMap<UsersViewModel, UserDomainModel>();
         
            CreateMap<ProductImageDomainModel, ProductImageViewModel>();
            CreateMap<ProductImageViewModel, ProductImageDomainModel>();
            //-----------------------------------

            CreateMap<ProductDomainModel, Product>();
            CreateMap< Product, ProductDomainModel>();

            CreateMap<CategoryDomainModel, Category>();
            CreateMap<Category, CategoryDomainModel>();

            CreateMap<MainCategoryDomainModel, MainCategory>();
            CreateMap<MainCategory, MainCategoryDomainModel>();

            CreateMap<BrandDomainModel, Brand>();
            CreateMap<Brand, BrandDomainModel>();

            CreateMap<BannerDomainModel, Banner>();
            CreateMap<Banner, BannerDomainModel>();
         
            CreateMap<StoreDomainModel, Store>();
            CreateMap<Store, StoreDomainModel>();

            CreateMap<UserAddressDomainModel, Address>();
            CreateMap<Address, UserAddressDomainModel>();

            CreateMap<UserDomainModel, AspNetUser>();
            CreateMap<AspNetUser, UserDomainModel>();

            CreateMap<ProductImageDomainModel, ProductImage>();
            CreateMap<ProductImage, ProductImageDomainModel>();
        }    
    }
}