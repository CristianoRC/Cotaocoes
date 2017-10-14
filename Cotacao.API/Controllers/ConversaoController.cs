using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;

namespace Cotacao.API.Controllers
{
    [Route("api/[Controller]")]
    public class ConversaoController : Controller
    {
        [HttpGet("ConverterParaDolar/{valor}/{moeda}")]
        public Convercao ConverterParaDolar(double valor, string moeda)
        {
            return Convercao.ConverterParaDolar(valor, moeda);
        }

        [HttpGet("ConverterParaReal/{valor}/{moeda}")]
        public Convercao ConverterParaReal(double valor, string moeda)
        {
            return Convercao.ConverterParaReais(valor, moeda);
        }
    }
}