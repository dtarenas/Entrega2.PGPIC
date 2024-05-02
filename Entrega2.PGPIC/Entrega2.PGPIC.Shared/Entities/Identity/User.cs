using Entrega2.PGPIC.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entrega2.PGPIC.Shared.Entities.Identity
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(20, ErrorMessage = "{0} no puede superar {1} caracteres")]
        public string Document { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} caracteres")]
        public string LastName { get; set; }

        public string Address { get; set; } 

        public UserType UserType { get; set; }

        public string FullName => $"{FirstName}{LastName}";
    }
}