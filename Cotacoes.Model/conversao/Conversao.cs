using System;

namespace Cotacoes.Model
{
    public class Conversao
    {
        public decimal ValorConvertido { get; set; }
        public DateTime DataConsulta { get; set; }
        
        public Conversao(decimal valor)
        {
            ValorConvertido = valor;
            DataConsulta = CotacaoService.ObterDataUltumaCotacao();
        }
    }
}