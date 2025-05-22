using Microsoft.AspNetCore.Mvc;
using SAGRISA.Data;
using SAGRISA.ViewModels;

namespace SAGRISA.Controllers
{
    public class AccountController : Controller
    {
        private readonly SagrisaDbContext db;

        public AccountController (SagrisaDbContext db)
        {
            this.db = db;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = db.SagusuariosMovils.FirstOrDefault(u => u.Pin == model.Username);

                if (usuario != null)
                {
                    HttpContext.Session.SetString("UserID", usuario.Pin);
                    HttpContext.Session.SetString("UserName", usuario.Nombre);
                    HttpContext.Session.SetString("VendedorID", usuario.CodVendedor.ToString());

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
