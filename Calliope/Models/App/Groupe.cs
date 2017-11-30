using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Groupe
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string nomGroupe { get; set; }
        public virtual Niveau Niveau { get; set; }
        public virtual ICollection<Enseignant> Enseignants { get; set; }
        public virtual ICollection<Eleve> Eleves { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual Emploi Emploi { get; set; }
        public virtual Saison Saison { get; set; }
    }
}