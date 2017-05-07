using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace DotCEP.Api.Controllers
{
	[RoutePrefix("api/v1")]
	public class EstadosController : ApiController
	{
		[HttpGet]
		[Route("obterEstados")]
		public HttpResponseMessage ObterEstados()
		{
			var result = Localidades.Estado.ObterListaDeEstados();

			return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
		}
	}
}