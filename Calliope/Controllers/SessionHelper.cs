using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Calliope.Models.App;
using System.Web;

namespace Calliope.Controllers
{
    public class SessionHelper : Controller
    {
        public Enseignant enseignant
        {
            get { return (Enseignant)System.Web.HttpContext.Current.Session["enseignant"]; }
            set { System.Web.HttpContext.Current.Session["enseignant"] = value; }
        }

        public Coordinateur coordinateur
        {
            get { return (Coordinateur)System.Web.HttpContext.Current.Session["coordinateur"]; }
            set { System.Web.HttpContext.Current.Session["coordinateur"] = value; }
        }
        public Administrateur administrateur
        {
            get { return (Administrateur)System.Web.HttpContext.Current.Session["administrateur"]; }
            set { System.Web.HttpContext.Current.Session["administrateur"] = value; }
        }
        public Administration administration
        {
            get { return (Administration)System.Web.HttpContext.Current.Session["administration"]; }
            set { System.Web.HttpContext.Current.Session["administration"] = value; }
        }
        public Dictionary<Niveau,List<Groupe>> Data
        {
            get { return (Dictionary<Niveau, List<Groupe>>)System.Web.HttpContext.Current.Session["data"]; }
            set { System.Web.HttpContext.Current.Session["data"] = value; }
        }
        public List<Eleve> eleves
        {
            get { return (List<Eleve>)System.Web.HttpContext.Current.Session["eleves"]; }
            set { System.Web.HttpContext.Current.Session["eleves"] = value; }
        }
        public List<Discipline> disciplines
        {
            get { return (List<Discipline>)System.Web.HttpContext.Current.Session["disciplines"]; }
            set { System.Web.HttpContext.Current.Session["disciplines"] = value; }
        }

        public List<EvaluationCollective> evals
        {
            get { return (List<EvaluationCollective>)System.Web.HttpContext.Current.Session["evals"]; }
            set { System.Web.HttpContext.Current.Session["evals"] = value; }
        }
        public Discipline selectedDiscipline
        {
            get { return (Discipline)System.Web.HttpContext.Current.Session["selectedDiscipline"]; }
            set { System.Web.HttpContext.Current.Session["selectedDiscipline"] = value; }
        }
        //////
        public Parent parent
        {
            get { return (Parent)System.Web.HttpContext.Current.Session["parent"]; }
            set { System.Web.HttpContext.Current.Session["parent"] = value; }
        }
        public int disciplineid
        {
            get { return (int)System.Web.HttpContext.Current.Session["disciplineid"]; }
            set { System.Web.HttpContext.Current.Session["disciplineid"] = value; }
        }
    }

}
