using System;
using System.Collections.Generic;
using Dapper;

namespace Cotacoes.Model
{
    internal class MoedaRepository : GenericRepository
    {

        internal static Moeda ObterMoeda(int codigo)
        {
            var sql = "select * from public.Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var moedaSaida = conexao.QueryFirst<Moeda>(sql, new { CodigoMoeda = codigo });
                FecharConexao();

                return moedaSaida;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao Obter informações sobre a moeda: {e.Message}");
            }
        }

        internal static Moeda ObterMoeda(string sigla)
        {
            var sql = "select * from public.Moedas where sigla = @siglaMoeda";

            try
            {
                AbrirConexao();
                var moedaSaida = conexao.QueryFirst<Moeda>(sql, new { siglaMoeda = sigla });
                FecharConexao();

                return moedaSaida;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao Obter informações sobre a moeda: {e.Message}");
            }
        }

        internal static string ObterNomeMoeda(string siglaMoeda)
        {
            var sql = "select nome  from public.Moedas where sigla = @SiglaMoeda";

            try
            {
                AbrirConexao();
                var nomePais = conexao.QueryFirst<string>(sql, new { SiglaMoeda = siglaMoeda });
                FecharConexao();

                return nomePais;
            }
            catch
            {
                return "-";
            }
        }

        internal static string ObterNomeMoeda(int codigoMoeda)
        {
            var sql = "select nome  from public.Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var nomePais = conexao.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                FecharConexao();

                return nomePais;
            }
            catch
            {
                return "-";
            }
        }

        internal static string ObterNomePais(string siglaMoeda)
        {
            var sql = "select nomepais  from public.Moedas where sigla = @SiglaMoeda";

            try
            {
                AbrirConexao();
                var nomePais = conexao.QueryFirst<string>(sql, new { SiglaMoeda = siglaMoeda });
                FecharConexao();

                return nomePais;
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o nome do país: {e.Message}");
            }
        }

        internal static string ObterSiglaMoeda(int codigoMoeda)
        {
            var sql = "select sigla from public.Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var nomePais = conexao.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                FecharConexao();

                return nomePais;
            }
            catch
            {
                return "-";
            }
        }

        internal static string ObterCodigoPais(string siglaMoeda)
        {
            var sql = "select CodigoPais  from public.Moedas where sigla = @SiglaMoeda";

            try
            {
                AbrirConexao();
                var codigoPais = conexao.QueryFirst<string>(sql, new { SiglaMoeda = siglaMoeda });
                FecharConexao();
                return codigoPais;

            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o código do país: {e.Message}");
            }
        }

        internal static string ObterCodigoMoeda(string siglaMoeda)
        {
            var sql = "select codigo from public.Moedas where sigla = @SiglaMoeda";

            try
            {
                AbrirConexao();
                var codigoMoeda = conexao.QueryFirst<string>(sql, new { SiglaMoeda = siglaMoeda });
                FecharConexao();
                return codigoMoeda;

            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter a sigla da moeda: {e.Message}");
            }
        }

        internal static char ObterTipoMoeda(string siglaMoeda)
        {
            var sql = "select tipo from Moedas where sigla = @SiglaMoeda";

            try
            {
                AbrirConexao();
                var tipoMoeda = conexao.QueryFirst<char>(sql, new { SiglaMoeda = siglaMoeda });
                FecharConexao();

                return tipoMoeda;
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o tipo da moeda: {e.Message}");
            }
        }

        internal static char ObterTipoMoeda(int codigoMoeda)
        {
            var sql = "select tipo from Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var tipoMoeda = conexao.QueryFirst<char>(sql, new { CodigoMoeda = codigoMoeda });
                FecharConexao();

                return tipoMoeda;
            }
            catch
            {
                return '-';
            }
        }

        public static IEnumerable<Moeda> Listar()
        {
            var sql = "select * from public.Moedas";

            try
            {
                AbrirConexao();
                var listaSaida = conexao.Query<Moeda>(sql);
                FecharConexao();

                return listaSaida;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);

                throw new Exception($"Erro ao obter a lista de moedas: {e.Message}");
            }
        }
    }
}