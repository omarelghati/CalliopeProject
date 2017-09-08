using Calliope.Models.App;
using System;
using Calliope.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calliope.ViewModels.Parent;

namespace Calliope.Controllers
{
    public class ParentController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        SessionHelper session = new SessionHelper();
        // GET: Parent
        public ActionResult Index()
        {
            var user = (Parent)System.Web.HttpContext.Current.Session["parent"];
            var parent = dbContext.Parents.SingleOrDefault(p => p.Id == user.Id);
            List<Eleve> eleves = parent.Eleves.ToList();
            session.eleves = eleves;
            return View(parent);
        }

        [HttpPost]
        public ActionResult Index(Parent par)
        {
            var user = (Parent)System.Web.HttpContext.Current.Session["parent"];
            var parent = dbContext.Parents.SingleOrDefault(e => e.Id == user.Id);
            parent.nomComplet = par.nomComplet;
            parent.email = par.email;
            parent.civilite = par.civilite;
            parent.phone = par.phone;
            dbContext.SaveChanges();
            session.parent = parent;
            return View(parent);
        }
        [Route("Parent/ConsulterNotes/{id}")]
        public ActionResult ConsulterNotes(int id)
        {
            ConsultViewModel vm = new ConsultViewModel();
            vm.Eleve = dbContext.Eleves.SingleOrDefault(e => e.Id == id);
            //var notes  = 
            vm.Notes = vm.Eleve.Notes.ToList();
            return View(vm);
        }
        public ActionResult ConsulterAbsences(int id)
        {
            var eleve = dbContext.Eleves.FirstOrDefault(e => e.Id == id);
            return View(eleve);
        }
    }
}