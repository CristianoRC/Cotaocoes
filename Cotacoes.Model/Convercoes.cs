using System;
using Dapper;

namespace Cotacoes.Model
{
    public class Convercao
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
            catch
            {
                return new Convercao(-1);
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
            catch
            {
                return new Convercao(-1);
            }
        }
    }
}