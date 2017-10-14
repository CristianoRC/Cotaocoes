using System;
using System.Collections.Generic;
using Dapper;

namespace Cotacao.Model
{
    internal class AtualizacoesCotacao : BancoDeDados
    {
        internal static void AtualizarCotacoes()
        {
            try
            {
                if (AtualizacoesCotacao.LiberarAtualizacao())
                {
                    var cotacoes = CSV.ListarCotacoesCSV();

                    InserirCotacoesNoBanco(cotacoes);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar cotações: {e.Message}");
            }
        }
        private static bool LiberarAtualizacao()
        {   /*
                O sistema do Banco Central libera atualizações somente de
                Segunda a Sexta, apartir das 13:00
             */

            if (DateTime.Now.Hour >= 13 && (DateTime.Now.DayOfWeek != DayOfWeek.Saturday &&
                                            DateTime.Now.DayOfWeek != DayOfWeek.Sunday))
            {
                string sql = $"Select max(data) from public.cotacoes";
                try
                {
                    AbrirConexao();
                    var dataSaida = conexao.QueryFirst<DateTime?>(sql);
                    FecharConexao();

                    if (dataSaida == null)
                        return true;
                    else if ((DateTime.Now - dataSaida.Value).TotalDays >= 1)
                        return true;
                    else
                        return false;

                }
                catch (Exception e)
                {
                    throw new Exception($"Erro ao buscar a data da ultima cotação: {e.Message}");
                }
            }
            else
                return false;
        }
        private static void InserirCotacoesNoBanco(IEnumerable<CotacaoMoeda> listaDeCotacoes)
        {
            string sql = @"insert into public.cotacoes values (@Data,@CodigoMoeda,@TaxaCompra,@TaxaVenda,
                                                         @ParidadeCompra,@ParidadeVenda)";

            AbrirConexao();
            conexao.Execute(sql, listaDeCotacoes);
            FecharConexao();
        }
    }
}