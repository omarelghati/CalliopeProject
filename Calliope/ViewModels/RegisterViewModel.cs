using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calliope.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string nomComplet { get; set; }
        [Required]
        public string email { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        public string phone { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public List<SelectListItem> civilite;
        [Required]
        public string selectedCivility { get; set; }
        public List<SelectListItem> type;
        [Required]
        public string selectedType { get; set; }
    }
}