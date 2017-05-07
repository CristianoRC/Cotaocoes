using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace DotCEP.Api.Controllers
{
	[RoutePrefix("api/v1/estados")]
	public class EstadosController : ApiController
	{
		[HttpGet]
		[Route("Lista")]

		public IEnumerable<Localidades.Estado> ObterLista()
		{
			//EX:http://localhost:8080/api/v1/estados/Lista

			return Localidades.Estado.ObterListaDeEstados(); ;
		}

		[HttpGet]
		[Route("Siglas")]
		public HttpResponseMessage ObterSigla([FromUri]int id)
		{
			//EX: http://localhost:8080/api/v1/estados/Sigla/?id=43

			try
			{
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
			catch
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}


		}

		[HttpGet]
		[Route("Siglas")]
		public HttpResponseMessage ObterSigla([FromUri] string Estado)
		{
			//EX: http://localhost:8080/api/v1/estados/Sigla/?id=Rio Grade do SUl

			try
			{
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
			catch
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}
		}
	}
}