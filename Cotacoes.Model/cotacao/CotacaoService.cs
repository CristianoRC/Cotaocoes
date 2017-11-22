using System;
using System.Collections.Generic;

namespace Cotacoes.Model
{
    public class CotacaoService
    {
        public static Cotacao ObterUltima(int codigoMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterUltima(codigoMoeda);
        }

        public static Cotacao ObterUltima(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterUltima(siglaMoeda.ToUpper());
        }

        public static void Adicionar(IEnumerable<Cotacao> listaDeCotacoes)
        {
            CotacaoRepository.Adicionar(listaDeCotacoes);
        }

        public static DateTime ObterDataUltumaCotacao()
        {
            return CotacaoRepository.DataUltumaCotacao();
        }

        public static IEnumerable<Cotacao> ListarUltimasCotacoes()
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ListarUltimas();
        }

        public static IEnumerable<Cotacao> ListarCotacoes()
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.Listar();
        }

        public static decimal ObterTaxaCompra(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterTaxaCompra(siglaMoeda.ToUpper());

        }

        public static decimal ObterTaxaVenda(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterTaxaVenda(siglaMoeda.ToUpper());
        }

        public static decimal ObterParidadeCompra(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterParidadeCompra(siglaMoeda.ToUpper());
        }

        public static decimal ObterParidadeVenda(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            return CotacaoRepository.ObterParidadeVenda(siglaMoeda.ToUpper());
        }
    }
}