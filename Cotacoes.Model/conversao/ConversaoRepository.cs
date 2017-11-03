using System;
using Dapper;

namespace Cotacoes.Model
{
    internal class ConversaoRepository : GenericRepository
    {
        internal static Conversao ConverterParaReais(double Montante, string SiglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select public.ConverterParaReais(@sigla,@montante)";
            try
            {
                AbrirConexao();
                var valorConvercao = conexao.QueryFirst<Double>(sql, new { montante = Montante, sigla = SiglaMoeda.ToUpper() });
                FecharConexao();

                return new Conversao(valorConvercao);
            }
            catch
            {
                return new Conversao(-1);
            }
        }
        
        internal static Conversao ConverterParaDolar(double Montante, string SiglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select public.ConverterParaDolar(@sigla,@montante)";
            try
            {
                AbrirConexao();
                var valorConvercao = conexao.QueryFirst<Double>(sql, new { montante = Montante, sigla = SiglaMoeda.ToUpper() });
                FecharConexao();

                return new Conversao(valorConvercao);
            }
            catch
            {
                return new Conversao(-1);
            }
        }
    }
}