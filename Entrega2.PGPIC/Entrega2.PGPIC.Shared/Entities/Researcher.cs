using System.ComponentModel.DataAnnotations;

namespace Entrega2.PGPIC.Shared.Entities
{
    public class Researcher
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Investigador")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(50, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Especialidad")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(500, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Specialization { get; set; }

        [Display(Name = "Afiliación")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(100, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Afiliation { get; set; }

        public ICollection<ResearchProject> Projects { get; set; }

    }
}
