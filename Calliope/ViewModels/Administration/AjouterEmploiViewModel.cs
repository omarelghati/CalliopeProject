using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Administration
{
    public class AjouterEmploiViewModel
    {
        public Emploi Emploi { get; set; }
        public List<Saison> Saisons { get; set; }
        public int SelectedSaison { get; set; }
    }
}