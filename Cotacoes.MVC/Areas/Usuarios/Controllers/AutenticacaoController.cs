using Microsoft.AspNetCore.Mvc;
using Cotacoes.Model;

namespace Cotacoes.MVC.Areas.Autenticacao.Controllers
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
            if (UsuarioService.Autenticar(Email, Senha))
            {
                TempData["Nome"] = UsuarioService.ObterNome(Email);
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