using System;
using System.Collections.Generic;
using System.Text;

namespace Modelss.CustomerSp
{
    public class Edit_forCustomerAddress
    {
        public int Id { get; set; }
        public string Customer_Address { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
