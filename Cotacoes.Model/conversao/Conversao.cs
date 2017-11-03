using System;

namespace Cotacoes.Model
{
    public class Conversao
    {
        public Double ValorConvertido { get; set; }
        public DateTime DataConsulta { get; set; }
        
        public Conversao(double valor)
        {
            ValorConvertido = valor;
            DataConsulta = CotacaoService.ObterDataUltumaCotacao();
        }
    }
}