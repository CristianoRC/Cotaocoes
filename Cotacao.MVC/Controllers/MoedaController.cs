using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;
using System.Collections.Generic;

namespace Cotacao.MVC.Controllers
{
    public class MoedaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Moedas";

            return View();
        }

        public IActionResult Sobre(int Id)
        {
            
            var _moeda = new Moeda(Id);
            ViewBag.Moeda = _moeda;
            ViewData["Title"] = $"{_moeda.Sigla}";

            return View();
        }
    }
}