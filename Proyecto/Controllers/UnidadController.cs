using Proyecto.Database;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class UnidadController : Controller
    {
        private TiendaContext context;
        public UnidadController()
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
            var producto = context.unidads.ToList();
            return View(producto);
        }
        public ActionResult Nuevo()
        {
            var unidades = new Unidad();
            return View("UnidadForm", unidades);
        }
        public ActionResult Editar(int id)
        {
            var clasificacionesInDb = context.unidads.SingleOrDefault(c => c.UnidadMedidaId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View("UnidadForm", clasificacionesInDb);
        }
        public ActionResult Eliminar(int id)
        {
            var clasificacionesInDb = context.unidads.SingleOrDefault(c => c.UnidadMedidaId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View(clasificacionesInDb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            var clasificacionesInDb = context.unidads.SingleOrDefault(c => c.UnidadMedidaId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            context.unidads.Remove(clasificacionesInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Guardar(Unidad unidades)
        {
            if (!ModelState.IsValid)
                return View("UnidadForm", unidades);

            if (unidades.UnidadMedidaId == 0)
            {
                context.unidads.Add(unidades);
            }
            else
            {
                var clasificacionesInDb = context.unidads.SingleOrDefault(c => c.UnidadMedidaId == unidades.UnidadMedidaId);
                clasificacionesInDb.Descripcion = unidades.Descripcion;
                clasificacionesInDb.Codigo = unidades.Codigo;
                clasificacionesInDb.Estado = unidades.Estado;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detalles(int id)
        {
            var clasificacionesInDb = context.unidads.SingleOrDefault(c => c.UnidadMedidaId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View(clasificacionesInDb);
        }

    }
}