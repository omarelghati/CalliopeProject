using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Administration
{
    public class AjouterEleveViewModel
    {
        public Eleve Eleve { get; set; }
        public List<Models.App.Parent> Parents { get; set; }
        public int selectedParent { get; set; }
    }
}