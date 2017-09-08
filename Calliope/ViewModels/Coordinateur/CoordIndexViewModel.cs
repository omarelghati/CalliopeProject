using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calliope.Models.App;
namespace Calliope.ViewModels.Coordinateur
{
    public class CoordIndexViewModel
    {
        public Calliope.Models.App.Coordinateur Coordinateur { get; set; }
        public List<Periode> Periodes { get; set; }
    }
}