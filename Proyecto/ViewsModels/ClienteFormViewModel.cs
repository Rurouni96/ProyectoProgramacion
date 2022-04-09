using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.ViewsModels
{
    public class ClienteFormViewModel
    {
        public Cliente Cliente { get; set; }
        public List<ClasificacionCliente> ClasificacionClientes { get; set; }
    }
}