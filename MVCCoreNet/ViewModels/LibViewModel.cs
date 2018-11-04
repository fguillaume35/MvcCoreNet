using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCoreNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreNet.ViewModels
{

    public class LibViewModel
    {

        public Lib  Lib { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public string CategorieSelected { get; set; }

        public LibViewModel()
        {
            Categories = new List<SelectListItem>();
        }

        public void SetModel(List<Categorie> liste)
        {
            foreach (var c in liste)
            {
                Categories.Add(new SelectListItem { Value=c.IdCategorie.ToString(), Text=c.Nom });
            }
        }
    }
}
