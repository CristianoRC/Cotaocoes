using System;
using Dapper;

namespace Cotacoes.Model
{
    internal class ConversaoRepository : GenericRepository
    {
        internal static Conversao ConverterParaReais(decimal Montante, string SiglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select public.ConverterParaReais(@sigla,@montante)";
            try
            {
                AbrirConexao();
                var valorConvercao = conexao.QueryFirst<decimal>(sql, new { montante = Montante, sigla = SiglaMoeda.ToUpper() });
                FecharConexao();

                return new Conversao(valorConvercao);
            }
            catch
            {
                return new Conversao(-1);
            }
        }
        internal static Conversao ConverterParaDolar(decimal Montante, string SiglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select public.ConverterParaDolar(@sigla,@montante)";
            try
            {
                AbrirConexao();
                var valorConvercao = conexao.QueryFirst<decimal>(sql, new { montante = Montante, sigla = SiglaMoeda.ToUpper() });
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