using Microsoft.EntityFrameworkCore;
using Modelss;
using Modelss.ViewModels;
using Modelss.ViewModels.OrderEditModel;
using Repositoris.Base;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Repositoris
{
   public class OrderRepository: Repositorie<Order>,IOrderRepository
    {

        public ICollection<vwOrderInfo> GetAllOrdersummary()
        {
            return db.vwOrderInfos.ToList();
        }

        public ICollection<OrderDetail> GetByOrderDetailsByID(int OrderDetailsID)
        {
            return db.OrderDetails.Where(m=>m.Id==OrderDetailsID).ToList();
        }

        public ICollection<spOrderID> GetSpOrderID(int id)
        {
            return db.GetSpOrderID(id);
        }

        public ICollection<spOrderIDWiseDetails> GetSpOrderIDWiseDetails(int id)
        {
            return db.GetSpOrderIDWiseDetails(id);
        }

        //// OrderSearchCriteria this model create in 50 vodeo
        //public IEnumerable<vwOrderInfo> GetOrderCriteria(OrderSearchCriteria criteria)
        //{
        //    var orders = db.Orders.Include(c => c.OrderDetails);
        //    if(criteria== null)
        //    {
        //        return orders.Select(c=>_ma)
        //    }
        //    if (!string.IsNullOrEmpty(criteria.CustomerName))
        //    {

        //    }
        //}

        public ICollection<SpOrderInfo> GetSpOrderInfo()
        {
            return db.GetSpOrderInfos();
        }

        public ICollection<SpOrderInfoParamater> GetSpOrderInfos_paramater(string OrderNo, string CustomerName)
        {
            return db.GetSpOrderInfos_paramater(OrderNo, CustomerName);
        }

    }
}
