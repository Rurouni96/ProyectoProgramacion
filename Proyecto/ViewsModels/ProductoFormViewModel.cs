using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.ViewsModels
{
    public class ProductoFormViewModel
    {
        public Producto Producto { get; set; }
        public List<ClasificacionProducto> ClasificacionProductos { get; set; }
        public List<Unidad> Unidads { get; set; }
    }

}
