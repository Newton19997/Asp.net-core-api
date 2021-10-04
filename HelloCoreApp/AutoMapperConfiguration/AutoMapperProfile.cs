//using HelloCoreApp.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloCoreApp.Models.Customer;
//using HelloCoreApp.Models.Order;
//using HelloCoreApp.Models.Order.OrderEditViewModel;

namespace HelloCoreApp.AutoMapperConfiguration
{
    public class AutoMapperProfile: Profile
    {
        
        public AutoMapperProfile()
        {
            //CreateMap<CategoryWiseProductViewModel, Product>();
            //CreateMap<Product, CategoryWiseProductViewModel>();
            //CreateMap<Product, ProductViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<EditCustomerModel, Customer>(); 
            CreateMap<Customer, EditCustomerModel>();
            

            // CreateMap<EditOrderModel, Order>();
            // CreateMap<Order, EditOrderModel>();

            //CreateMap<OrderDetail, EditOrderModel>(); 
            //CreateMap<EditOrderModel, OrderDetail>();

        }
    }
}
