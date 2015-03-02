using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.ViewModels
{
    public class IndexFormView
    {
        public IndexFormView()
        {
            Services=new List<SelectListItem>();
            Locations=new List<SelectListItem>();
        }

        public List<SelectListItem> Services { get; set; } 

        public List<SelectListItem> Locations { get; set; } 
    }
}