using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Parent : User
    {
        public virtual ICollection<Eleve> Eleves { get; set; }
    }
}