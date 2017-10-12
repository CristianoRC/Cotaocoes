using Microsoft.Data.Sqlite;
using System.Data;

namespace Cotacao.Model
{
    public abstract class BancoDeDados
    {
        private static readonly string Strconnection = @"Data Source=/home/cristiano/Projetos/Cotacoes/DB/Cotacao.db";

        protected static SqliteConnection conexao = new SqliteConnection(Strconnection);

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