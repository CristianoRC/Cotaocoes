using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;

namespace Cotacao.MVC.Areas.Moedas.Controllers
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