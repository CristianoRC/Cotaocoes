using System;
using Dapper;

namespace Cotacao.Model
{
    public class Convercao : BancoDeDados
    {
        public Double ValorConvertido { get; set; }
        public DateTime DataConsulta { get; set; }
        public Convercao(double valor)
        {
            ValorConvertido = valor;
            DataConsulta = CotacaoMoeda.ObterDataUltumaCotacao();
        }
        public static Convercao ConverterParaReais(double Montante, string SiglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select public.ConverterParaReais(@sigla,@montante)";
            try
            {
                AbrirConexao();
                var valorConvercao = conexao.QueryFirst<Double>(sql, new { montante = Montante, sigla = SiglaMoeda.ToUpper() });
                FecharConexao();

                return new Convercao(valorConvercao);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao converter valor para Reais (BRL): {e.Message}");
            }
        }
        public static Convercao ConverterParaDolar(double Montante, string SiglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select public.ConverterParaDolar(@sigla,@montante)";
            try
            {
                AbrirConexao();
                var valorConvercao = conexao.QueryFirst<Double>(sql, new { montante = Montante, sigla = SiglaMoeda.ToUpper() });
                FecharConexao();

                return new Convercao(valorConvercao);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao converter valor para Reais (BRL): {e.Message}");
            }
        }
    }
}