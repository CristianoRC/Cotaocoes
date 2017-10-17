using System;
using Dapper;

namespace Cotacao.Model
{
    public class Usuario : BancoDeDados
    {
        public int ID { get; private set; }
        public string ChaveDeAcesso { get; private set; }

        public Usuario(int id)
        {
            var sql = "Selct * from usuarios where id = @ID";

            try
            {
                AbrirConexao();
                var usuario = conexao.QueryFirstOrDefault<Usuario>(sql, new { ID = id });
                FecharConexao();

                this.ID = usuario.ID;
                this.ChaveDeAcesso = usuario.ChaveDeAcesso;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao carregar informações do usuário: {e.Message}");
            }
        }
    }
}