using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;

namespace Cotacao.MVC.Areas.Moedas.Controllers
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
        public IActionResult ConverterParaDolar([FromForm]string Moeda, [FromForm]double Montante)
        {
            var result = Convercao.ConverterParaDolar(Montante, Moeda);

            TempData["Data"] = result.DataConsulta;
            TempData["Valor"] = System.Math.Round(result.ValorConvertido, 5);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ConverterParaReal([FromForm]string Moeda, [FromForm]double Montante)
        {
            var result = Convercao.ConverterParaReais(Montante, Moeda);

            TempData["Data"] = result.DataConsulta;
            TempData["Valor"] = System.Math.Round(result.ValorConvertido, 5);

            return RedirectToAction("Index");
        }
    }
}