using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Saison
    {
        public int Id { get; set; }
        [Required]
        public DateTime SeasonStart { get; set; }
        [Required]
        public DateTime SeasonEnd { get; set; }
        public virtual ICollection<Periode> Periodes { get; set; }
    }
}