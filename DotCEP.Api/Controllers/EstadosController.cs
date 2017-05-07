using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace DotCEP.Api.Controllers
{
	[RoutePrefix("api/v1/estados")]
	public class EstadosController : ApiController
	{
		[HttpGet]
		[Route("obterLista")]

		public IEnumerable<Localidades.Estado> ObterLista()
		{
			//EX:http://localhost:8080/api/v1/estados/obterLista

			return Localidades.Estado.ObterListaDeEstados(); ;
		}

		[HttpGet]
		[Route("obterSigla")]
		public string ObterSigla([FromUri]int id)
		{
			//EX: http://localhost:8080/api/v1/estados/obterSigla/?id=43

			return Localidades.Estado.ObterSiglaDoEstado(id);
		}
	}
}