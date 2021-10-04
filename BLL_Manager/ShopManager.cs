using BLL_Manager.Base;
using BLL_Manager.Contact;
using Modelss;
using Repositoris;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager
{
    public class ShopManager : Manager<Shop>, IShopManager
    {
        public ShopManager(IShopRepository repository):base(repository)
        { 
        }
    }
}
