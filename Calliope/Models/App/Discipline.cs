using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Calliope.Models.App
{
    public class Discipline
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string nomDiscipline { get; set; }
        public virtual ICollection<Enseignant>  Enseignants { get; set; }
        public virtual ICollection<Competance> Competances { get; set; }
        public virtual ICollection<Groupe> Groupes { get; set; }
        public virtual Niveau Niveau{ get; set; }
    }

}