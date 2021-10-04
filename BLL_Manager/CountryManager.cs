using BLL_Manager.Base;
using BLL_Manager.Contact;
using Modelss;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager
{
   public class CountryManager: Manager<Country>,ICountryManager
    {
        ICountryRepository countryRepository;
        public CountryManager(ICountryRepository repository) : base(repository)
        {
            countryRepository = repository;
            //    customerRepository = new CustomerRepository();          

        }
        public int Insert_Countyr(string CountryName, int commandID)
        {
            return countryRepository.Insert_Countyr(CountryName, commandID);
        }
    }
}
