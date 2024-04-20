﻿using System.ComponentModel.DataAnnotations;

namespace Entrega2.PGPIC.Shared.Entities
{
    public class ResearchActivity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Invstigación")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(50, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo {1} requerido")]
        [MaxLength(500, ErrorMessage = "{1} no puede superar {2} caracteres")]
        public string Description { get; set; }

        [Display(Name = "Fecha de inicio")]
        [Required(ErrorMessage = "Campo requerido")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha estimada de finalización")]
        [DisplayFormat(DataFormatString = "{0}:yyyy/MM/dd HH:mm", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        public ResearchProject Project { get; set; }

        public ICollection<SpecializedResource> Resources { get; set; }
    }
}