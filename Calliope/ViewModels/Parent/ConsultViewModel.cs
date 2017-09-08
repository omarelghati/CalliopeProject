using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.ViewModels.Parent
{
    public class ConsultViewModel
    {
        public Eleve Eleve { get; set; }
        public List<Note> Notes { get; set; }
    }
}