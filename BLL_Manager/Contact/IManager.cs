using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager.Contact
{
    public interface IManager<T>where T:class
    {
        bool Add(T entity);
        bool UpDate(T entity);
        bool Remove(T entity);
        T GetById(int id);
        ICollection<T> GetAll();
    }
}
