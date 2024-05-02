using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entrega2.PGPIC.Shared.Entities
{
    public class SpecializedResource
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Recurso")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(50, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Cantidad Requerida")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        public int RequiredQuantity { get; set; }

        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(50, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Provider { get; set; }

        [Display(Name = "Fecha de Entrega Estimada")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime EstimatedDeliveryDate{ get; set; }

        [JsonIgnore]
        public ICollection<ResearchActivity> Activities { get; set; }
    }
}
