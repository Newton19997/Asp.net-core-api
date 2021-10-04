using Modelss;
using Modelss.CustomerSp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoris.Contacts
{
   public interface ICustomerRepository:IRepository<Customer>
    {
        ICollection<Edit_forCustomer> GetEdit_forCustomer(int id);
        ICollection<Edit_forCustomerAddress> GetEdit_forCustomerAddress(int id);
    }
}
