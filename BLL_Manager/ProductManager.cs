using BLL_Manager.Contact;
using Modelss;
using Repositoris;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager.Base
{
   public class ProductManager:Manager<Product>, IProductManager
    {
        IProductRepository productRepository;
        public ProductManager(IProductRepository repository) : base(repository)
        {

            productRepository = repository;
            //    customerRepository = new CustomerRepository();
        }

        public ICollection<Product> GetByCategory(int CategoryID)
        {
            return productRepository.GetByCategory(CategoryID);


        }

        public ICollection<Product> GetByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
