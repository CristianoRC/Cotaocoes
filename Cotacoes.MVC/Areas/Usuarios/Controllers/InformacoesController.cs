using Cotacoes.Model;
using Microsoft.AspNetCore.Mvc;

namespace Cotacoes.MVC.Areas.Usuarios.Controllers
{
    [Area("Usuarios")]
    public class InformacoesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Informações usuário";
            return View();
        }

        [HttpPut]
        public IActionResult Editar()
        {
            ViewData["Title"] = "Editar usuário";
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(string email)
        {
            UsuarioService.Deletar(email);

            return View();
        }
    }
}