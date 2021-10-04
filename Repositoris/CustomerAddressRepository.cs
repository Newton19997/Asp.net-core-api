using Modelss;
using Repositoris.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoris.Contacts
{
    public class CustomerAddressRepository : Repositorie<CustomerAddress>, ICustomerAddressRepository
    {
        public int  EditInsert_CustomerAddresss(Nullable<int> CustomerId, string Customer_Address, Nullable<int> commandID)
        {
            return db.EditInsert_CustomerAddresss(CustomerId, Customer_Address, commandID);
        }

        public int DeleteCustomerAddresssAfteredit(Nullable<int> CustomerId)
        {
            return db.DeleteCustomerAddresssAfteredit(CustomerId);
        }
    }
}
