using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Modelss;
using Repositoris;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
         CategoryRepository cat = new CategoryRepository();
         var Allcata=cat.GetAll();

         cat.LoadcategorywiseProduct(Allcata);

         if(Allcata != null && Allcata.Any())
         {
             foreach (var item in Allcata)
             {
                 Console.WriteLine("Cetagory name " +item.Name +"Code"+item.Code );
                 if(item.Products != null && item.Products.Any())
                 {
                     Console.WriteLine("product list:");
                     foreach (var prod in item.Products)

                     {
                         Console.WriteLine("product list:" +prod.Name);
                     }
                 }
             }
         }



     for insert
         Product bproduct = new Product()
         {
             Name = "Lg monitor",
             Description = "good tv1",
             Price = 19000
         };
         Product product = new Product()
         {
             Name = "Lg monitordd",
             Description = "good tv",
             Price = 190001
         };

         Category category = new Category()
         {
             Code = "002",
             Name = "Man"
         };
         //if (category.Products == null)
         //{
         //    category.Products = new List<Product>();
         //}

         var categoryId = db.Categories.FirstOrDefault(c => c.Id == 1);

         product.Category = category;

         db.Products.Add(product);
         bool issave = db.SaveChanges() > 0;
         if (issave)
         {
             Console.WriteLine("save Success");
         }
         //category.Products.Add(bproduct);
         //category.Products.Add(product);

         //Console.WriteLine("Category :" + category.Name);
         //foreach (var cateitem in category.Products)

         //{
         //    Console.WriteLine("Product name :" + cateitem.Name);
         //    Console.WriteLine("Product price :" + cateitem.Price);

         //}
        */
        }
    }
}
