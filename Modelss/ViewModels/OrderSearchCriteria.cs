using System;
using System.Collections.Generic;
using System.Text;

namespace Modelss.ViewModels
{
   public class OrderSearchCriteria
    {
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime FromOrderDate { get; set; }
        public DateTime ToOrderDate { get; set; }
    }
}
