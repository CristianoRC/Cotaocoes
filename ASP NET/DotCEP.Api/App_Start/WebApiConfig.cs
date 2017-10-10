using System.Web.Http;

namespace DotCEP.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/v1/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			//Colocando o JSON como padrão  --> Basta remover o XML.
			config.Formatters.Remove(config.Formatters.XmlFormatter);

			//Identando o JSON.
			config.Formatters.JsonFormatter.Indent = true;
		}
	}
}
