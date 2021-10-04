using BLL_Manager.Base;
using BLL_Manager.Contact;
using Modelss;
using Repositoris;
using Repositoris.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager
{
    public class ForeignProductManager : Manager<Product>,IProductManager
    {
        public ForeignProductManager() : base(new ProductRepository())
        {
        }

        public override bool Add(Product product)
        {
            //for poreginproduct  logic
            if (true)
            {


            }
            else
            {
            }
            return base.Add(product);
        }

        public ICollection<Product> GetByCategory(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
