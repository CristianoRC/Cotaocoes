namespace Cotacoes.Model
{
    public class UsuarioService
    {

        public static Usuario ObterInformacoes(string email)
        {
            return UsuarioRepository.Obter(email.ToLower());
        }

        public static void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Ferramentas.Criptografar(usuario.Senha);
            usuario.Email = usuario.Email.ToLower();

            UsuarioRepository.Adicionar(usuario);
        }

        public static void Deletar(string email)
        {
            email = email.ToLower();

            UsuarioRepository.Deletar(email);
        }

        public static void AtualizarCadastro(Usuario usuario)
        {
            usuario.Senha = Ferramentas.Criptografar(usuario.Senha);
            usuario.Email = usuario.Email.ToLower();

            UsuarioRepository.Atualizar(usuario);
        }

        public static bool Autenticar(string email, string senha)
        {
            senha = Ferramentas.Criptografar(senha);
            email = email.ToLower();

            return UsuarioRepository.Autenticar(email, senha);
        }

        public static string ObterNome(string email)
        {
            return UsuarioRepository.ObterNome(email.ToLower());
        }

        public static System.Collections.Generic.IEnumerable<Usuario> Listar()
        {
            return UsuarioRepository.Listar();
        }
    }
}