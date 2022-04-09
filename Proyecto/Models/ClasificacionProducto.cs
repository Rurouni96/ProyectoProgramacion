using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class ClasificacionProducto
    {
        [Key]
        [Required]
        public int ClasificacionProductoId { get; set; }
        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}