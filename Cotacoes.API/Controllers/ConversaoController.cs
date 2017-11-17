using Microsoft.AspNetCore.Mvc;
using Cotacoes.Model;

namespace Cotacoes.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class ConversoesController : Controller
    {
        [HttpGet("Dolar/{moeda}/{valor}")]
        public Conversao ConverterParaDolar(string moeda, double valor)
        {
            return ConversaoService.ConverterParaDolar(valor, moeda);
        }

        [HttpGet("Real/{moeda}/{valor}")]
        public Conversao ConverterParaReal(string moeda, double valor)
        {
            return ConversaoService.ConverterParaReais(valor, moeda);
        }
    }
}