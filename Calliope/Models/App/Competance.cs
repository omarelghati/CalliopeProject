using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Competance
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string nomCompetance { get; set; }
        public virtual EvaluationCollective EvaluationCollective { get; set; }
        public virtual ICollection<SavoirFaire> SavoirFaires { get; set; }
        public virtual Discipline Discipline { get; set; }
    }
}
