using System;
using System.Collections.Generic;
using System.Net;

namespace Cotacao.Model
{
    public static class AtualizacoesCotacao
    {

        private static string ObterCSVCotacoes()
        {
            var data = DateTime.Now.ToString("yyyyMMdd");
            var enderecoArquivo = $"http://www4.bcb.gov.br/Download/fechamento/20171011.csv";

            try
            {
                using (var webClient = new WebClient())
                {
                    return webClient.DownloadString(enderecoArquivo);
                }
            }
            catch
            {
                return String.Empty;
            }
        }

        private static Cotacao PreencherValoresCotacao(String Linha)
        {
            string[] informacoes = Linha.Split(';'); //Colocando cada valor separado por ';' no array

            Cotacao CotacaoBase = new Cotacao();

            CotacaoBase.Data = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            CotacaoBase.CodigoMoeda = int.Parse(informacoes[1]);
            CotacaoBase.Tipo = Convert.ToChar(informacoes[2]);
            CotacaoBase.Sigla = informacoes[3];

            CotacaoBase.TaxaCompra = Double.Parse(informacoes[4]);
            CotacaoBase.TaxaVenda = Double.Parse(informacoes[5]);
            CotacaoBase.ParidadeCompra = Double.Parse(informacoes[6]);
            CotacaoBase.ParidadeVenda = Double.Parse(informacoes[4]);

            return CotacaoBase;
        }

        internal static IEnumerable<Cotacao> ListarCotacoesDiarias()
        {
            try
            {
                var listaCotacoes = new List<Cotacao>();

                var linhasCSV = ObterCSVCotacoes().Replace('\r', ' ').Trim().Split('\n');

                foreach (var linha in linhasCSV)
                {
                    listaCotacoes.Add(PreencherValoresCotacao(linha));
                }

                return listaCotacoes;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao converter o CSV de cotações em lista: {e.Message}");
            }

        }
    }
}