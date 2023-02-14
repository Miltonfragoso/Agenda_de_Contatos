using Microsoft.AspNetCore.Mvc;

namespace AgendaContatos.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
