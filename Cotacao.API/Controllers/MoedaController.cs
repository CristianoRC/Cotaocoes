using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;
using System.Collections.Generic;

namespace Cotacao.API.Controllers
{
    [Route("api/[Controller]")]
    public class MoedaController : Controller
    {
        [HttpGet("{sigla}")]
        public Moeda ObterInformacoes(string sigla)
        {
            return new Moeda(sigla);

        }

        [HttpGet("listar")]
        public IEnumerable<Moeda> Listar()
        {
            return Moeda.Listar();
        }
    }
}