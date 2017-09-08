using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Administration
{
    public class AffecterEleveViewModel
    {
        public List<Eleve> Eleves { get; set; }
        public int selectedEleve { get; set; }
    }
}