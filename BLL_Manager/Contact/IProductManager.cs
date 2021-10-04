using Modelss;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager.Contact
{
   public interface IProductManager:IManager<Product>
    {
        
        ICollection<Product> GetByYear(int year);
        ICollection<Product> GetByCategory(int CategoryID);


    }
}
