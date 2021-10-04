using Modelss.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCoreApp.Models.Order
{
    public class IndexViewModel
    {
        public string OrderNo { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<vwOrderInfo> Orders { get; set; }
    }
}
