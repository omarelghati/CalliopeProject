using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Administration
{
    public class CreerGroupeViewModel
    {
        public Groupe Groupe { get; set; }
        public List<Niveau> Niveaux { get; set; }
        public int selectedNiveau{ get; set; }
    }
}