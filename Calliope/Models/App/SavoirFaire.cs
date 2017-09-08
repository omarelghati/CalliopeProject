using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class SavoirFaire
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string nomSavoir { get; set; }
        public virtual ICollection<Etat> Etats { get; set; }
        public virtual Competance Competance { get; set; }
        public virtual ICollection<Note> Notes{ get; set; }
    }
}