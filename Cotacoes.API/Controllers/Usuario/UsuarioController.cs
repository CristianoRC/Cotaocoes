using System.Collections.Generic;
using Cotacoes.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cotacoes.API.Controllers
{
    [Route("api/v1/[Controller]")]
    [Authorize("Bearer")]
    public class UsuarioController : Controller
    {

        [HttpGet("{email}")]
        public Usuario ObterInformacoes(string email)
        {
            return UsuarioService.ObterInformacoes(email);
        }

        [HttpPost("Cadastrar")]
        public Usuario Cadastrar([FromBody] Usuario usuario)
        {
            try
            {
                if (!string.IsNullOrEmpty(usuario.Email) && !string.IsNullOrEmpty(usuario.Senha))
                {
                    usuario.Administrador = false;

                    UsuarioService.Cadastrar(usuario);

                    return new Usuario(usuario.Email);
                }
                return new Usuario { ID = -1 };
            }
            catch
            {
                return new Usuario { ID = -1 };
            }
        }


        [HttpGet("Listar")]
        public IEnumerable<Usuario> Listar()
        {
            return UsuarioService.Listar();
        }
    }
}