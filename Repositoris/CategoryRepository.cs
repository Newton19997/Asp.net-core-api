using DatabaseContext;
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
   public class CategoryRepository: Repositorie<Category>,ICategoryRepository
    {
        //CustomerDbContext db = new CustomerDbContext();
        public override ICollection<Category> GetAll()
        {
            //var cat=db.Categories.ToList();
            //return cat;
            return db.Categories.Include(c=>c.Products).ToList();
        }

        public List<Category> LoadcategorywiseProduct(List<Category> cat)
        {
            foreach (var ca in cat)
            {
                db.Entry(ca).
                    Collection(c => c.Products)
                    .Query()
                    .Where(c=>c.IsActive==true)
                    .Load();  

            }
            return cat;
        }
    }
}
