using System;
using System.Collections.Generic;
using System.Net;
using Dapper;

namespace Cotacao.Model
{
    public class Cotacao : BancoDeDados
    {
        public int Data { get; set; }
        public int CodigoMoeda { get; set; }
        public Double TaxaCompra { get; set; }
        public Double TaxaVenda { get; set; }
        public Double ParidadeCompra { get; set; }
        public Double ParidadeVenda { get; set; }

        //Informações moeda
        public char Tipo { get; set; }
        public string Sigla { get; set; }

        internal static void AtualizarCotacoes()
        {
            try
            {
                if (ObterDataUltimaCotacao() <= Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")))
                {
                    var cotacoes = AtualizacoesCotacao.ListarCotacoesDiarias();
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao atualizar cotações: {e.Message}");
            }


        }

        private static void InserirCotacoesNoBanco(IEnumerable<Cotacao> listaDeCotacoes)
        {
            
        }
        private static int ObterDataUltimaCotacao()
        {
            string sql = $"Select max(data) from cotacoes";
            try
            {
                AbrirConexao();
                var dataSaida = conexao.QueryFirst<int>(sql);
                FecharConexao();

                return dataSaida;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar a data da ultima cotação: {e.Message}");
            }
        }
    }
}