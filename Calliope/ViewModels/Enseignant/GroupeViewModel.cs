using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Enseignant
{
    public class GroupeViewModel
    {
        public Groupe Groupe { get; set; }
        public ICollection<Eleve> Eleves { get; set; }
    }
}