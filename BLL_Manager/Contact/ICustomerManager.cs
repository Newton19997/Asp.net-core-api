using Modelss;
using Modelss.CustomerSp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager.Contact
{
    public interface ICustomerManager:IManager<Customer>
    {
        ICollection<Edit_forCustomer> GetEdit_forCustomer(int id);
        ICollection<Edit_forCustomerAddress> GetEdit_forCustomerAddress(int id);
      
    }
}
