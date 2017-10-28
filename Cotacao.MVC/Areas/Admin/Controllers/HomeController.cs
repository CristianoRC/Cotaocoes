using Cotacao.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cotacao.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
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