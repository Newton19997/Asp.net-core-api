using Modelss;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoris.Contacts
{
   public interface ICustomerAddressRepository:IRepository<CustomerAddress>
    {
        int EditInsert_CustomerAddresss(Nullable<int> CustomerId, string Customer_Address, Nullable<int> commandID);
        int DeleteCustomerAddresssAfteredit(Nullable<int> CustomerId);
    }
}
