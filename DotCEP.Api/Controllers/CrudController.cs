using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;


namespace DotCEP.Api.Controllers
{

	public class CrudController : ApiController
	{
		//Url - http://localhost:8080/api/Crud/

		//Tabela para simulação de CRUD.
		List<Pessoa> Listapessoas = new List<Pessoa>();

		public CrudController()
		{
			Listapessoas.Add(new Pessoa { Nome = "Cristiano Cunha", Idade = 18 });
			Listapessoas.Add(new Pessoa { Nome = "Cristian Cunha", Idade = 18 });
			Listapessoas.Add(new Pessoa { Nome = "Cunha", Idade = 19 });
		}

		public HttpResponseMessage Get()
		{
			return Request.CreateResponse(System.Net.HttpStatusCode.OK, Listapessoas.ToArray());
		}
	}
}
