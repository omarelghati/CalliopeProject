using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calliope.Models.App;
namespace Calliope.ViewModels.Enseignant
{
    public class EvaluationsViewModel
    {
        public List<EvaluationCollective> Evals { get; set; }
        public Groupe Groupes { get; set; }
        public List<Discipline> Disciplines { get; set; }
    }
}