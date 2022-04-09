using Proyecto.Database;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ClasificacionClienteController : Controller
    {
        private TiendaContext context;
        public ClasificacionClienteController()
        {
            context = new TiendaContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }
        public ActionResult Index()
        {
            // mostrar todos los registros de las clasificaciones
            var producto = context.clasificacionClientes.ToList();
            return View(producto);
        }
        public ActionResult Nuevo()
        {
            var clasificacionCliente = new ClasificacionCliente();
            return View("ClasificacionClienteForm", clasificacionCliente);
        }
        public ActionResult Editar(int id)
        {
            var clasificacionesInDb = context.clasificacionClientes.SingleOrDefault(c => c.ClasificacionId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View("ClasificacionClienteForm", clasificacionesInDb);
        }
        public ActionResult Detalles(int id)
        {
            var clasificacionesInDb = context.clasificacionClientes.SingleOrDefault(c => c.ClasificacionId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View(clasificacionesInDb);
        }
        public ActionResult Eliminar(int id)
        {
            var clasificacionesInDb = context.clasificacionClientes.SingleOrDefault(c => c.ClasificacionId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View(clasificacionesInDb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            var clasificacionesInDb = context.clasificacionClientes.SingleOrDefault(c => c.ClasificacionId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            context.clasificacionClientes.Remove(clasificacionesInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Guardar(ClasificacionCliente clasificacionClientes)
        {
            if (!ModelState.IsValid)
                return View("ClasificacionClienteForm", clasificacionClientes);

            if (clasificacionClientes.ClasificacionId == 0)
            {
                context.clasificacionClientes.Add(clasificacionClientes);
            }
            else
            {
                var clasificacionesInDb = context.clasificacionClientes.SingleOrDefault(c => c.ClasificacionId == clasificacionClientes.ClasificacionId);
                clasificacionesInDb.Descripcion = clasificacionClientes.Descripcion;
                clasificacionesInDb.Codigo = clasificacionClientes.Codigo;
                clasificacionesInDb.Estado = clasificacionClientes.Estado;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}