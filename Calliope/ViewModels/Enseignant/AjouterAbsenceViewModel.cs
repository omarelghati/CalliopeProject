using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Enseignant
{
    public class AjouterAbsenceViewModel
    {
        public Groupe Groupe { get; set; }
        public Absence Absence { get; set; }
        public Discipline Discipline { get; set; }
    }
}