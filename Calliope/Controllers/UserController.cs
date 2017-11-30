using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calliope.Models;
using Calliope.Models.App;

namespace Calliope.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewModels.RegisterViewModel register = new ViewModels.RegisterViewModel();

            register.civilite = new List<SelectListItem>
             {
                new SelectListItem { Text = "Monsieur", Value = "Monsieur" },
                new SelectListItem{ Text = "Madame", Value = "Madame" },
                new SelectListItem{ Text = "Mademoiselle", Value = "Mademoiselle" }
            };
            register.type = new List<SelectListItem>{
                new SelectListItem{ Text = "Administrateur", Value = "Administrateur" },
                new SelectListItem{ Text = "Enseignant", Value = "Enseignant" },
                new SelectListItem{ Text = "Parent", Value = "Parent" },
                new SelectListItem{ Text = "Coordinateur", Value = "Coordinateur" },
                new SelectListItem{ Text = "Administration", Value = "Administration" }
            };
            return View(register);
        }
        [HttpPost]
        public ActionResult Register(ViewModels.RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    ViewBag.Message = db.GetValidationErrors();
                    switch (register.selectedType)
                    {
                        case "Parent":
                            Parent p = new Parent();
                            p.generateData(register);
                            db.Users.Add(p);
                            return RedirectToAction("Index", "Parent", new { area = "" });
                        case "Enseignant":
                            Enseignant e = new Enseignant();
                            e.generateData(register);
                            db.Users.Add(e);
                            return RedirectToAction("Index", "Enseignant", new { area = "" });
                        case "Administrateur":
                            Administrateur a = new Administrateur();
                            a.generateData(register);
                            db.Users.Add(a);
                            return RedirectToAction("Index", "Administrateur", new { area = "" });
                        case "Coordinateur":
                            Coordinateur c = new Coordinateur();
                            c.generateData(register);
                            db.Users.Add(c);
                            return RedirectToAction("Index", "Coordinateur", new { area = "" });
                        case "Administration":
                            Administration ad = new Administration();
                            ad.generateData(register);
                            db.Users.Add(ad);
                            return RedirectToAction("Index", "Administration", new { area = "" });
                    }
                    db.SaveChanges();
                   
                }
            } 
           
            return View();
        }
        public ActionResult Login()
        {
            if (System.Web.HttpContext.Current.Session["enseignant"] != null)
                return RedirectToAction("Index", "Enseignant", new { area = "" });
            else if (System.Web.HttpContext.Current.Session["parent"] != null)
            {
                return RedirectToAction("Index", "Parent", new { area = "" });
            }
            else if (System.Web.HttpContext.Current.Session["coordinateur"] != null)
            {
                return RedirectToAction("Index", "Coordinateur", new { area = "" });
            }
            else if (System.Web.HttpContext.Current.Session["administration"] != null)
            {
                return RedirectToAction("Index", "Administration", new { area = "" });
            }
            else if (System.Web.HttpContext.Current.Session["administrateur"] != null)
            {
                return RedirectToAction("Index", "Root", new { area = "" });
            }

            ViewModels.LoginViewModel login = new ViewModels.LoginViewModel();
            login.type = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Administrateur", Value = "Administrateur" },
                new SelectListItem{ Text = "Enseignant", Value = "Enseignant" },
                new SelectListItem{ Text = "Parent", Value = "Parent" },
                new SelectListItem{ Text = "Coordinateur", Value = "Coordinateur" },
                new SelectListItem{ Text = "Administration", Value = "Administration" }
            };
            return View(login);
        }
        [HttpPost]
        public ActionResult Login(ViewModels.LoginViewModel login)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var usr = db.Users.SingleOrDefault(u => u.email.Equals(login.email) && u.password.Equals(login.password));
                if (usr != null)
                {
                    if (usr.type == login.selectedType)
                    {
                       
                        SessionHelper session = new SessionHelper();

                        switch (usr.type)
                        {
                            case "Enseignant":
                                Enseignant enseignant = (Enseignant)usr;
                                session.enseignant = enseignant;
                                return RedirectToAction("Index", "Enseignant", new { area = "" });
                            case "Parent":
                                Parent parent = (Parent)usr;
                                session.parent = parent;
                                return RedirectToAction("Index", "Parent", new { area = "" });
                            case "Administration":
                                Administration administration = (Administration)usr;
                                session.administration = administration;
                                return RedirectToAction("Index", "Administration", new { area = "" });
                            case "Administrateur":
                                Administrateur administrateur = (Administrateur)usr;
                                session.administrateur = administrateur;
                                return RedirectToAction("Index", "Administrateur", new { area = "" });
                            case "Coordinateur":
                                Coordinateur coordinateur = (Coordinateur)usr;
                                session.coordinateur = coordinateur;
                                return RedirectToAction("Index", "Coordinateur", new { area = "" });                            
                        }
                    }
                        
                }
                else
                {
                    ModelState.AddModelError("", "Informations invalides");
                }
            }
            ViewModels.LoginViewModel loginvm = new ViewModels.LoginViewModel();
            loginvm.type = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Administrateur", Value = "Administrateur" },
                new SelectListItem{ Text = "Enseignant", Value = "Enseignant" },
                new SelectListItem{ Text = "Parent", Value = "Parent" },
                new SelectListItem{ Text = "Coordinateur", Value = "Coordinateur" },
                new SelectListItem{ Text = "Administration", Value = "Administration" }
            };
            ModelState.AddModelError("error_user", "Utilisateur non trouvé");
            return View(loginvm);
        }
        [Route("User/Logout")]
        public ActionResult Logout()
        {
            if (System.Web.HttpContext.Current.Session != null)
                System.Web.HttpContext.Current.Session.Abandon();
            return RedirectToAction("Login", "User", new { area = "" });
        }
    }
}