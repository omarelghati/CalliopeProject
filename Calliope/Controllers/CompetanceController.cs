using Calliope.Models;
using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Calliope.Controllers
{
    public class CompetanceController : Controller
    {

        SessionHelper session = new SessionHelper();
        private ApplicationDbContext _dbContext;

        public CompetanceController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }
         [Route("Competance/AjouterSavoir/{compId}")]
        public ActionResult AjouterSavoir(int compId)
        {
            ViewBag.Competance = _dbContext.Competances.SingleOrDefault(c => c.Id == compId);
            //var competances = _dbContext.Disciplines.FirstOrDefault(c => c.Id == discId).Competances.ToList();
            //session.competances = competances;
            return View();
        }
        [HttpPost]
        [Route("Competance/AjouterSavoir/{compId}")]
        public ActionResult AjouterSavoir(SavoirFaire savoir , int compId)
        {
            ViewBag.Competance = _dbContext.Competances.SingleOrDefault(c => c.Id == compId);
            var competance = _dbContext.Competances.SingleOrDefault(c => c.Id == compId);

            if (ModelState.IsValid)
            {
                //adding "savoirfaire" 
                if (_dbContext.Competances.SingleOrDefault(c => c.Id == compId).SavoirFaires.Any(sf => sf.nomSavoir.Equals(savoir.nomSavoir, StringComparison.InvariantCultureIgnoreCase)))
                {
                    ModelState.AddModelError("Erreur_nomSavoir", "Ce savoir éxiste déja dans cette compétance");
                    return View();
                } else
                {
                    _dbContext.Competances.SingleOrDefault(c => c.Id == compId).SavoirFaires.Add(savoir);
                }
                //adding "etats" for the new "savoirfaire" 
                List<Periode> periodes = _dbContext.Periodes.ToList();
                List<Etat> etats = new List<Etat>();
               foreach(var periode in periodes) {
                    Etat et = new Etat()
                    {
                        Periode = periode,
                        SavoireFaire = savoir
                    };
                    _dbContext.Etats.Add(et);
                }
                _dbContext.SaveChanges();
            }
            return View();
        }
        [Route("Competance/SupprimerSavoir/{savId}/{compId}")]
        public ActionResult SupprimerSavoir(int savId,int compId)
        {
           var value =  _dbContext.SavoirFaires.Remove(_dbContext.SavoirFaires.SingleOrDefault(sf => sf.Id == savId));
            _dbContext.SaveChanges();
            return RedirectToAction("All", new RouteValueDictionary( new { controller = "Competance", action = "All", Id = compId }));
        }
        [Route("Competance/All/{discId}")]
        public ActionResult All(int discId)
        {
            var a = discId;
            var selectedDiscipline = _dbContext.Disciplines.FirstOrDefault(c => c.Id == discId);
            session.selectedDiscipline = selectedDiscipline;
            return View();
        }
        //ajouter competance

        [Route("Competance/AjouterCompetance/{discId}")]
        public ActionResult AjouterCompetance(int discId)
        {
            ViewBag.Discipline = System.Web.HttpContext.Current.Session["selectedDiscipline"];
            return View();
        }
        [HttpPost]
        [Route("Competance/AjouterCompetance/{discId}")]
        public ActionResult AjouterCompetance(Competance competance, int discId)
        {
            ViewBag.Discipline = System.Web.HttpContext.Current.Session["selectedDiscipline"];
            var discipline = (Discipline)ViewBag.Discipline;
            if (ModelState.IsValid)
            {
                if (_dbContext.Disciplines.SingleOrDefault(c => c.Id == discipline.Id).Competances.Any(sf => sf.nomCompetance.Equals(competance.nomCompetance, StringComparison.InvariantCultureIgnoreCase)))
                {
                    ModelState.AddModelError("error", "Cette compétance éxiste déja dans la discipline sélectionée");
                    return View();
                }
                else
                {
                    _dbContext.Disciplines.SingleOrDefault(c => c.Id == discipline.Id).Competances.Add(competance);
                    _dbContext.SaveChanges();
                    ModelState.AddModelError("success", "Compétance créee");
                }
            }

            return View();
        }

    }
}