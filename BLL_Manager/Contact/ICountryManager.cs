using Modelss;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager.Contact
{
   public interface ICountryManager:IManager<Country>
    {
        int Insert_Countyr(string CountryName, int commandID);
    }
}
