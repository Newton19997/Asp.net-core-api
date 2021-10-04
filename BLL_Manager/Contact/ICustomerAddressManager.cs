using Modelss;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager.Contact
{
    public interface ICustomerAddressManager: IManager<CustomerAddress>
    {
        int EditInsert_CustomerAddresss(int CustomerId, string Customer_Address, int commandID);
        int DeleteCustomerAddresssAfteredit(Nullable<int> CustomerId);
    }
}
