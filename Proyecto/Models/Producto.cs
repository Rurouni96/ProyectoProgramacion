using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Producto
    {
        [Key]
        [Required]
        public int ProductoId { get; set; }
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Clasificacion Producto")]
        public int ClasificacionProductoId { get; set; }
        [Required]
        [Display(Name = "Unidad Medida")]
        public int UnidadMedidaId { get; set; }
        [Required]
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaIngreso { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public bool Estado { get; set; }
        public ClasificacionProducto ClasificacionProducto { get; set; }
        public Unidad Unidad { get; set; }
    }
}