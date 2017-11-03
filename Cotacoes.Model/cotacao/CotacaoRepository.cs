using System;
using System.Collections.Generic;
using Dapper;

namespace Cotacoes.Model
{
    internal class CotacaoRepository : GenericRepository
    {
        internal static Cotacao ObterUltima(int codigoMoeda)
        {
            var sql = @"select t.* from public.cotacoes t
                         where t.codigomoeda = @codigo
                         and t.data = (select MAX(s.data)
                             from public.cotacoes s)";
            try
            {
                AbrirConexao();
                var cotacaoSaida = conexao.QueryFirst<Cotacao>(sql, new { codigo = codigoMoeda });
                FecharConexao();

                return cotacaoSaida;
            }
            catch
            {
                return new Cotacao { CodigoMoeda = -1 };
            }
        }

        internal static Cotacao ObterUltima(string siglaMoeda)
        {

            var sql = @"select t.* from public.cotacoes t
                         where t.codigomoeda = (select m.codigo from moedas m where m.sigla = @sigla)
                         and t.data = (select MAX(s.data) from public.cotacoes s)";
            try
            {

                AbrirConexao();
                var cotacaoSaida = conexao.QueryFirst<Cotacao>(sql, new { sigla = siglaMoeda });
                FecharConexao();

                return cotacaoSaida;
            }
            catch
            {
                return new Cotacao { CodigoMoeda = -1 };
            }
        }

        internal static void Adicionar(IEnumerable<Cotacao> listaDeCotacoes)
        {
            string sql = @"insert into public.cotacoes values (@Data,@CodigoMoeda,@TaxaCompra,@TaxaVenda,
                                                         @ParidadeCompra,@ParidadeVenda)";

            AbrirConexao();
            conexao.Execute(sql, listaDeCotacoes);
            FecharConexao();
        }

        internal static DateTime DataUltumaCotacao()
        {
            var sql = @"select MAX(s.data)from public.cotacoes s";
            try
            {
                AbrirConexao();
                var cotacaoSaida = conexao.QueryFirst<DateTime>(sql);
                FecharConexao();
                return cotacaoSaida;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar data da ultima cotação: { e.Message}");
            }
        }

        internal static IEnumerable<Cotacao> ListarUltimas()
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = @"select * from cotacoes where data =
                               (select MAX(s.data) from public.cotacoes s)";

            try
            {
                AbrirConexao();
                var listaSaida = conexao.Query<Cotacao>(sql);
                FecharConexao();

                return listaSaida;
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter a lista de moedas: {e.Message}");
            }
        }

        internal static IEnumerable<Cotacao> Listar()
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = "select * from cotacoes";

            try
            {
                AbrirConexao();
                var listaSaida = conexao.Query<Cotacao>(sql);
                FecharConexao();

                return listaSaida;
            }
            catch (System.Exception e)
            {
                throw new Exception($"Erro ao obter a lista de moedas: {e.Message}");
            }
        }

        internal static double ObterTaxaCompra(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = @"select t.taxacompra from public.cotacoes t
                        where t.codigomoeda = (select m.codigo from moedas m where m.sigla = @sigla)
                        and t.data = (select MAX(s.data) from public.cotacoes s)";
            try
            {
                AtualizacoesCotacao.AtualizarCotacoes();

                AbrirConexao();
                var taxaCompra = conexao.QueryFirst<double>(sql, new { sigla = siglaMoeda });
                FecharConexao();
                return taxaCompra;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar a Taxa de compra - {siglaMoeda}: { e.Message}");
            }
        }

        internal static double ObterTaxaVenda(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = @"select t.taxavenda from public.cotacoes t
                        where t.codigomoeda = (select m.codigo from moedas m where m.sigla = @sigla)
                        and t.data = (select MAX(s.data) from public.cotacoes s)";
            try
            {
                AtualizacoesCotacao.AtualizarCotacoes();

                AbrirConexao();
                var taxaCompra = conexao.QueryFirst<double>(sql, new { sigla = siglaMoeda });
                FecharConexao();
                return taxaCompra;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar a Taxa de venda - {siglaMoeda}: { e.Message}");
            }
        }

        internal static double ObterParidadeCompra(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = @"select t.paridadecompra from public.cotacoes t
                        where t.codigomoeda = (select m.codigo from moedas m where m.sigla = @sigla)
                        and t.data = (select MAX(s.data) from public.cotacoes s)";
            try
            {
                AtualizacoesCotacao.AtualizarCotacoes();

                AbrirConexao();
                var taxaCompra = conexao.QueryFirst<double>(sql, new { sigla = siglaMoeda });
                FecharConexao();
                return taxaCompra;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar a paridade de compra - {siglaMoeda}: { e.Message}");
            }
        }

        internal static double ObterParidadeVenda(string siglaMoeda)
        {
            AtualizacoesCotacao.AtualizarCotacoes();

            var sql = @"select t.paridadevenda from public.cotacoes t
                        where t.codigomoeda = (select m.codigo from moedas m where m.sigla = @sigla)
                        and t.data = (select MAX(s.data) from public.cotacoes s)";
            try
            {
                AtualizacoesCotacao.AtualizarCotacoes();

                AbrirConexao();
                var taxaCompra = conexao.QueryFirst<double>(sql, new { sigla = siglaMoeda });
                FecharConexao();
                return taxaCompra;
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar a paridade de venda - {siglaMoeda}: { e.Message}");
            }
        }
    }
}