using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace Cotacao.Model
{
    public class CotacaoMoeda : BancoDeDados
    {
        public DateTime Data { get; set; }
        public int CodigoMoeda { get; set; }
        public Double TaxaCompra { get; set; }
        public Double TaxaVenda { get; set; }
        public Double ParidadeCompra { get; set; }
        public Double ParidadeVenda { get; set; }


        public CotacaoMoeda(int CodigoMoeda)
        {
            var sql = @"select t.* from public.cotacoes t
                        where t.codigomoeda = @codigo
                        and t.data = (select MAX(s.data)
                            from public.cotacoes s)";
            try
            {
                AtualizacoesCotacao.AtualizarCotacoes();

                AbrirConexao();
                var cotacaoSaida = conexao.QueryFirst<CotacaoMoeda>(sql, new { codigo = CodigoMoeda });
                FecharConexao();
                atualizarPropriedades(cotacaoSaida);
            }
            catch
            {
                this.CodigoMoeda = -1;
            }
        }

        public CotacaoMoeda(string siglaMoeda)
        {
            var sql = @"select t.* from public.cotacoes t
                        where t.codigomoeda = (select m.codigo from moedas m where m.sigla = @sigla)
                        and t.data = (select MAX(s.data) from public.cotacoes s)";
            try
            {
                AtualizacoesCotacao.AtualizarCotacoes();

                AbrirConexao();
                var cotacaoSaida = conexao.QueryFirst<CotacaoMoeda>(sql, new { sigla = siglaMoeda });
                FecharConexao();

                if (cotacaoSaida.CodigoMoeda != 0)
                {
                    atualizarPropriedades(cotacaoSaida);
                }
            }
            catch
            {
                this.CodigoMoeda = -1;
            }
        }
        public CotacaoMoeda()
        {
        }

        public static double ObterTaxaCompra(string siglaMoeda)
        {
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

        public static double ObterTaxaVenda(string siglaMoeda)
        {
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

        public static double ObterParidadeCompra(string siglaMoeda)
        {
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

        public static double ObterParidadeVenda(string siglaMoeda)
        {
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


        public static DateTime ObterDataUltumaCotacao()
        {
            var sql = @"select MAX(s.data)from public.cotacoes s";
            try
            {
                AtualizacoesCotacao.AtualizarCotacoes();

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
        private void atualizarPropriedades(CotacaoMoeda cotacaoConsulta)
        {
            this.CodigoMoeda = cotacaoConsulta.CodigoMoeda;
            this.Data = cotacaoConsulta.Data;
            this.ParidadeCompra = cotacaoConsulta.ParidadeCompra;
            this.ParidadeVenda = cotacaoConsulta.ParidadeVenda;
            this.TaxaCompra = cotacaoConsulta.TaxaCompra;
            this.TaxaVenda = cotacaoConsulta.TaxaVenda;
        }
    }
}