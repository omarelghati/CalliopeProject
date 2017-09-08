using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calliope.Models;
using Calliope.Models.App;
using Calliope.ViewModels.Administration;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Data.Entity.Validation;

namespace Calliope.Controllers
{
    public class AdministrationController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        SessionHelper session = new SessionHelper();
        // GET: Administration
        public ActionResult Index()
        {
            var user = (Administration)Session["administration"];
            var admin = dbContext.Administrations.SingleOrDefault(a => a.Id == user.Id);

            Session["groupes"] = dbContext.Groupes.Count();
            Session["coords"] = dbContext.Coordinateurs.Count();
            Session["enseignants"] = dbContext.Enseignants.Count();
            Session["parents"] = dbContext.Parents.Count();
            return View(admin);
        }
        //Enseignants
        public ActionResult Enseignants()
        {
            var enseignants = dbContext.Enseignants.ToList();
            return View(enseignants);
        }
        public ActionResult ModifierEnseignant(int id)
        {
            var enseignant = dbContext.Enseignants.SingleOrDefault(e => e.Id == id);
            return View(enseignant);
        }
        [HttpPost]
        public ActionResult ModifierEnseignant(Enseignant ens)
        {
            var enseignant = dbContext.Enseignants.SingleOrDefault(e => e.Id == ens.Id);
            enseignant.nomComplet = ens.nomComplet;
            enseignant.email = ens.email;
            enseignant.phone = ens.phone;
            enseignant.civilite = ens.civilite;
            dbContext.SaveChanges();
            ModelState.AddModelError("success_enseignant", "Modifications approuvées.");
            return View(enseignant);
        }
        public ActionResult SupprimerEnseignant(int id)
        {
            var enseignant = dbContext.Enseignants.SingleOrDefault(e => e.Id == id);
            dbContext.Enseignants.Remove(enseignant);
            dbContext.SaveChanges();
            return RedirectToAction("Enseignants");
        }

        //parents

        public ActionResult Parents()
        {
            var parents = dbContext.Parents.ToList();
            return View(parents);
        }
        public ActionResult ModifierParent(int id)
        {
            var parent = dbContext.Parents.SingleOrDefault(e => e.Id == id);
            return View(parent);
        }
        [HttpPost]
        public ActionResult ModifierParent(Parent par)
        {
            var parent = dbContext.Parents.SingleOrDefault(e => e.Id == par.Id);
            parent.nomComplet = par.nomComplet;
            parent.email = par.email;
            parent.phone = par.phone;
            parent.civilite = par.civilite;
            dbContext.SaveChanges();
            ModelState.AddModelError("success_parents", "Modifications approuvées.");
            return View(parent);
        }
        public ActionResult SupprimerParent(int id)
        {
            var parent = dbContext.Parents.SingleOrDefault(e => e.Id == id);
            dbContext.Parents.Remove(parent);
            dbContext.SaveChanges();
            return RedirectToAction("Parents");
        }
        //groupes

        public ActionResult Groupes()
        {
            var groupes = dbContext.Groupes.ToList();
            return View(groupes);
        }
        public ActionResult AfficherGroupe(int id)
        {
            var groupe = dbContext.Groupes.SingleOrDefault(e => e.Id == id);
            return View(groupe);
        }
        [HttpPost]
        public ActionResult AfficherGroupe(Groupe grp)
        {
            var groupe = dbContext.Groupes.SingleOrDefault(e => e.Id == grp.Id);

            dbContext.SaveChanges();
            ModelState.AddModelError("success_parents", "Modifications approuvées.");
            return View(groupe);
        }
        public ActionResult SupprimerGroupe(int id)
        {
            var groupe = dbContext.Groupes.SingleOrDefault(e => e.Id == id);
            dbContext.Groupes.Remove(groupe);
            dbContext.SaveChanges();
            return RedirectToAction("Groupes");
        }
        public ActionResult CreerGroupe()
        {
            CreerGroupeViewModel grpvm = new CreerGroupeViewModel();
            grpvm.Niveaux = dbContext.Niveaux.ToList();
            return View(grpvm);
        }
        [HttpPost]
        public ActionResult CreerGroupe(CreerGroupeViewModel grp)
        {
            var x = grp.selectedNiveau;
            var niveau = dbContext.Niveaux.SingleOrDefault(n => n.Id == x);
            var groupe = niveau.Groupes.SingleOrDefault(g => g.nomGroupe == grp.Groupe.nomGroupe);
            if (ModelState.IsValid && groupe == null)
            {
                Groupe g = new Groupe
                {
                    nomGroupe = grp.Groupe.nomGroupe,
                    Niveau = niveau
                };

                dbContext.Groupes.Add(g);
                dbContext.SaveChanges();
                ModelState.AddModelError("success_groupe", "Groupe Ajouté");
            }
            CreerGroupeViewModel grpvm = new CreerGroupeViewModel();
            grpvm.Niveaux = dbContext.Niveaux.ToList();
            return View(grpvm);
        }

        // eleves
        public ActionResult AjouterEleve(int id)
        {
            AjouterEleveViewModel vm = new AjouterEleveViewModel();
            vm.Parents = dbContext.Parents.ToList();
            return View(vm);
        }
        [HttpPost]
        public ActionResult AjouterEleve(AjouterEleveViewModel evm, int id)
        {
            var groupe = dbContext.Groupes.SingleOrDefault(g => g.Id == id);
            evm.Eleve.Groupe = groupe;
            if (ModelState.IsValid)
            {
                dbContext.Parents.SingleOrDefault(g => g.Id == evm.selectedParent).Eleves.Add(evm.Eleve);
                dbContext.SaveChanges();
                ModelState.AddModelError("success_eleve", "Elève Ajouté.");
            }
            AjouterEleveViewModel vm = new AjouterEleveViewModel();
            vm.Parents = dbContext.Parents.ToList();

            return View(vm);
        }

