using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;
using System.Collections.Generic;

namespace Cotacao.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class MoedasController : Controller
    {
        [HttpGet("{sigla}")]
        public Moeda ObterInformacoes(string sigla)
        {
            return new Moeda(sigla);
        }

        [HttpGet]
        public IEnumerable<Moeda> Listar()
        {
            return Moeda.Listar();
        }
    }
}