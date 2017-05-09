using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Web.Http;

namespace DotCEP.Api.Controllers
{
	public class EstadoController : ApiController
	{
		[Route("api/v1/Estado/Lista")]
		public IEnumerable<Localidades.Estado> GetLista()
		{
			//EX:http://localhost:8080/api/v1/Estado/Lista

			return Localidades.Estado.ObterListaDeEstados(); ;
		}

		[Route("api/v1/Estado/Sigla")]
		public HttpResponseMessage GetSigla([FromUri] string Estado)
		{
			//EX: http://localhost:8080/api/v1/Estado/Sigla/?Estado=Rio Grande do Sul

			try
			{
				var result = Localidades.Estado.ObterSiglaDoEstado(Estado); ;

				if (result.Length == 2)
				{
					return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
				}
				else
				{
					return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
				}
			}
			catch
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}
		}

		[Route("api/v1/Estado/Sigla")]
		public HttpResponseMessage GetSigla([FromUri]int Codigo)
		{
			//EX: http://localhost:8080/api/v1/Estado/Sigla/?Codigo=43

			try
			{
				var result = Localidades.Estado.ObterSiglaDoEstado(Codigo);

				if (result.Length == 2)
				{
					return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
				}
				else
				{
					return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
				}
			}
			catch
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}


		}

		[Route("api/v1/Estado/Codigo/{Sigla}")]
		public HttpResponseMessage GetCodigo([FromUri] string Sigla)
		{
			//EX: http://localhost:8080/api/v1/Estado/Sigla/?Sigla=RS

			try
			{
				var result = Localidades.Estado.ObterCodigoDoEstado(Sigla);

				return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
			}
			catch
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}
		}

		[Route("api/v1/Estado/Nome")]
		public HttpResponseMessage GetNome([FromUri] int Codigo)
		{
			//EX: http://localhost:8080/api/v1/estado/nome/?Codigo=43

			try
			{
				var result = Localidades.Estado.ObterNomeDoEstado(Codigo);

				return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
			}
			catch
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}
		}

		[Route("api/v1/Estado/Nome")]
		public HttpResponseMessage GetNome([FromUri] string Sigla)
		{
			if (Sigla.Length == 2)
			{
				//EX: http://localhost:8080/api/v1/estado/nome/?Sigla=RS
				try
				{
					var result = Localidades.Estado.ObterNomeDoEstado(Sigla);

					return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
				}
				catch
				{
					return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
				}
			}
			else
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Sigla inválida");
			}
		}
	}
}