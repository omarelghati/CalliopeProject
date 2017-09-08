using Calliope.Models;
using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calliope.Controllers
{
    public class RootController : Controller
    {
        SessionHelper session = new SessionHelper();
        ApplicationDbContext dbContex = new ApplicationDbContext();
        // GET: Root
        public ActionResult Index()
        {
            var user = (Administrateur)Session["administrateur"];
            var root = dbContex.Administrateurs.SingleOrDefault(r => r.Id == user.Id);
            return View(root);
        }
    }
}