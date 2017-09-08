using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Enseignant
{
    public class IndexViewModel
    {
        public ICollection<Groupe> Groupes { get; set; }
    }
}