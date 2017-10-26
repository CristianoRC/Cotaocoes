using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;

namespace Cotacao.MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            ViewBag.Error = false;
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]string Email, [FromForm]string Senha)
        {
            if (Usuario.Autenticar(Email, Senha))
            {
                return RedirectToAction("Index", "Home", new { area = "admin" });
                //TODO: Implementar sistema de controle de acesso em páginas específicas
            }
            else
            {
                ViewBag.Error = true;
                ViewData["Title"] = "Login";
                return View();
            }
        }

        public IActionResult Cadastro()
        {
            ViewData["Title"] = "Cadastro usuário";

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro([FromForm]string Nome, [FromForm]string Email, [FromForm]string Senha)
        {
            try
            {
                ViewData["Title"] = "Cadastro usuário";

                Usuario _usuario = new Usuario();

                _usuario.Nome = Nome;
                _usuario.Email = Email;
                _usuario.Senha = Senha;

                Usuario.Cadastrar(_usuario);

                return View();
            }
            catch (System.Exception e)
            {
                ViewData["Title"] = "Cadastro usuário";
                ViewBag.Error = true;
                ViewBag.MensageErro = e.Message;

                return View();
            }
        }
    }
}