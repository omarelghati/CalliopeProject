using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Calliope.Models.App;

namespace Calliope.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Saison> Saisons { get; set; }
        public DbSet<Emploi> Emplois { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<SavoirFaire> SavoirFaires { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Coordinateur> Coordinateurs { get; set; }
        public DbSet<Administration> Administrations { get; set; }
        public DbSet<Niveau> Niveaux { get; set; }
        public DbSet<Competance> Competances { get; set; }
        public DbSet<EvaluationCollective> EvaluationCollectives { get; set; }
        public DbSet<EvalutiationIndiv> EvalutiationIndivs { get; set; }
        public DbSet<Etat> Etats { get; set; }
        public DbSet<Periode> Periodes { get; set; }
        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Note>()
            //    .HasOptional<SavoirFaire>(s => s.SavoirFaire)
            //    .WithMany()
            //    .WillCascadeOnDelete(true);
        }
        public ApplicationDbContext() : base("AppDBContext")
        {

        }
    }
}