        public ActionResult ModifierEleve(int id)
        {
            var eleve = dbContext.Eleves.FirstOrDefault(e => e.Id == id);
            return View(eleve);
        }
        [HttpPost]
        public ActionResult ModifierEleve(Eleve e, int id)
        {
            var eleve = dbContext.Eleves.FirstOrDefault(el => el.Id == e.Id);
            eleve.nomComplet = e.nomComplet;
            eleve.gender = e.gender;
            eleve.dateDeNaissance = e.dateDeNaissance;
            dbContext.SaveChanges();
            var selected = (int)Session["selectedGroupe"];
            return RedirectToAction("AfficherGroupe", "Administration", new { id = selected });
        }
        public ActionResult SupprimerEleve(int id)
        {
            var selected = (int)Session["selectedGroupe"];
            var eleve = dbContext.Eleves.FirstOrDefault(el => el.Id == id);
            dbContext.Groupes.FirstOrDefault(g => g.Id == selected).Eleves.Remove(eleve);
            dbContext.SaveChanges();

            return RedirectToAction("AfficherGroupe", "Administration", new { id = selected });
        }
        public ActionResult AffecterEleve(int id)
        {
            AffecterEleveViewModel vm = new AffecterEleveViewModel();
            vm.Eleves = dbContext.Eleves.Where(e => e.Groupe == null).ToList();
            return View(vm);
        }
        [HttpPost]
        public ActionResult AffecterEleve(AffecterEleveViewModel vm)
        {
            var groupe = (int)Session["selectedGroupe"];
            var eleve = dbContext.Eleves.FirstOrDefault(e => e.Id == vm.selectedEleve);
            eleve.Groupe = dbContext.Groupes.FirstOrDefault(g => g.Id == groupe);
            dbContext.SaveChanges();
            ModelState.AddModelError("success_AffecterEleve", "Elève affecté à ce groupe");
            vm.Eleves = dbContext.Eleves.Where(e => e.Groupe == null).ToList();
            return View(vm);
        }
        public ActionResult Coordinateurs()
        {
            var coords = dbContext.Coordinateurs.ToList();
            return View(coords);
        }
        public ActionResult ModifierCoordinateur(int id)
        {
            var coord = dbContext.Coordinateurs.SingleOrDefault(e => e.Id == id);
            return View(coord);
        }
        [HttpPost]
        public ActionResult ModifierCoordinateur(Coordinateur coord)
        {
            var coordinateur = dbContext.Coordinateurs.SingleOrDefault(e => e.Id == coord.Id);
            coordinateur.nomComplet = coord.nomComplet;
            coordinateur.email = coord.email;
            coordinateur.phone = coord.phone;
            coordinateur.civilite = coord.civilite;
            dbContext.SaveChanges();
            ModelState.AddModelError("success_coordinateur", "Modifications approuvées.");
            return View(coordinateur);
        }
        public ActionResult SupprimerCoordinateur(int id)
        {
            var coord = dbContext.Coordinateurs.SingleOrDefault(e => e.Id == id);
            dbContext.Coordinateurs.Remove(coord);
            dbContext.SaveChanges();
            return RedirectToAction("Coordinateurs");
        }
        public ActionResult AfficherEmploi(int id)
        {
            var groupe = dbContext.Groupes.FirstOrDefault(g => g.Id == id);
            return View(groupe.Emploi);
        }
        public ActionResult AjouterEmploi(int id)
        {
            //AjouterEmploiViewModel vm = new AjouterEmploiViewModel();
            var s = dbContext.Saisons.ToList();
            //var saisons = new List<SelectListItem>();
            //foreach (var saison in s)
            //{
            //    saisons.Add(new SelectListItem
            //    {
            //        Text = saison.dateSaison.ToString(),
            //        Value = 1+""
            //    });
            //}
            //vm.Saisons = saisons;
            Session["Saisons"] = s;
            return View();
        }
        [HttpPost]
        public ActionResult AjouterEmploi([Bind(Include = "FileName, FilePath")] Emploi emploi, HttpPostedFileBase emploiFile, int id)
        {
            string filename = string.Empty;
            string filepath = string.Empty;

            filename = emploiFile.FileName;
            string ext = Path.GetExtension(filename);
            if (ext == ".pdf")
            {
                var a = emploi.SelectedSaison;
                filepath = Server.MapPath("~//Files//");
                emploiFile.SaveAs(filepath + filename);

                emploi.FileName = filename;
                emploi.FilePath = "~//Files//";
                var groupe = dbContext.Groupes.FirstOrDefault(g => g.Id == id);
                emploi.Groupe = groupe;
                var saison = dbContext.Saisons.FirstOrDefault(g => g.Id == 1);
                emploi.Saison = saison;

                dbContext.Emplois.Add(emploi);
                try
                {
                    dbContext.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    var error = "";
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            error += "Property:   " + validationError.PropertyName + " Error:  " + validationError.ErrorMessage+"\n";
                            return Content(error);
                        }
                    }
                }
            }
            return View();
        } 
    } 
}///////Affectation des eleves !!!! (done)

/*
 parent => eleve => note/absences
 add absence model  and set absence to "enseignant"
     */