using Microsoft.AspNetCore.Mvc;
using Cotacoes.Model;
using System.Collections.Generic;

namespace Cotacoes.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class MoedaController : Controller
    {
        [HttpGet("{sigla}")]
        public Moeda ObterInformacoes(string sigla)
        {
            return new Moeda(sigla);
        }

        [HttpGet]
        public IEnumerable<Moeda> Listar()
        {
            return MoedaService.Listar();
        }
    }
}