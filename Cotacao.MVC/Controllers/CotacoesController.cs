using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;

namespace Cotacao.MVC.Controllers
{
    public class CotacoesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Informações";
            return View();
        }
    }
}