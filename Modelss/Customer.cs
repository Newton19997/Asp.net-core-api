using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Modelss
{
    public class Customer
    {
        //public int Id { get; set; }
        //[Required]
        //public string CustomerName { get; set; }
        //public string Address { get; set; }      
        //public string ContactNo { get; set; }
        //public List<Order> Orders { get; set; }



      
            public int Id { get; set; }
            public string CustomerName { get; set; }
            public string FatherName { get; set; }
            public string MotherName { get; set; }
            public int MaritalStatus { get; set; }
            public int? CountryId { get; set; }         
            public Country Country { get; set; }
           public string Image { get; set; }
           public List<CustomerAddress> CustomerAddresss { get; set; }






    }
}
