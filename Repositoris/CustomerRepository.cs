using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modelss;
using Modelss.CustomerSp;
using Repositoris.Base;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Repositoris
{
   public class CustomerRepository: Repositorie<Customer>,ICustomerRepository
    {
        //CustomerDbContext db = new CustomerDbContext();
        //public override bool Add(Customer customer)
        //{
        //    if (true)
        //    {

        //    }
        //    else
        //    {

        //    }

        //    return base.Add(customer);

        //}
        /*
         public Customer GetById(int id)
         {
             // Customer retriveCustomer = db.Customers.Find(id);
             Customer retriveCustomer = db.Customers.FirstOrDefault(c=>c.Id==id);
             return retriveCustomer;
         }

         public bool Add(Customer customer)
         {

             db.Customers.Add(customer);
             return db.SaveChanges() > 0;

         }

         public bool UpDate(Customer customer)
         {
             db.Entry(customer).State = EntityState.Modified;
             return db.SaveChanges() > 0;
         }
         public bool Remove(int id)
         {
             Customer customer = GetById(id);
             db.Customers.Remove(customer);
             return db.SaveChanges() > 0;
         }
         public List<Customer> GetAll()
         {
             return db.Customers.ToList();
         }
         */
        //public List<Customer> GetByShopId(int shopId)
        //{
        //    List<Customer> customer = db.Customers
        //        .Where(c => c.ShopId == shopId)
        //        .Where(c => c.Address == "Gopalgonj")
        //        .ToList();

        //    return customer;
        //}


        [Obsolete]
        public ICollection<Edit_forCustomer> GetEdit_forCustomer(int id)
        {
            return db.GetEdit_forCustomer(id);
        }

        [Obsolete]
        public ICollection<Edit_forCustomerAddress> GetEdit_forCustomerAddress(int id)
        {
            return db.GetEdit_forCustomerAddress(id);
        }
    }
}
