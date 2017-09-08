using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Enseignant
{
    public class PlannifierEvalViewModel
    {
        public List<Periode> Periodes{ get; set; }
        public List<Etat> Etats { get; set; }
        public List<Calliope.Models.App.Competance> Competances { get; set; }
    }
}