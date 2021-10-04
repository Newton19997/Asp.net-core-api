using Modelss;
using Repositoris.Base;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoris
{
   public class CountryRepository: Repositorie<Country>,ICountryRepository
    {
        public int Insert_Countyr( string CountryName, int commandID)
        {
           return  db.Insert_Countyr( CountryName, commandID);
        }
    }
}
