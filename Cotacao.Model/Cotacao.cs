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


        public Cotacao(int CodigoMoeda)
        {
            var sql = @"select t.* from public.cotacoes t
                        where t.codigomoeda = @codigo
                        and t.data = (select MAX(s.data)
                            from public.cotacoes s)";
            try
            {
                AtualizacoesCotacao.AtualizarCotacoes();

                AbrirConexao();
                var cotacaoSaida = conexao.QueryFirst<Cotacao>(sql, new { codigo = CodigoMoeda });
                FecharConexao();
                atualizarPropriedades(cotacaoSaida);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao carregar Cotação: { e.Message}");
            }


        }
        public Cotacao()
        {
        }

        private void atualizarPropriedades(Cotacao cotacaoConsulta)
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