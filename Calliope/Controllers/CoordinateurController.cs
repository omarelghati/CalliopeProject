using Calliope.Models.App;
using Calliope.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calliope.ViewModels.Coordinateur;

namespace Calliope.Controllers
{
    public class CoordinateurController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Coordinateur
        public ActionResult Index()
        {
            CoordIndexViewModel cvm = new CoordIndexViewModel();
            var user = (Coordinateur)Session["coordinateur"];
            cvm.Coordinateur = dbContext.Coordinateurs.SingleOrDefault(c => c.Id == user.Id);
            cvm.Periodes = dbContext.Periodes.ToList();
            return View(cvm);
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