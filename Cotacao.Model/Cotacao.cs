using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace Cotacao.Model
{
    public class Cotacao : BancoDeDados
    {
        public DateTime Data { get; set; }
        public int CodigoMoeda { get; set; }
        public Double TaxaCompra { get; set; }
        public Double TaxaVenda { get; set; }
        public Double ParidadeCompra { get; set; }
        public Double ParidadeVenda { get; set; }

        //Informações moeda
        public char Tipo { get; set; }
        public string Sigla { get; set; }

        private static void InserirCotacoesNoBanco(IEnumerable<Cotacao> listaDeCotacoes)
        {
            string sql = @"insert into public.cotacoes values (@Data,@CodigoMoeda,@TaxaCompra,@TaxaVenda,
                                                         @ParidadeCompra,@ParidadeVenda)";

            AbrirConexao();
            conexao.Execute(sql, listaDeCotacoes);
            FecharConexao();
        }

        public static void AtualizarCotacoes()
        {
            try
            {
                if (LiberarAtualizacao())
                {
                    var cotacoes = AtualizacoesCotacao.ListarCotacoesAtuais();

                    InserirCotacoesNoBanco(cotacoes);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar cotações: {e.Message}");
            }
        }


        private static bool LiberarAtualizacao()
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
    }
}