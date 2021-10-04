using Modelss;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoris
{
   public interface IShopRepository:IRepository<Shop>
    {
        //newton for check
        //ICollection<Shop> GetByYear(int year);
    }
}
