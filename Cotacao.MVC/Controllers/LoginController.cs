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
                throw new System.Exception();
            }
            else
            {
                ViewBag.Error = true;
                ViewData["Title"] = "Login";
                return View();
            }
        }
    }
}