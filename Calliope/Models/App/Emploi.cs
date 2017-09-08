using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Emploi
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        [Required]
        public virtual Groupe Groupe { get; set; }
        [Required]
        public virtual Saison Saison { get; set; }
        [NotMapped]
        public string SelectedSaison { get; internal set; }
    }
}