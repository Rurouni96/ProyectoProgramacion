using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Clasificacion Cliente")]
        public int ClasificacionId { get; set; }

        [Required]
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaIngreso { get; set; }
        [Required]
        [Display(Name = "Porcentaje de decuento")]
        public int PorcentajeDescuento { get; set; }
        [Required]
        public bool Estado { get; set; }

        public ClasificacionCliente ClasificacionCliente { get; set; }
    }
}