using System;
using System.Collections.Generic;
using System.Net;

namespace Cotacao.Model
{
    internal static class CSV
    {
        internal static IEnumerable<Cotacao> ListarCotacoesCSV()
        {
            try
            {
                var listaCotacoes = new List<Cotacao>();

                var linhasCSV = ObterCSVCotacoes().Replace(',', '.').Trim().Split('\n');

                if (linhasCSV.Length != 0)
                {
                    foreach (var linha in linhasCSV)
                    {
                        listaCotacoes.Add(PreencherValoresCotacao(linha));
                    }
                }


                return listaCotacoes;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao converter o CSV de cotações em lista: {e.Message}");
            }

        }

        private static string ObterCSVCotacoes()
        {
            var data = DateTime.Now.ToString("yyyyMMdd");
            var enderecoArquivo = $"http://www4.bcb.gov.br/Download/fechamento/{data}.csv";

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

            CotacaoBase.Data = DateTime.Now;
            CotacaoBase.CodigoMoeda = Convert.ToInt16(informacoes[1]);
            //2 E 3 --> Eram os códigos e o Tipo, mas a busca é feita via banco

            CotacaoBase.TaxaCompra = Convert.ToDouble(informacoes[4]);
            CotacaoBase.TaxaVenda = Convert.ToDouble(informacoes[5]);
            CotacaoBase.ParidadeCompra = Convert.ToDouble(informacoes[6]);
            CotacaoBase.ParidadeVenda = Convert.ToDouble(informacoes[7]);

            return CotacaoBase;
        }
    }
}