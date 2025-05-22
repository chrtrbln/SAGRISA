using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAGRISA.Data;
using SAGRISA.Models;
using SAGRISA.ViewModels;

namespace SAGRISA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SagrisaDbContext db;

        public HomeController(ILogger<HomeController> logger, SagrisaDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [Authorize]
        public ActionResult Index()
        {
            var vendedorId = Convert.ToInt32(HttpContext.Session.GetString("VendedorID"));
            var cotizacionesRecientes = db.Cotizaciones
                .Where(c => c.CodVendedor == vendedorId)
                .OrderByDescending(c => c.FechaHora)
                .Take(5)
                .Select(c => new CotizacionListViewModel
                {
                    CodCotizacion = c.CodCotizacion,
                    Cliente = c.CodClienteNavigation.NomCliente,
                    Fecha = (DateTime)c.FechaHora,
                    Total = (decimal)c.PrecioTotal,
                    Estado = c.Estado
                })
                .ToList();

            return View(cotizacionesRecientes);
        }
    }
}
