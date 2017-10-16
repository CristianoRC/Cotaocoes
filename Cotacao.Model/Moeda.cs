using System;
using Dapper;
using System.Collections.Generic;

namespace Cotacao.Model
{
    public class Moeda : BancoDeDados
    {
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public string NomePais { get; private set; }
        public int CodigoPais { get; private set; }
        public char Tipo { get; private set; }


        public Moeda(int codigo)
        {
            var sql = "select * from public.Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var moedaSaida = conexao.QueryFirst<Moeda>(sql, new { CodigoMoeda = codigo });
                FecharConexao();

                atualizarPropriedades(moedaSaida);
            }
            catch
            {
                this.Codigo = -1;
            }
        }

        public Moeda(string sigla)
        {
            var sql = "select * from public.Moedas where sigla = @siglaMoeda";

            try
            {
                AbrirConexao();
                var moedaSaida = conexao.QueryFirst<Moeda>(sql, new { siglaMoeda = sigla.ToUpper() });
                FecharConexao();

                atualizarPropriedades(moedaSaida);
            }
            catch
            {
                this.Codigo = -1;
            }
        }

        public Moeda()
        {

        }
        public static string ObterNomeMoeda(int codigoMoeda)
        {
            var sql = "select nome  from public.Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var nomePais = conexao.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                FecharConexao();

                return nomePais;
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o nome da moeda: {e.Message}");
            }
        }

        public static string ObterNomePais(int codigoMoeda)
        {
            var sql = "select nomepais  from public.Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var nomePais = conexao.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                FecharConexao();

                return nomePais;
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o nome do país: {e.Message}");
            }
        }

        public static string ObterCodigoPais(int codigoMoeda)
        {
            var sql = "select CodigoPais  from public.Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var codigoPais = conexao.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                FecharConexao();
                return codigoPais;

            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o código do país: {e.Message}");
            }
        }

        public static string ObterSiglaMoeda(int codigoMoeda)
        {
            var sql = "select sigla from public.Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var siglaMoeda = conexao.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                FecharConexao();
                return siglaMoeda;

            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter a sigla da moeda: {e.Message}");
            }
        }

        public static char ObterTipoMoeda(int codigoMoeda)
        {
            var sql = "select tipo from Moedas where codigo = @CodigoMoeda";

            try
            {
                AbrirConexao();
                var tipoMoeda = conexao.QueryFirst<char>(sql, new { CodigoMoeda = codigoMoeda });
                FecharConexao();

                return tipoMoeda;
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o tipo da moeda: {e.Message}");
            }
        }

        public static IEnumerable<Moeda> Listar()
        {
            var sql = "select * from Moedas";

            try
            {
                AbrirConexao();
                var listaSaida = conexao.Query<Moeda>(sql);
                FecharConexao();

                return listaSaida;
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter a lista de moedas: {e.Message}");
            }
        }

        private void atualizarPropriedades(Moeda moedaConsulta)
        {
            this.Codigo = moedaConsulta.Codigo;
            this.CodigoPais = moedaConsulta.CodigoPais;
            this.Nome = moedaConsulta.Nome;
            this.NomePais = moedaConsulta.NomePais;
            this.Sigla = moedaConsulta.Sigla;
            this.Tipo = moedaConsulta.Tipo;
        }
    }
}