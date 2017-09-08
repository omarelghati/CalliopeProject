using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class EvalutiationIndiv
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string titre { get; set; }
        [StringLength(255)]
        public string domaine { get; set; }
        public DateTime date { get; set; }
        public virtual Enseignant Enseignant { get; set; }
        public virtual Eleve Eleve { get; set; }
    }
}