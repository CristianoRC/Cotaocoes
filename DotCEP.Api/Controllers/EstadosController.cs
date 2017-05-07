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
			return Localidades.Estado.ObterListaDeEstados(); ;
		}

		[HttpGet]
		[Route("obterSigla")]
		public HttpResponseMessage obterSigla(int id)
		{
			var result = Localidades.Estado.ObterSiglaDoEstado(id);

			return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
		}
	}
}