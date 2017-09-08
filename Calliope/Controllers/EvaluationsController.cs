using Calliope.Models;
using Calliope.Models.App;
using Calliope.ViewModels.Enseignant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Calliope.Controllers
{
    public class EvaluationsController : Controller
    {
        SessionHelper session = new SessionHelper();
        private ApplicationDbContext _dbContext;

        public EvaluationsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Evaluations
        public ActionResult Index()
        {
            return View();
        }

        [Route("Enseignant/Evaluations/Plannifier/{DisciplineId}")]

        public ActionResult Plannifier(int DisciplineId)
        {
            session.disciplineid = DisciplineId;
            PlannifierEvalViewModel planVm = new PlannifierEvalViewModel();
            planVm.Periodes = _dbContext.Periodes.ToList();
            planVm.Competances = _dbContext.Disciplines.SingleOrDefault(c => c.Id == DisciplineId).Competances.ToList();
            planVm.Etats = _dbContext.Etats.ToList();
            return View(planVm);
        }
        [Route("Enseignant/Evaluations/Plannifier/etat/{EtatId}")]
        public ActionResult Plannifier(int? Id2,int EtatId)
        {
            var DisciplineId = (int)System.Web.HttpContext.Current.Session["disciplineid"];
            Etat etat = _dbContext.Etats.SingleOrDefault(e => e.Id == EtatId);
            var Discipline = _dbContext.Disciplines.SingleOrDefault(c => c.Id == DisciplineId);
            var userSession = (Enseignant)Session["enseignant"];
            var enseignant = _dbContext.Enseignants.SingleOrDefault(e=> e.Id == userSession.Id);
            //creating evaluation
            EvaluationCollective evaluation = new EvaluationCollective();
            if (etat.etat == false)
            {
                evaluation.SavoirFaire = etat.SavoireFaire;
                evaluation.Niveau = Discipline.Niveau;
                evaluation.Periode = etat.Periode;
                evaluation.date = DateTime.Now;
                evaluation.titre = Discipline.nomDiscipline;
                evaluation.domaine = etat.SavoireFaire.Competance.nomCompetance;
                _dbContext.Enseignants.SingleOrDefault(e => e.Id == userSession.Id).EvaluationCollectives.Add(evaluation);
            }
            etat.etat = !etat.etat;
            _dbContext.SaveChanges();
            PlannifierEvalViewModel planVm = new PlannifierEvalViewModel();
            planVm.Periodes = _dbContext.Periodes.ToList();
            planVm.Competances = Discipline.Competances.ToList();
            planVm.Etats = _dbContext.Etats.ToList();
            return Redirect("/Enseignant/Evaluations/Plannifier/"+DisciplineId);
        }
    }
}