using System.ComponentModel.DataAnnotations;

namespace Entrega2.PGPIC.Shared.Entities
{
    public class Publication
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(50, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Title { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(255, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Author { get; set; }

        [Display(Name = "Fecha de publicación")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }

        public ResearchProject Project { get; set; }
    }
}