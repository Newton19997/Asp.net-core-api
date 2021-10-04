using System;
using System.Collections.Generic;
using System.Text;

namespace Modelss
{
   public class Country
    {
        public Country()
        {
            Customers = new List<Customer>();
        }
        public int Id { get; set; }       
        public string CountryName { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
