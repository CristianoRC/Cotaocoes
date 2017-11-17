using Microsoft.AspNetCore.Mvc;
using System;
using Cotacoes.Model;
using System.Collections.Generic;

namespace Cotacoes.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class CotacoesController : Controller
    {
        [HttpGet]
        public IEnumerable<Cotacao> Listar()
        {
            var teste = CotacaoService.ListarCotacoes();
            return teste;
        }

        [HttpGet("Moeda/{siglaMoeda}")]
        public Cotacao ObterCotacao(string siglaMoeda)
        {
            return new Cotacao(siglaMoeda);
        }

        [HttpGet("Data")]
        public DateTime Data()
        {
            return CotacaoService.ObterDataUltumaCotacao();
        }
    }
}