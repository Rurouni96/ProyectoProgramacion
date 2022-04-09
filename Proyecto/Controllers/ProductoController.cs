using Proyecto.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Proyecto.Models;
using Proyecto.ViewsModels;

namespace Proyecto.Controllers
{
    public class ProductoController : Controller
    {
        private TiendaContext context;

        public ProductoController()
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
            var productos = context.productos.Include(c => c.ClasificacionProducto)
                                           .ToList();
            return View(productos);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            var producto = new Producto();
            var unidad = context.unidads.Where(c => c.Estado == true).ToList();
            var clasificacionProductos = context.clasificacionProductos.Where(c => c.Estado == true).ToList();
            var viewModel = new ProductoFormViewModel()
            {
                Producto = producto,
                ClasificacionProductos = clasificacionProductos,
                Unidads = unidad
            };
            return View("ProductoForm", viewModel);
        }
        public ActionResult Editar(int productoid)
        {
            var producto = context.productos.SingleOrDefault(c => c.ProductoId == productoid);
            if (producto == null)
                return HttpNotFound();

            var unidad = context.unidads.Where(c => c.Estado == true).ToList();
            var clasificacificacionProductos = context.clasificacionProductos.Where(c => c.Estado == true).ToList();
            var viewModel = new ProductoFormViewModel()
            {
                Producto = producto,
                ClasificacionProductos = clasificacificacionProductos,
                Unidads = unidad
            };
            return View("ProductoForm", viewModel);
        }
        public ActionResult Detalles(int productoid)

        {

            var productoInDb = context.productos.Include(c => c.ClasificacionProducto)
                                              .SingleOrDefault(c => c.ProductoId == productoid);
            if (productoInDb == null)
                return HttpNotFound();

            return View(productoInDb);
        }

        [HttpPost]
        public ActionResult Guardar(Producto producto)
        {
            if (producto.ProductoId == 0)
            {
                producto.FechaIngreso = DateTime.Now;

            }
            else
            {
                producto.FechaIngreso = DateTime.Now;
            }
            if (producto.ClasificacionProductoId == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar una clasificacion del Producto");
            }

            if (producto.ProductoId == 0)
            {
                producto.FechaIngreso = DateTime.Now;

            }
            else
            {
                producto.FechaIngreso = DateTime.Now;
            }
            if (producto.UnidadMedidaId == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar una clasificacion del Producto");
            }

            if (!ModelState.IsValid)
            {
                var unidad = context.unidads.Where(c => c.Estado == true).ToList();
                var clasificacionProductos = context.clasificacionProductos.Where(c => c.Estado == true).ToList();
                var viewModel = new ProductoFormViewModel()
                {
                    Producto = producto,
                    ClasificacionProductos = clasificacionProductos,
                    Unidads = unidad


                };
                return View("ProductoForm", viewModel);
            }

            if (producto.ProductoId == 0)
            {
                context.productos.Add(producto);
            }
            else
            {
                var productoInDb = context.productos.SingleOrDefault(c => c.ProductoId == producto.ProductoId);


                productoInDb.Codigo = producto.Codigo;
                productoInDb.Descripcion = producto.Descripcion;
                productoInDb.UnidadMedidaId = producto.UnidadMedidaId;
                productoInDb.ClasificacionProductoId = producto.ClasificacionProductoId;
                productoInDb.FechaIngreso = producto.FechaIngreso;
                productoInDb.Precio = producto.Precio;
                productoInDb.Estado = producto.Estado;


            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int productoid)
        {
            var productoInDb = context.productos.SingleOrDefault(c => c.ProductoId == productoid);
            if (productoInDb == null)
                return HttpNotFound();

            return View(productoInDb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int productoid)
        {
            var productoInDb = context.productos.SingleOrDefault(c => c.ProductoId == productoid);
            if (productoInDb == null)
                return HttpNotFound();

            context.productos.Remove(productoInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}