using Microsoft.AspNetCore.Mvc;

namespace Cotacao.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index(string nome)
        {
             ViewData["Title"] = "Início";
             ViewData["NomeUsuario"] = nome;
             
            return View();
        }
    }
}