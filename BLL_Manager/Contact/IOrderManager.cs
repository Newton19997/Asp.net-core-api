using Modelss;
using Modelss.ViewModels;
using Modelss.ViewModels.OrderEditModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager.Contact
{
   public interface IOrderManager:IManager<Order>
    {
      public  ICollection<vwOrderInfo> GetAllOrdersummary();
        public ICollection<SpOrderInfo> GetSpOrderInfo();
        ICollection<SpOrderInfoParamater> GetSpOrderInfos_paramater(string OrderNo, string CustomerName);
        //for edit
        ICollection<spOrderID> GetSpOrderID(int id);
        ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id);

        ICollection<OrderDetail> GetByOrderDetailsByID(int OrderDetailsID);
    }
}
