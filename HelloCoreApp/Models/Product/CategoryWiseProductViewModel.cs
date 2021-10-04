using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCoreApp.Models.Product
{
    public class CategoryWiseProductViewModel
    {
        public ICollection<SelectListItem> CategoryList { get; set; }
    }
}
