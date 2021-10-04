using BLL_Manager.Base;
using BLL_Manager.Contact;
using Modelss;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager
{
  public class OrderdetailsManager:Manager<OrderDetail> ,IOrderdetailsManager
    {
        IOrderdetailsRepository orderdetailsRepository;
        public OrderdetailsManager(IOrderdetailsRepository repository) : base(repository)
        {

            orderdetailsRepository = repository;
            //    customerRepository = new CustomerRepository();
        }

    }
}
