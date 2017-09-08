using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Periode
    {
        public int Id { get; set; }
        [Required]
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public virtual ICollection<Etat> Etats { get; set; }
        public virtual Saison Saison { get; set; }
    }
}