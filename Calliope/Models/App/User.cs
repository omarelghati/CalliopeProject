using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace Calliope.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string nomComplet { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string phone { get; set; }

        [Required]
        [StringLength(20)]
        public string civilite { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }

        [Required]
        [StringLength(20)]
        public string type { get; set; }

        public void generateData(ViewModels.RegisterViewModel r)
        {
            this.nomComplet = r.nomComplet;
            this.email = r.email;
            this.phone = r.phone;
            this.civilite = r.selectedCivility;
            this.type = r.selectedType;
            this.password = r.password;
            this.confirmPassword = r.confirmPassword;

        }
    }
}