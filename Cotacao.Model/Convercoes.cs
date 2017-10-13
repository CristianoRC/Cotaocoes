using System;
using Dapper;

namespace Cotacao.Model
{
    public class Convercoes : BancoDeDados
    {
        public static double ConverterParaReais(double Montante, string SiglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select public.ConverterParaReais(@sigla,@montante)";
            try
            {
                AbrirConexao();
                var convercao = conexao.QueryFirst<Double>(sql, new { montante = Montante, sigla = SiglaMoeda.ToUpper() });
                FecharConexao();

                return convercao;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao converter valor para Reais (BRL): {e.Message}");
            }
        }

        public static double ConverterParaDolar(double Montante, string SiglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select public.ConverterParaDolar(@sigla,@montante)";
            try
            {
                AbrirConexao();
                var convercao = conexao.QueryFirst<Double>(sql, new { montante = Montante, sigla = SiglaMoeda.ToUpper() });
                FecharConexao();

                return convercao;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao converter valor para Reais (BRL): {e.Message}");
            }
        }
    }
}