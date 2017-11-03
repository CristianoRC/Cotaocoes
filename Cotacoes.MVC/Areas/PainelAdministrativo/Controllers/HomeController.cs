using Cotacoes.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cotacoes.MVC.Areas.PainelAdministrativo.Controllers
{
    [Area("PainelAdministrativo")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Início";
            ViewData["NomeUsuario"] = TempData["Nome"];

            return View();
        }
    }
}