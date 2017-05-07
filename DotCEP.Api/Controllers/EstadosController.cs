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
		public HttpResponseMessage ObterSigla([FromUri]int id)
		{
			//EX: http://localhost:8080/api/v1/estados/obterSigla/?id=43

			var result = Localidades.Estado.ObterSiglaDoEstado(id);

			if (result.Length == 2)
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
			}
			else
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}
		}

		[HttpGet]
		[Route("obterSigla")]
		public HttpResponseMessage ObterSigla([FromUri] string Estado)
		{
			//EX: http://localhost:8080/api/v1/estados/obterSigla/?id=Rio Grade do SUl

			var result = Localidades.Estado.ObterSiglaDoEstado(Estado); ;

			if (result.Length == 2)
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
			}
			else
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}
		}
	}
}