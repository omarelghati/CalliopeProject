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
        [StringLength(12)]
        public string phone { get; set; }

        [Required]
        [StringLength(20)]
        public string civilite { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
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