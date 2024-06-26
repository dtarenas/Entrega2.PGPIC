﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entrega2.PGPIC.Shared.Entities
{
    public class ResearchProject
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Proyecto")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(50, ErrorMessage = "{0} no puede superar {1} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo {0} requerido")]
        [MaxLength(255, ErrorMessage = "{0} no puede superar {1} caracteres")]
        public string Description { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "Fecha estimada de finalización")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime EstimatedEndDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<Researcher> Researchers { get; set; }
        
        [JsonIgnore]
        public ICollection<ResearchActivity> Activities { get; set; }

        [JsonIgnore]
        public ICollection<Publication> Publications { get; set; }
        
        [JsonIgnore]
        public ICollection<SpecializedResource> Resources { get; set; }
    }
}