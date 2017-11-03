using Microsoft.AspNetCore.Mvc;
using System;
using Cotacao.Model;
using System.Collections.Generic;

namespace Cotacao.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class CotacoesController : Controller
    {
        [HttpGet]
        public IEnumerable<CotacaoMoeda> Listar()
        {
            return CotacaoMoeda.ListarCotacoes();
        }

        [HttpGet("{siglaMoeda}")]
        public CotacaoMoeda ObterCotacao(string siglaMoeda)
        {
            return new CotacaoMoeda(siglaMoeda.ToUpper());
        }

        [HttpGet("Data")]
        public DateTime Data()
        {
            return CotacaoMoeda.ObterDataUltumaCotacao();
        }
    }
}