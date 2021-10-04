using BLL_Manager.Base;
using BLL_Manager.Contact;
using Modelss;
using Repositoris.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_Manager
{
    public class CategoryManager:Manager<Category>,ICategoryManager
    {
      private  ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            
        }
    }
}
