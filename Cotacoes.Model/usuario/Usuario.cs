namespace Cotacoes.Model
{
    public class Usuario
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public bool Administrador { get; set; }
        

        public Usuario(string email)
        {
            try
            {
                var usuTemp = UsuarioService.ObterInformacoes(email);

                this.Administrador = usuTemp.Administrador;
                this.Email = usuTemp.Email;
                this.ID = usuTemp.ID;
                this.Nome = usuTemp.Nome;
                this.Senha = usuTemp.Senha;
            }
            catch (System.Exception e)
            {
                throw new System.Exception($"Erro ao carregar informações do usuário: {e.Message}");
            }
        }

        public Usuario() { }
    }
}