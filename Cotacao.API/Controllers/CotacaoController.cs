using Microsoft.AspNetCore.Mvc;
using System;
using Cotacao.Model;

namespace Cotacao.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class CotacoesController : Controller
    {
        [HttpGet("{siglaMoeda}")]
        public CotacaoMoeda ObterCotacao(string siglaMoeda)
        {
            return new CotacaoMoeda(siglaMoeda.ToUpper());
        }

        [HttpGet("{siglaMoeda}/taxacompra")]
        public double ObterTaxaCompra(string siglaMoeda)
        {
            return CotacaoMoeda.ObterTaxaCompra(siglaMoeda.ToUpper());
        }

        [HttpGet("{siglaMoeda}/taxavenda")]
        public double ObterTaxaVenda(string siglaMoeda)
        {
            return CotacaoMoeda.ObterTaxaVenda(siglaMoeda.ToUpper());
        }

        [HttpGet("{siglaMoeda}/paridadecompra")]
        public double ObterPridadeCompra(string siglaMoeda)
        {
            return CotacaoMoeda.ObterParidadeCompra(siglaMoeda.ToUpper());
        }

        [HttpGet("{siglaMoeda}/paridadevenda")]
        public double ObterPridadeVenda(string siglaMoeda)
        {
            return CotacaoMoeda.ObterParidadeVenda(siglaMoeda.ToUpper());
        }

        [HttpGet("Data")]
        public DateTime Data()
        {
            return CotacaoMoeda.ObterDataUltumaCotacao();
        }
    }
}