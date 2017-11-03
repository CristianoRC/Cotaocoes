using Microsoft.AspNetCore.Mvc;

namespace Cotacoes.MVC.Areas.Moedas.Controllers
{
    [Area("Moedas")]
    public class CotacaoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Informações";
            return View();
        }
    }
}