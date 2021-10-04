using BLL_Manager.Base;
using BLL_Manager.Contact;
using Modelss;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager
{
    public class CustomerAddressManager:Manager<CustomerAddress>, ICustomerAddressManager
    {
        ICustomerAddressRepository customerAddressRepository;
        public CustomerAddressManager(ICustomerAddressRepository _customerAddressRepository) : base(_customerAddressRepository)
        {
            customerAddressRepository = _customerAddressRepository;
        }

       public int EditInsert_CustomerAddresss(int CustomerId, string Customer_Address, int commandID)
        {
            return customerAddressRepository.EditInsert_CustomerAddresss(CustomerId, Customer_Address, commandID);
        }
        public int DeleteCustomerAddresssAfteredit(Nullable<int> CustomerId)
        {
            return customerAddressRepository.DeleteCustomerAddresssAfteredit(CustomerId);
        }
    }
}
