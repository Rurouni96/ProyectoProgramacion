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
    public class ClienteController : Controller
    {
        private TiendaContext context;
        public ClienteController()
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
            var clientes = context.clientes.Include(c => c.ClasificacionCliente)
                                           .ToList();
            return View(clientes);
        }
        public ActionResult Nuevo()
        {
            var cliente = new Cliente();
            var clasificacionClientes = context.clasificacionClientes.Where(c => c.Estado == true).ToList();
            var viewModel = new ClienteFormViewModel()
            {
                Cliente = cliente,
                ClasificacionClientes = clasificacionClientes
            };
            return View("ClienteForm", viewModel);
        }
        public ActionResult Editar(int clienteid)
        {
            var cliente = context.clientes.SingleOrDefault(c => c.ClienteId == clienteid);
            if (cliente == null)
                return HttpNotFound();

            var clasificacionClientes = context.clasificacionClientes.Where(c => c.Estado == true).ToList();
            var viewModel = new ClienteFormViewModel()
            {
                Cliente = cliente,
                ClasificacionClientes = clasificacionClientes
            };
            return View("ClienteForm", viewModel);
        }
        [HttpPost]
        public ActionResult Guardar(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                cliente.FechaIngreso = DateTime.Now;

            }
            else
            {
                cliente.FechaIngreso = DateTime.Now;
            }
            if (cliente.ClasificacionId == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar una clasificacion del cliente");
            }

            if (!ModelState.IsValid)
            {
                var clasificacionClientes = context.clasificacionClientes.Where(c => c.Estado == true).ToList();
                var viewModel = new ClienteFormViewModel()
                {
                    Cliente = cliente,
                    ClasificacionClientes = clasificacionClientes
                };
                return View("ClienteForm", viewModel);
            }

            if (cliente.ClienteId == 0)
            {
                context.clientes.Add(cliente);
            }
            else
            {
                var clienteInDb = context.clientes.SingleOrDefault(c => c.ClienteId == cliente.ClienteId);

                clienteInDb.Nombres = cliente.Nombres;
                clienteInDb.Apellidos = cliente.Apellidos;
                clienteInDb.PorcentajeDescuento = cliente.PorcentajeDescuento;
                clienteInDb.Estado = cliente.Estado;
                clienteInDb.ClasificacionId = cliente.ClasificacionId;

            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detalles(int clienteid)
        {
            var clienteInDb = context.clientes.Include(c => c.ClasificacionCliente)
                                              .SingleOrDefault(c => c.ClienteId == clienteid);
            if (clienteInDb == null)
                return HttpNotFound();

            return View(clienteInDb);
        }



        public ActionResult Eliminar(int clienteid)
        {
            var clienteInDb = context.clientes.SingleOrDefault(c => c.ClienteId == clienteid);
            if (clienteInDb == null)
                return HttpNotFound();

            return View(clienteInDb);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int clienteid)
        {
            var clienteInDb = context.clientes.SingleOrDefault(c => c.ClienteId == clienteid);
            if (clienteInDb == null)
                return HttpNotFound();

            context.clientes.Remove(clienteInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}