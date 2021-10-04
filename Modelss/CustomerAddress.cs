using System;
using System.Collections.Generic;
using System.Text;

namespace Modelss
{
   public class CustomerAddress
    {

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Customer_Address { get; set; }
       
    }
}
