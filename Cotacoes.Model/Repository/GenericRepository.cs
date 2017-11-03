using System.Data;
using Npgsql;

namespace Cotacoes.Model
{
    internal abstract class GenericRepository
    {
        private static readonly string Strconnection = @"User ID=postgres;Password=cotacoes123456;Host=192.168.0.109;Port=5432;Database=Cotacoes;";

        internal static NpgsqlConnection conexao = new NpgsqlConnection(Strconnection);

        internal static void AbrirConexao()
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

        internal static void FecharConexao()
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