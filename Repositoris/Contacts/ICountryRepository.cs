using Modelss;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoris.Contacts
{
  public interface ICountryRepository:IRepository<Country>
    {
        int Insert_Countyr(string CountryName, int commandID);
    }
}
