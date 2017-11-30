using Calliope.Models.App;
using Calliope.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calliope.ViewModels.Coordinateur;
using System.Data.Entity.Validation;

namespace Calliope.Controllers
{
    public class CoordinateurController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        SessionHelper session = new SessionHelper();
        // GET: Coordinateur
        public ActionResult Index()
        {
            CoordIndexViewModel cvm = new CoordIndexViewModel();
            var user = (Coordinateur)Session["coordinateur"];
            cvm.Coordinateur = dbContext.Coordinateurs.SingleOrDefault(c => c.Id == user.Id);
            cvm.Periodes = dbContext.Periodes.ToList();
            return View(cvm);
        }
        [HttpPost]
        public ActionResult Index(Coordinateur ens)
        {
            var user = (Coordinateur)System.Web.HttpContext.Current.Session["coordinateur"];
            var coordinateur = dbContext.Coordinateurs.SingleOrDefault(e => e.Id == user.Id);
            coordinateur.nomComplet = ens.nomComplet;
            coordinateur.email = ens.email;
            coordinateur.civilite = ens.civilite;
            coordinateur.phone = ens.phone;
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ModelState.AddModelError("error", "Une erreur s'est produite, veuillez vos informations");
            }    
            session.coordinateur = coordinateur;
            CoordIndexViewModel coord = new CoordIndexViewModel();
            coord.Coordinateur = coordinateur;
            coord.Periodes = dbContext.Periodes.ToList();
            return View(coord);
        }

        public ActionResult CreerPeriode()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreerPeriode(Periode p)
        {
            dbContext.Periodes.Add(p);
            dbContext.SaveChanges();
            return View();
        }
        public ActionResult Supprimerperiode(int id)
        {
            var periode = dbContext.Periodes.SingleOrDefault(p => p.Id == id);
            return View(periode);
        }
        [HttpPost]
        public ActionResult Supprimerperiode(Periode p)
        {
            p = dbContext.Periodes.SingleOrDefault(pe => pe.Id == p.Id);
            dbContext.Periodes.Remove(p);
            dbContext.SaveChanges();
            return RedirectToAction("index","coordinateur");
        }
        public ActionResult ModifierPeriode(int id)
        {
            var periode = dbContext.Periodes.SingleOrDefault(pe => pe.Id == id);
            return View(periode);
        }
        [HttpPost]
        public ActionResult ModifierPeriode(Periode periode)
        {
            if(ModelState.IsValid)
            {
                var p = dbContext.Periodes.SingleOrDefault(pe => pe.Id == periode.Id);
                p.start = periode.start;
                p.end = periode.end;
                dbContext.SaveChanges();
                ModelState.AddModelError("success_periode", "Période modifiée");
            }
            else
            {
                ModelState.AddModelError("Erreur_periode", "Veuillez entrer des dates Valides");
            }
            return View(periode);
        }
    }
}