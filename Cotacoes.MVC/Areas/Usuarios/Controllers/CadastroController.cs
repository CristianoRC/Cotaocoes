using Cotacao.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cotacao.MVC.Areas.Usuarios.Controllers
{
    [Area("Usuarios")]
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Cadastro usuário";

            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm]string Nome, [FromForm]string Email, [FromForm]string Senha)
        {
            try
            {
                ViewData["Title"] = "Cadastro usuário";

                Usuario _usuario = new Usuario();

                _usuario.Nome = Nome;
                _usuario.Email = Email;
                _usuario.Senha = Senha;

                Usuario.Cadastrar(_usuario);

                ViewBag.UltimoEmail = Email;

                return RedirectToAction("Index","Autenticacao");
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