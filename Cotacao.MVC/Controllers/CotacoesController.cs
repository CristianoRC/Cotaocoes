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

        public IActionResult Convercoes()
        {
            ViewData["Title"] = "Converções";
            ViewBag.Data = TempData["Data"];
            ViewBag.Valor = TempData["Valor"];

            return View("Convercoes");
        }

        [Route("Cotacoes/ConverterParaDolar/")]
        [HttpPost]
        public IActionResult ConverterDolar([FromForm]string Moeda, [FromForm]double Montante)
        {
            var result = Convercao.ConverterParaDolar(Montante, Moeda);

            TempData["Data"] = result.DataConsulta;
            TempData["Valor"] = System.Math.Round(result.ValorConvertido, 4);

            return RedirectToAction("Convercoes");
        }

        [Route("Cotacoes/ConverterParaReal/")]
        [HttpPost]
        public IActionResult ConverterReal([FromForm]string Moeda, [FromForm]double Montante)
        {
            var result = Convercao.ConverterParaReais(Montante, Moeda);

            TempData["Data"] = result.DataConsulta;
            TempData["Valor"] = System.Math.Round(result.ValorConvertido, 4);

            return RedirectToAction("Convercoes");
        }
    }
}