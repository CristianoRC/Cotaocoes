using Microsoft.AspNetCore.Mvc;
using Cotacoes.Model;

namespace Cotacoes.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class ConversoesController : Controller
    {
        [HttpGet("Dolar/{valor}/{moeda}")]
        public Conversao ConverterParaDolar(double valor, string moeda)
        {
            return ConversaoService.ConverterParaDolar(valor, moeda);
        }

        [HttpGet("Real/{valor}/{moeda}")]
        public Conversao ConverterParaReal(double valor, string moeda)
        {
            return ConversaoService.ConverterParaReais(valor, moeda);
        }
    }
}