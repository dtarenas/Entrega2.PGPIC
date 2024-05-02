using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entrega2.PGPIC.Shared.Entities
{
    public class ResearchActivity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Invstigación")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(500, ErrorMessage = "{0} no puede superar {1} caracteres")]
        public string Description { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha estimada de finalización")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        public int ProjectId { get; set; }

        public ResearchProject Project { get; set; }

        [JsonIgnore]
        public ICollection<SpecializedResource> Resources { get; set; }
    }
}
