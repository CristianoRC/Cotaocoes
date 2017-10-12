using System;
using Microsoft.Data.Sqlite;
using Dapper;
using System.Collections.Generic;

namespace Cotacao.Model
{
    public class Moeda
    {
        #region Propriedades

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public string NomePais { get; private set; }
        public int CodigoPais { get; private set; }
        public char Tipo { get; private set; }
        #endregion

        public Moeda()
        {

        }
        public Moeda(int codigo)
        {
            var sql = "select * from Moedas where codigo = @CodigoMoeda";

            try
            {
                using (SqliteConnection db = new SqliteConnection(Ferramentas.StrConexao()))
                {
                    db.Open();
                    var moedaSaida = db.QueryFirst<Moeda>(sql, new { CodigoMoeda = codigo });
                    db.Close();

                    atualizarPropriedades(moedaSaida);
                }
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao carregar Moeda: {e.Message}");
            }
        }


        public static string ObterNomePais(int codigoMoeda)
        {
            var sql = "select nomepais  from Moedas where codigo = @CodigoMoeda";

            try
            {
                using (SqliteConnection db = new SqliteConnection(Ferramentas.StrConexao()))
                {
                    db.Open();
                    var nomePais = db.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                    db.Close();

                    return nomePais;
                }
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o nome do país: {e.Message}");
            }
        }

        public static string ObterCodigoPais(int codigoMoeda)
        {
            var sql = "select CodigoPais  from Moedas where codigo = @CodigoMoeda";

            try
            {
                using (SqliteConnection db = new SqliteConnection(Ferramentas.StrConexao()))
                {
                    db.Open();
                    var codigoPais = db.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                    db.Close();

                    return codigoPais;
                }
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter o código do país: {e.Message}");
            }
        }

        public static string ObterSiglaMoeda(int codigoMoeda)
        {
            var sql = "select sigla from Moedas where codigo = @CodigoMoeda";

            try
            {
                using (SqliteConnection db = new SqliteConnection(Ferramentas.StrConexao()))
                {
                    db.Open();
                    var siglaMoeda = db.QueryFirst<string>(sql, new { CodigoMoeda = codigoMoeda });
                    db.Close();

                    return siglaMoeda;
                }
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
                using (SqliteConnection db = new SqliteConnection(Ferramentas.StrConexao()))
                {
                    db.Open();
                    var tipoMoeda = db.QueryFirst<char>(sql, new { CodigoMoeda = codigoMoeda });
                    db.Close();

                    return tipoMoeda;
                }
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
                using (SqliteConnection db = new SqliteConnection(Ferramentas.StrConexao()))
                {
                    db.Open();
                    var listaSaida = db.Query<Moeda>(sql);
                    db.Close();

                    return listaSaida;
                }
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