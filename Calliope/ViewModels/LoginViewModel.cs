using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calliope.ViewModels
{
    public class LoginViewModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public List<SelectListItem> type;
        public string selectedType { get; set; }
    }
}