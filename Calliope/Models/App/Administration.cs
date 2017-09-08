using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calliope.Models.App
{
    public class Administration : User
    {
        public Administration()
        {
           type = "Administration";
        }
    }
}