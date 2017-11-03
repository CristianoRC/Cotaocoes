using Microsoft.AspNetCore.Mvc;
using Cotacao.Model;

namespace Cotacao.MVC.Areas.Autenticacao.Controllers
{
    [Area("Usuarios")]
    public class AutenticacaoController : Controller
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
            if (Model.Usuario.Autenticar(Email, Senha))
            {
                TempData["Nome"] = Usuario.ObterNome(Email);
                return RedirectToAction("Index", "Home", new { area = "PainelAdministrativo"});
                //TODO: Implementar sistema de controle de acesso em páginas específicas
            }
            else
            {
                ViewBag.Error = true;
                ViewBag.UltimoEmail = Email;
                ViewData["Title"] = "Login";
                
                return View();
            }
        }   
    }
}