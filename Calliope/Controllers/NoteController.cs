using Calliope.Models;
using Calliope.Models.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calliope.Controllers
{
    public class NoteController : Controller
    {

        ApplicationDbContext _dbContext;
        public NoteController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Note
        public ActionResult Index()
        {
            return View();
        }
        [Route("AjouterNote/{discipline}/{eval}/{eleve}/{sf}/{noteValue}")]
        public ActionResult AjouterNote(int discipline, int eval, int eleve,int sf,int noteValue)
        {
            Eleve e = _dbContext.Eleves.SingleOrDefault(a => a.Id == eleve);
            var note = e.Notes.SingleOrDefault(n => n.SavoirFaire.Id == sf);
            if (note == null)
            {
                SavoirFaire savoir = _dbContext.SavoirFaires.SingleOrDefault(s => s.Id == sf);
                Note n = new Note()
                {
                    note = noteValue,
                    SavoirFaire = savoir,
                };
                _dbContext.Eleves.SingleOrDefault(el => el.Id == e.Id).Notes.Add(n);
                ModelState.AddModelError("done", "Note ajoutée.");
            } else
            {
                note.note = noteValue;
                ModelState.AddModelError("done", "Note modifiée.");
            } 
            _dbContext.SaveChanges();
            var niveau = _dbContext.Disciplines.SingleOrDefault(d => d.Id == discipline).Niveau.Id;
            return Redirect("/Enseignant/Evaluations/Details/" + eval+"/"+niveau);
        }
    }
}