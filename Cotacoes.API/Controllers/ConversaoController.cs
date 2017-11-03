using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;

namespace Cotacao.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class ConversoesController : Controller
    {
        [HttpGet("Dolar/{valor}/{moeda}")]
        public Convercao ConverterParaDolar(double valor, string moeda)
        {
            return Convercao.ConverterParaDolar(valor, moeda);
        }

        [HttpGet("Real/{valor}/{moeda}")]
        public Convercao ConverterParaReal(double valor, string moeda)
        {
            return Convercao.ConverterParaReais(valor, moeda);
        }
    }
}