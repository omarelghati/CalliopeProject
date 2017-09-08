using Calliope.Models;
using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Enseignant
{
    public class EnseignantViewModel
    {
        public GroupeViewModel groupeview = new GroupeViewModel();
        public IndexViewModel indexview = new IndexViewModel();
        public ICollection<EvaluationCollective> evalC { get; set; }
        public ICollection<EvaluationCollective> evalI { get; set; }
    }
}