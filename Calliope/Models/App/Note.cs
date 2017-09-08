using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public int note { get; set; }
        [Required]
        public virtual Eleve Eleve { get; set; }
        [Required]
        public virtual SavoirFaire SavoirFaire { get; set; }
    }
}