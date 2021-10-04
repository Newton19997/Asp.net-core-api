using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositoris.Base
{
    public abstract class Repositorie<T>:IRepository<T> where T : class
    {
      protected  CustomerDbContext db;
        public Repositorie()
        {
            db = new CustomerDbContext();
        }
     private DbSet<T> Table
        {
            get
            {
              return db.Set<T>();

            }
         
        }
        public virtual bool Add(T entity)
        {
            //db.Set<T>().Add(entity);
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }
        public virtual bool UpDate(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            // Customer customer = GetById(id);
            //db.Set<T>().Remove(entity);
            Table.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public virtual T GetById(int id)
        {
            return Table.Find(id);
            //Customer retriveCustomer = db.Customers.Find(id);
            //return retriveCustomer;
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }
    }
}
