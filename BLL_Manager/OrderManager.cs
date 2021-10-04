using BLL_Manager.Base;
using BLL_Manager.Contact;
using Modelss;
using Modelss.ViewModels;
using Modelss.ViewModels.OrderEditModel;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager
{
   public class OrderManager:Manager<Order>,IOrderManager
    {
        private IOrderRepository _repository;
        public OrderManager(IOrderRepository orderRepository):base(orderRepository)
        {
            _repository = orderRepository;
        }
        public ICollection<vwOrderInfo> GetAllOrdersummary()
        {
            return _repository.GetAllOrdersummary();
        }

       

        public ICollection<SpOrderInfo> GetSpOrderInfo()
        {
            return _repository.GetSpOrderInfo();
        }

        public ICollection<SpOrderInfoParamater> GetSpOrderInfos_paramater(string OrderNo, string CustomerName)
        {
            return _repository.GetSpOrderInfos_paramater(OrderNo, CustomerName);
        }

        //for edit
        public ICollection<spOrderID> GetSpOrderID(int id)
        {
            return _repository.GetSpOrderID(id);
        }

        public ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id)
        {
            return _repository.GetSpOrderIDWiseDetails(id);
        }

        public ICollection<OrderDetail> GetByOrderDetailsByID(int OrderDetailsID)
        {
            return _repository.GetByOrderDetailsByID(OrderDetailsID);
        }
        //end  //for edit
    }
}
