using BLL_Manager.Contact;
using Repositoris.Base;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager.Base
{
    public abstract class Manager<T>:IManager<T> where T:class
    {
      private IRepository<T> repositorie;
        public Manager(IRepository<T> _repositorie)
        {
            repositorie = _repositorie;
        }

        public virtual bool Add(T entity)
        {
            return repositorie.Add(entity);

        }

        public virtual bool UpDate(T entity)
        {
            return repositorie.UpDate(entity);
        }
        public bool Remove(T entity)
        {
            return repositorie.Remove(entity);
        }
        public virtual T GetById(int id)
        {
            return repositorie.GetById(id);
        }
        public virtual ICollection<T> GetAll()
        {
            return repositorie.GetAll();
        }
    }


}
