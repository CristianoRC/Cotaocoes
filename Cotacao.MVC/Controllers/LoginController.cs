using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;

namespace Cotacao.MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [HttpPost]
        public string Autenticar([FromForm]string Email, [FromForm]string Senha)
        {
            if (Usuario.Autenticar(Email,Senha))
            {
                return "Logado comm sucesso!";
            }
            else
            {
                return "Login ou senha inválidos!";
            }
        }
    }
}