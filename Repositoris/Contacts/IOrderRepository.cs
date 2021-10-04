using Modelss;
using Modelss.ViewModels;
using Modelss.ViewModels.OrderEditModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoris.Contacts
{
    public interface IOrderRepository:IRepository<Order>
    {
        ICollection<vwOrderInfo> GetAllOrdersummary();
        ICollection<SpOrderInfo> GetSpOrderInfo();
        ICollection<SpOrderInfoParamater> GetSpOrderInfos_paramater(string OrderNo, string CustomerName);
        ICollection<spOrderID> GetSpOrderID(int id);
        ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id);
        ICollection<OrderDetail> GetByOrderDetailsByID(int OrderDetailsID);
    }
}
