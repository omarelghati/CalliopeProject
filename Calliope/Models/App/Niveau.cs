using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Niveau
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string niveau { get; set; }
        public string cycle { get; set; }
        public  virtual ICollection<Groupe> Groupes { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<Enseignant> Enseignants { get; set; }
    }
}