using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Pedido
    {
        [Key]
        [Required]
        public int PedidoId { get; set; }
        [Required]
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public decimal DescuentoTotal { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public bool Estado { get; set; }
        public Cliente Cliente { get; set; }
    }
}