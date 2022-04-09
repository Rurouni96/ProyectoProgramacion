using Proyecto.Database;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Controllers
{
    public class ClasificacionProductoController : Controller
    {
        private TiendaContext context;
        public ClasificacionProductoController()
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
            var producto = context.clasificacionProductos.ToList();
            return View(producto);
        }
        public ActionResult Nuevo()
        {
            var clasificacionProducto = new ClasificacionProducto();
            return View("ClasificacionProductoForm", clasificacionProducto);
        }
        public ActionResult Editar(int id)
        {
            var clasificacionesInDb = context.clasificacionProductos.SingleOrDefault(c => c.ClasificacionProductoId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View("ClasificacionProductoForm", clasificacionesInDb);
        }


        public ActionResult Detalles(int id)
        {
            var clasificacionesInDb = context.clasificacionProductos.SingleOrDefault(c => c.ClasificacionProductoId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View(clasificacionesInDb);
        }
        public ActionResult Eliminar(int id)
        {
            var clasificacionesInDb = context.clasificacionProductos.SingleOrDefault(c => c.ClasificacionProductoId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            return View(clasificacionesInDb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            var clasificacionesInDb = context.clasificacionProductos.SingleOrDefault(c => c.ClasificacionProductoId == id);
            if (clasificacionesInDb == null)
                return HttpNotFound();

            context.clasificacionProductos.Remove(clasificacionesInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }




        [HttpPost]
        public ActionResult Guardar(ClasificacionProducto clasificacionProducto)
        {
            if (!ModelState.IsValid)
                return View("ClasificacionProductoForm", clasificacionProducto);

            if (clasificacionProducto.ClasificacionProductoId == 0)
            {
                context.clasificacionProductos.Add(clasificacionProducto);
            }
            else
            {
                var clasificacionesInDb = context.clasificacionProductos.SingleOrDefault(c => c.ClasificacionProductoId == clasificacionProducto.ClasificacionProductoId);
                clasificacionesInDb.Descripcion = clasificacionProducto.Descripcion;
                clasificacionesInDb.Codigo = clasificacionProducto.Codigo;
                clasificacionesInDb.Estado = clasificacionProducto.Estado;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}