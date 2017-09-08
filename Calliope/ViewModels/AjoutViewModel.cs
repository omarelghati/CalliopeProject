using Calliope.Models;
using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels
{
    public class AjoutViewModel
    {
        public string Niveau { get; set; }
        public string Discipline { get; set; }
        public string Groupe { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<Discipline> CurrentDisciplines { get; set; }
        public Dictionary<Calliope.Models.App.Niveau, List<Calliope.Models.App.Groupe>> Data { get; set; }

    }
}