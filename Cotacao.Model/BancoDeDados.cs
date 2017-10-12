using System.Data;
using Npgsql;

namespace Cotacao.Model
{
    public abstract class BancoDeDados
    {
        private static readonly string Strconnection = @"User ID=postgres;Password=cotacoes123456;Host=192.168.0.109;Port=5432;Database=Cotacoes;";

        protected static NpgsqlConnection conexao = new NpgsqlConnection(Strconnection);

        protected static void AbrirConexao()
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
            }
            catch (System.Exception e)
            {
                throw new System.Exception($"Erro ao abrir a conexão com o banco: {e.Message}");
            }
        }

        protected static void FecharConexao()
        {
            try
            {
                if (conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
            catch (System.Exception e)
            {

                throw new System.Exception($"Erro ao fechar a conexão com o banco: {e.Message}");
            }
        }
    }
}