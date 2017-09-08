using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Eleve
    {
        public int Id { get; set; }
        public string nomComplet { get; set; }
        public Groupe Groupe { get; set; }
        public string gender { get; set; }
        public DateTime dateDeNaissance { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }
    }
}