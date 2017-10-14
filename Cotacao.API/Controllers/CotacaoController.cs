using Microsoft.AspNetCore.Mvc;
using System;
using Cotacao.Model;

namespace Cotacao.API.Controllers
{
    [Route("api/[Controller]")]
    public class CotacaoController : Controller
    {

        [HttpGet("ObterCotacao/{siglaMoeda}")]
        public CotacaoMoeda ObterCotacao(string siglaMoeda)
        {
            return new CotacaoMoeda(siglaMoeda);
        }

        [HttpGet("Data")]
        public DateTime Data()
        {
            return CotacaoMoeda.ObterDataUltumaCotacao();
        }
    }
}