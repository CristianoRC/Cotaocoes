using System;
using Dapper;

namespace Cotacao.Model
{
    public class Usuario : BancoDeDados
    {
        public int ID { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public bool Administrador { get; set; }

        public bool Ativo { get; set; }

        public Usuario(string email)
        {
            try
            {
                AbrirConexao();
                var usuTemp = conexao.QueryFirst<Usuario>("select * from usuarios where email = @EmailUsu",
                                                     new { EmailUsu = email.ToLower() });
                FecharConexao();

                this.Administrador = usuTemp.Administrador;
                this.Ativo = usuTemp.Ativo;
                this.Email = usuTemp.Email;
                this.ID = usuTemp.ID;
                this.Nome = usuTemp.Nome;
                this.Senha = usuTemp.Senha;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao carregar informações do usuário: {e.Message}");
            }
        }
        public Usuario() { }

        public static void Cadastrar(Usuario usuario)
        {
            var sql = @"Insert into usuarios (nome,email,senha,administrador,ativo) 
                        values(@nome,@email,@senha,@administrador,@ativo)";

            usuario.Senha = Ferramentas.Criptografar(usuario.Senha);
            usuario.Email = usuario.Email.ToLower();

            try
            {
                AbrirConexao();
                conexao.Execute(sql, usuario);
                FecharConexao();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("duplicar valor da chave viola a restrição de unicidade"))
                    throw new Exception("Email já cadastrado.");
                else
                    throw new Exception($"Erro ao cadastrar usuário: {e.Message}");
            }
        }
        public static bool Autenticar(string email, string senha)
        {
            var sql = @"select AutenticarUsuario(@EmailUsuario, @SenhaUsuario)";

            senha = Ferramentas.Criptografar(senha);
            email = email.ToLower();

            try
            {
                AbrirConexao();
                var resultado = conexao.QueryFirst<bool>(sql, new { SenhaUsuario = senha, EmailUsuario = email });
                FecharConexao();

                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao cadastrar usuário: {e.Message}");
            }
        }
    }
}