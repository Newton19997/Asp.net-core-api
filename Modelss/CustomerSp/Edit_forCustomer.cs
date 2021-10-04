using System;
using System.Collections.Generic;
using System.Text;

namespace Modelss.CustomerSp
{
    public class Edit_forCustomer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int MaritalStatus { get; set; }
        public string Image { get; set; }
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
