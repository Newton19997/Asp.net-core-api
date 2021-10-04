using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modelss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EFCoreExamples
{
    class CustomerRepository
    {
        CustomerDbContext db = new CustomerDbContext();
        
        public Customer GetById(int id)
        {
            Customer retriveCustomer = db.Customers.Find(id);
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

        public List<Customer> GetByShopId(int shopId)
        {
            List<Customer> customer = db.Customers
                .Where(c => c.ShopId == shopId)
                .Where(c=> c.Address=="Gopalgonj")
                .ToList();

            return customer;
        }

    }
}
