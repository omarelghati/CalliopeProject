using Calliope.Models;
using Calliope.Models.App;
using Calliope.ViewModels.Enseignant;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calliope.ViewModels;
using System;
using System.Data.Entity.Validation;

namespace Calliope.Controllers
{

    public class EnseignantController : Controller
    {
        SessionHelper session = new SessionHelper();
        private ApplicationDbContext _dbContext;

        public EnseignantController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Enseignant
        public ActionResult Index()
        {
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];
            var enseignant = _dbContext.Enseignants.SingleOrDefault(e => e.Id == user.Id);
            var niveaux = _dbContext.Enseignants.Where(a => a.Id == user.Id).Include(ens => ens.Niveaus).First();
            Dictionary<Niveau, List<Groupe>> Data = new  Dictionary<Niveau, List<Groupe>>();
            foreach (var niveau in niveaux.Niveaus)
            {
                var groupes = niveau.Groupes.ToList();
                foreach (var groupe in groupes.ToList())
                {
                    if (groupe.Enseignants.Count == 0)
                        groupes.Remove(groupe);
                }
                Data.Add((Niveau)niveau, (List<Groupe>)groupes);
            }
            session.Data = Data;
            var counter = 0;
            foreach(var groupe in enseignant.Groupes)
            {
                counter += groupe.Eleves.Count;
            }
            Session["counter"] = counter;
            return View(enseignant);
        }
        [HttpPost]
        public ActionResult Index(Enseignant ens)
        {
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];
            var enseignant = _dbContext.Enseignants.SingleOrDefault(e => e.Id == user.Id);
            enseignant.nomComplet = ens.nomComplet;
            enseignant.email = ens.email;
            enseignant.civilite = ens.civilite;
            enseignant.phone = ens.phone;
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ModelState.AddModelError("error", "Une erreur s'est produite, veuillez vos informations");
            }
            session.enseignant = enseignant;
            var niveaux = _dbContext.Enseignants.Where(a => a.Id == user.Id).Include(ense => ense.Niveaus).First();
            Dictionary<Niveau, List<Groupe>> Data = new Dictionary<Niveau, List<Groupe>>();
            foreach (var niveau in niveaux.Niveaus)
            {
                var groupes = niveau.Groupes.ToList();
                foreach (var groupe in groupes.ToList())
                {
                    if (groupe.Enseignants.Count == 0)
                        groupes.Remove(groupe);
                }
                Data.Add((Niveau)niveau, (List<Groupe>)groupes);
            }
            session.Data = Data;
            var counter = 0;
            foreach (var groupe in enseignant.Groupes)
            {
                counter += groupe.Eleves.Count;
            }
            Session["counter"] = counter;
            return View(enseignant);
        }
        public ActionResult Mes_Disciplines()
        {
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];

            var Disciplines = _dbContext.Enseignants.SingleOrDefault(u => u.Id == user.Id).Disciplines;
            AjoutViewModel ajout = new AjoutViewModel();
            ajout.Data = (Dictionary<Niveau, List<Groupe>>)Session["data"];
            ajout.Disciplines = _dbContext.Disciplines.ToList();
            ajout.CurrentDisciplines = Disciplines.ToList();
            return View(ajout);
        }
        [HttpPost]
        public ActionResult Mes_Disciplines(AjoutViewModel ajout)
        {
            //var niveau = _dbContext.Niveaux.SingleOrDefault(n => n.niveau == ajout.Niveau).Disciplines.SingleOrDefault(d=> d.nomDiscipline == ajout.Discipline);
            //var t=niveau;
            //preparing the viewmodel for the view
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];
            var Disciplines = _dbContext.Enseignants.SingleOrDefault(u => u.Id == user.Id).Disciplines;
            AjoutViewModel ajouter = new AjoutViewModel();
            ajouter.Data = (Dictionary<Niveau, List<Groupe>>)Session["data"];
            ajouter.Disciplines = _dbContext.Disciplines.ToList();
            ajouter.CurrentDisciplines = Disciplines.ToList();
            //getting the selected "niveau"
            var niveau = _dbContext.Niveaux.SingleOrDefault(n => n.niveau.Equals(ajout.Niveau));
            var d = new Discipline()
            {
                nomDiscipline = ajout.Discipline
            };
            niveau.Disciplines.Add(d);
            //adding if not exists (groupe/discipline)
            var groupe = _dbContext.Groupes.SingleOrDefault(g => g.nomGroupe.Equals(ajout.Groupe));
            var discipline = _dbContext.Niveaux.SingleOrDefault(n => n.niveau.Equals(ajout.Niveau)).Disciplines.SingleOrDefault(di => di.nomDiscipline == ajout.Discipline);
            var groupes = _dbContext.Enseignants.Single(e => e.Id == user.Id).Groupes;
            var test = groupes.Single(g => g.nomGroupe.Equals(ajout.Groupe)).Disciplines.SingleOrDefault(di => di.Id == discipline.Id);
            if (test == null)
            {
                //adding to the join table (groupe-discipline)
                var disciplines = groupes.Single(di => di.nomGroupe.Equals(ajout.Groupe)).Disciplines;
                disciplines.Add(discipline);
                ModelState.AddModelError("done", "Discipline ajouté au groupe sélectioné !");
                _dbContext.Enseignants.SingleOrDefault(c => c.Id == user.Id).Groupes.Add(groupe);
                //adding to join table (enseignant-discipline)
                _dbContext.Enseignants.SingleOrDefault(e => e.Id == user.Id).Disciplines.Add(discipline);
                _dbContext.SaveChanges();
                return View(ajouter);
            }
            ModelState.AddModelError("exists", "Discipline existe déja pour le groupe sélectioné !");
            return View(ajout);
        }

        public ActionResult Evaluations()
        {
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];
            EvaluationsViewModel VmEvals = new EvaluationsViewModel();
            VmEvals.Evals = _dbContext.Enseignants.SingleOrDefault(c => c.Id == user.Id).EvaluationCollectives.ToList();
            VmEvals.Groupes = (Groupe)System.Web.HttpContext.Current.Session["selectedGroupe"];
            VmEvals.Disciplines = _dbContext.Enseignants.SingleOrDefault(u => u.Id == user.Id).Disciplines.ToList();
            return View(VmEvals);
        }
        public ActionResult EvaluationDetails(int evalId,int nivId)
        {
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];
            var eval = _dbContext.EvaluationCollectives.SingleOrDefault(c => c.Id == evalId);
            System.Web.HttpContext.Current.Session["evalDetails"] = eval;
            return View();
        }
        public ActionResult Groupe(int id)
        {
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];
            var selectedGroup = _dbContext.Groupes.SingleOrDefault(c => c.Id == id);
            GroupeViewModel model = new GroupeViewModel();
            model.Eleves = selectedGroup.Eleves.ToList();
            model.Groupe = selectedGroup;
            System.Web.HttpContext.Current.Session["selectedGroupe"] = selectedGroup;
            return View(model);
        }
        public ActionResult Profil(int? id)
        {
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];
            var ens = _dbContext.Enseignants.Where(c => c.Id == user.Id).Include(c => c.Groupes);
            ViewBag.Data = ens.ToList();
            return View();
        }
        [Route("Enseignant/AjouterAbsence/{disc}/{grp}")]
        public ActionResult AjouterAbsence(int disc,int grp)
        {
            AjouterAbsenceViewModel vm = new AjouterAbsenceViewModel();
            vm.Groupe = _dbContext.Groupes.FirstOrDefault(g => g.Id == grp);
            vm.Discipline = _dbContext.Disciplines.FirstOrDefault(d => d.Id == disc);
            return View(vm);
        }
        [Route("Enseignant/NoterAbsence/{eleve}/{disc}")]
        public ActionResult NoterAbsence(int eleve,int disc)
        {
            var Discipline = _dbContext.Disciplines.FirstOrDefault(d => d.Id == disc);
            var user = (Enseignant)System.Web.HttpContext.Current.Session["enseignant"];
            var Enseignant = _dbContext.Enseignants.FirstOrDefault(e =>e.Id == user.Id);
            var Eleve = _dbContext.Eleves.FirstOrDefault(e => e.Id == eleve);
            Absence a = new Absence {
                Date = DateTime.Now,
                Eleve = Eleve,
                Discipline = Discipline,
                Enseignant = Enseignant
            };
            _dbContext.Absences.Add(a);
            _dbContext.SaveChanges();
            var groupe = (Groupe)System.Web.HttpContext.Current.Session["selectedGroupe"];
            Session["absdone"] = eleve;
             return RedirectToAction("AjouterAbsence", new { disc = disc,grp = groupe.Id});
        }
    }
}