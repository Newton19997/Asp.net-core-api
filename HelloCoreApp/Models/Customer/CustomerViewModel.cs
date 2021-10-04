using Microsoft.AspNetCore.Mvc.Rendering;
using Modelss;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCoreApp.Models.Customer
{
    public class CustomerViewModel
    {
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        [Display(Name = "Marital Status")]
        public int MaritalStatus { get; set; }
       
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        public string Image { get; set; }
        public List<SelectListItem> Countrys { get; set; }
        public List<CustomerAddress> CustomerAddresss { get; set; }



    }
}
