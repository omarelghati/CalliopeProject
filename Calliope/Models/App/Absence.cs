using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Absence
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date{ get; set; }
        [Required]
        public virtual Eleve Eleve { get; set; }
        [Required]
        public virtual Enseignant Enseignant { get; set; }
        [Required]
        public virtual Discipline Discipline { get; set; }
    }
}