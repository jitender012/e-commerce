using eShop.Business.Interfaces;
using eShop.Business.Services.Admin_Services;
using eShop.Business.Services.Customer;
using eShop.Business.Services.Customer_Services;
using eShop.Business.Services.Seller_Service;
using eShop.Repository;
using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;
using FurnitureShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using FurnitureShop.Controllers;
using Unity.Injection;
using AutoMapper;
using FurnitureShop.Areas.Administration.Controllers;
using System;
using eShop.Domain;
using FurnitureShop.Areas.Administration.Data;
using eShop.Repository.Interfaces;
using FurnitureShop.Areas.Customer.Controllers;
using FurnitureShop.Infrastructure;
using eShop.Business.Services.Seller_Services;

namespace FurnitureShop
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutomapperWebProfile>();
            });          

            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<IMainCategoryService, MainCategoryService>();     
            container.RegisterType<ICategoryService, CategoryService>();            
            container.RegisterType<IStoreService, StoreService>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<IUserAddressService, UserAddressService>();
            container.RegisterType<IProductImageService,ProductImageService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();          

            container.RegisterInstance<IMapper>(config.CreateMapper());

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            

        }

       
    }
}