using Microsoft.AspNetCore.Mvc;

namespace SAGRISA.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
