using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAGRISA.Data;
using SAGRISA.Models;
using SAGRISA.ViewModels;

namespace SAGRISA.Controllers
{
    public class ClientesController : Controller
    {
        private readonly SagrisaDbContext db;

        public ClientesController(SagrisaDbContext context)
        {
            db = context;
        }

        // GET: Clientes
        [Authorize]
        public ActionResult Index()
        {
            var clientes = db.Clientes.ToList();
            return View(clientes);
        }

        // GET: /Clientes/Create
        [Authorize]
        public ActionResult Create()
        {
            var model = new ClienteViewModel
            {
                Vendedor = HttpContext.Session.GetString("VendedorID")
            };

            return View(model);
        }

        // POST: /Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente
                {
                    NomCliente = model.NomCliente,
                    Ciudad = model.Ciudad,
                    Correo = model.Correo,
                    Vendedor = Convert.ToInt32(model.Vendedor),
                };

                db.Clientes.Add(cliente);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Clientes/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var cliente = db.Clientes.Find(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            var model = new ClienteViewModel
            {
                CodCliente = cliente.CodCliente,
                NomCliente = cliente.NomCliente,
                Ciudad = cliente.Ciudad,
                Correo = cliente.Correo,
                Vendedor = cliente.Vendedor.ToString()
            };

            return View(model);
        }

        // POST: /Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = db.Clientes.Find(model.CodCliente);

                if (cliente == null)
                {
                    return HttpNotFound();
                }

                cliente.NomCliente = model.NomCliente;
                cliente.Ciudad = model.Ciudad;
                cliente.Correo = model.Correo;

                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Clientes/AutoComplete
        [HttpGet]
        public JsonResult AutoComplete(string term)
        {
            var clientes = db.Clientes
                .Where(c => c.NomCliente.Contains(term))
                .Select(c => new {
                    id = c.CodCliente,
                    label = c.NomCliente,
                    value = c.NomCliente,
                    correo = c.Correo,
                    ciudad = c.Ciudad
                })
                .Take(10)
                .ToList();

            return Json(clientes, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
