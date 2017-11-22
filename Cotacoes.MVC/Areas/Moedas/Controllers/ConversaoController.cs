using Microsoft.AspNetCore.Mvc;
using Cotacoes.Model;

namespace Cotacoes.MVC.Areas.Moedas.Controllers
{
    [Area("Moedas")]
    public class ConversaoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Converções";
            ViewBag.Data = TempData["Data"];
            ViewBag.Valor = TempData["Valor"];

            return View("Index");
        }

        [HttpPost]
        public IActionResult ConverterParaDolar([FromForm]string Moeda, [FromForm]decimal Montante)
        {
            var result = ConversaoService.ConverterParaDolar(Montante, Moeda);

            TempData["Data"] = result.DataConsulta;
            TempData["Valor"] = result.ValorConvertido;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ConverterParaReal([FromForm]string Moeda, [FromForm]decimal Montante)
        {
            var result = ConversaoService.ConverterParaReais(Montante, Moeda);

            TempData["Data"] = result.DataConsulta;
            TempData["Valor"] = result.ValorConvertido;

            return RedirectToAction("Index");
        }
    }
}