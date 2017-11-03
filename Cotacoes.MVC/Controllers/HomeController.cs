using Microsoft.AspNetCore.Mvc;

namespace Cotacoes.MVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Cotacao", new { area = "Moedas" });
        }
    }
}