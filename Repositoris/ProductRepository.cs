using Microsoft.EntityFrameworkCore;
using Modelss;
using Repositoris.Base;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositoris
{
    public class ProductRepository:Repositorie<Product>,IProductRepository
    {
        public override ICollection<Product> GetAll()
        {
           return db.Products.Include(p => p.Category).ToList();
        }

        public ICollection<Product> GetByCategory(int CategoryID)
        {
            return db.Products.Where(c => c.CategoryId == CategoryID).ToList();
        }
    }
}
