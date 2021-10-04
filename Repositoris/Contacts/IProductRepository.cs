using Modelss;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoris.Contacts
{
   public interface IProductRepository:IRepository<Product>
    {
        ICollection<Product> GetByCategory(int CategoryID);
    }
}
